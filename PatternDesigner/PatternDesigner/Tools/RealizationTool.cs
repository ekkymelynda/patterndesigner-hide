using PatternDesigner.Shapes;
using System;
using System.Windows.Forms;

namespace PatternDesigner.Tools
{
    public partial class RealizationTool : EdgeTool
    {
        public RealizationTool()
        {
            this.Name = "Realization Line tool";
            this.ToolTipText = "Realization Line tool";
            this.Image = IconSet.realization;
            this.CheckOnClick = true;
        }

        public override void MakeLine()
        {
            line = new RealizationLine(new System.Drawing.Point(StartingObject.Width + StartingObject.X, (StartingObject.Height / 2) + StartingObject.Y));
        }
    }
}
