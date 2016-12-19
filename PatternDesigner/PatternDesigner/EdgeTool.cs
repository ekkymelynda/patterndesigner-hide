using PatternDesigner.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner
{
    public abstract class EdgeTool : ToolStripButton, ITool
    {
        public Edge line;
        public Vertex StartingObject;
        public Vertex EndingObject;
        private ICanvas canvas;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Cross;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public abstract void MakeLine();

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursor;
            if (e.Button == MouseButtons.Left)
            {
                if (canvas.GetObjectAt(e.X, e.Y) is Vertex)
                {
                    StartingObject = (Vertex)canvas.GetObjectAt(e.X, e.Y);
                    MakeLine();
                    
                    line.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    canvas.AddDrawingObject(line);
                    canvas.GetListSelectedObject().Clear();
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.line != null)
                {
                    line.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (this.line != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (canvas.GetObjectAt(e.X, e.Y) is Vertex && canvas.GetObjectAt(e.X, e.Y) != StartingObject)
                    {
                        EndingObject = (Vertex)canvas.GetObjectAt(e.X, e.Y);
                        foreach(Edge edge in StartingObject.GetEdgeList()) {
                            if(edge.GetEndVertex() == EndingObject || edge.GetStartVertex() == EndingObject)
                            {
                                canvas.RemoveDrawingObject(line);
                                
                                line = null;
                                break;
                            }
                        }
                        if(line != null)
                        {
                            line.Endpoint = new System.Drawing.Point(EndingObject.X, (EndingObject.Height / 2) + EndingObject.Y);
                            line.Select();

                            StartingObject.Subscribe(line);
                            line.AddVertex(StartingObject);

                            EndingObject.Subscribe(line);
                            line.AddVertex(EndingObject);

                            ICommand command = new CreateRelationship(line, canvas);
                            canvas.AddCommand(command);
                            canvas.SetSelectedObject(line);
                            canvas.DeselectAllObjects();
                            line.Select();
                        }
                        
                    }
                    else if(!(canvas.GetSelectedObject() is Edge) || !(canvas.GetObjectAt(e.X, e.Y) is Vertex))
                    {
                        if(line != null)
                            canvas.RemoveDrawingObject(this.line);
                    }
                    line = null;
                }
                /*else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.line);
                }*/
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e){}

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            throw new NotImplementedException();
        }
    }
}
