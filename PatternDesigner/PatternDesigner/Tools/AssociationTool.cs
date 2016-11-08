using PatternDesigner.Shapes;
using System;
using System.Windows.Forms;

namespace PatternDesigner.Tools
{
    public partial class AssociationTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private AssociationLine associationLine;

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
