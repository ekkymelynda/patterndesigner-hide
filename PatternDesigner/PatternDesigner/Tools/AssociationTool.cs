using PatternDesigner.Shapes;
using System;
using System.Windows.Forms;

namespace PatternDesigner.Tools
{
    public partial class AssociationTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private AssociationLine associationLine;
        private Vertex StartingObject;
        private Vertex EndingObject;

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

        public AssociationTool()
        {
            this.Name = "Association Line tool";
            this.ToolTipText = "Association Line tool";
            this.Image = IconSet.assosiation;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                associationLine = new AssociationLine(new System.Drawing.Point(e.X, e.Y));
                associationLine.Endpoint = new System.Drawing.Point(e.X, e.Y);
                canvas.AddDrawingObject(associationLine);
                if(canvas.GetObjectAt(e.X,e.Y) is Vertex)
                {
                    StartingObject = (Vertex)canvas.GetObjectAt(e.X, e.Y);
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.associationLine != null)
                {
                    associationLine.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (this.associationLine != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    associationLine.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    associationLine.Select();

                    if (canvas.GetObjectAt(e.X, e.Y) is Vertex)
                    {
                        EndingObject = (Vertex)canvas.GetObjectAt(e.X, e.Y);
                        if (StartingObject != null)
                        {
                            StartingObject.Subscribe(associationLine);
                            associationLine.AddVertex(StartingObject);
                        }

                        if (EndingObject != null)
                        {
                            EndingObject.Subscribe(associationLine);
                            associationLine.AddVertex(EndingObject);
                        }
                    }
                    else if(!(canvas.GetObjectAt(e.X, e.Y) is Vertex))
                    {
                        canvas.RemoveDrawingObject(this.associationLine);
                    }

                    
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.associationLine);
                }
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
