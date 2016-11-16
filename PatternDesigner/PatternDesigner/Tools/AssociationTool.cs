using PatternDesigner.Shapes;
using System;
using System.Windows.Forms;

namespace PatternDesigner.Tools
{
    public partial class AssociationTool : EdgeTool
    {
        public AssociationTool()
        {
            this.Name = "Association Line tool";
            this.ToolTipText = "Association Line tool";
            this.Image = IconSet.assosiation;
            this.CheckOnClick = true;
        }

        public override void MakeLine()
        {
            line = new AssociationLine(new System.Drawing.Point(StartingObject.Width + StartingObject.X, (StartingObject.Height / 2) + StartingObject.Y));
        }

        
    }
}
