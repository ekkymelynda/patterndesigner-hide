using PatternDesigner.Shapes;
using System;
using System.Windows.Forms;

namespace PatternDesigner.Tools
{
    public partial class DependencyTool : EdgeTool
    {
        public DependencyTool()
        {
            this.Name = "Dependency Line tool";
            this.ToolTipText = "Dependency Line tool";
            this.Image = IconSet.dependency;
            this.CheckOnClick = true;
        }

        public override void MakeLine()
        {
            line = new DependencyLine(new System.Drawing.Point(StartingObject.Width + StartingObject.X, (StartingObject.Height / 2) + StartingObject.Y));
        }
    }
}
