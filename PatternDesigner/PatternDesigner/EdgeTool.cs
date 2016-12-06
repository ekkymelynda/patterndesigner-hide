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
                return Cursors.Arrow;
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
            if (e.Button == MouseButtons.Left)
            {
                if (canvas.GetObjectAt(e.X, e.Y) is Vertex)
                {
                    StartingObject = (Vertex)canvas.GetObjectAt(e.X, e.Y);
                    MakeLine();
                    line.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    canvas.AddDrawingObject(line);
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
                    if (canvas.GetObjectAt(e.X, e.Y) is Vertex)
                    {
                        EndingObject = (Vertex)canvas.GetObjectAt(e.X, e.Y);
                        line.Endpoint = new System.Drawing.Point(EndingObject.X, (EndingObject.Height / 2) + EndingObject.Y);
                        line.Select();

                        StartingObject.Subscribe(line);
                        line.AddVertex(StartingObject);

                        EndingObject.Subscribe(line);
                        line.AddVertex(EndingObject);
                    }
                    else
                    {
                        canvas.RemoveDrawingObject(this.line);
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.line);
                }
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e){}
    }
}
