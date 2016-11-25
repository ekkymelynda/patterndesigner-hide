using PatternDesigner.Shapes;
using System;
using System.Windows.Forms;

namespace PatternDesigner.Tools
{
    public partial class DirectedTool : EdgeTool
    {
        public DirectedTool()
        {
            this.Name = "Directed Association Line tool";
            this.ToolTipText = "Directed Association Line tool";
            this.Image = IconSet.directed;
            this.CheckOnClick = true;
        }

        public override void MakeLine()
        {
            line = new DirectedAssociationLine(new System.Drawing.Point(StartingObject.Width + StartingObject.X, (StartingObject.Height / 2) + StartingObject.Y));
        }
    }
}
