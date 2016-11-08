using PatternDesigner.Shapes;
using System;
using System.Windows.Forms;

namespace PatternDesigner.Tools
{
    public partial class DirectedTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DirectedAssociationLine directedLine;

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

        public DirectedTool()
        {
            this.Name = "Directed Association Line tool";
            this.ToolTipText = "Directed Association Line tool";
            this.Image = IconSet.directed;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                directedLine = new DirectedAssociationLine(new System.Drawing.Point(e.X, e.Y));
                directedLine.Endpoint = new System.Drawing.Point(e.X, e.Y);
                canvas.AddDrawingObject(directedLine);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.directedLine != null)
                {
                    directedLine.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (this.directedLine != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    directedLine.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    directedLine.Select();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.directedLine);
                }
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
