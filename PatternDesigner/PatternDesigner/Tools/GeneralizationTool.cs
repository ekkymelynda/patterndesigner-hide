using PatternDesigner.Shapes;
using System;
using System.Windows.Forms;

namespace PatternDesigner.Tools
{
    public partial class GeneralizationTool : EdgeTool
    {
        public GeneralizationTool()
        {
            this.Name = "Generalization Line tool";
            this.ToolTipText = "Generalization Line tool";
            this.Image = IconSet.general;
            this.CheckOnClick = true;
        }

        public override void MakeLine()
        {
            line = new GeneralizationLine(new System.Drawing.Point(StartingObject.Width + StartingObject.X, (StartingObject.Height / 2) + StartingObject.Y));
        }
    }
}
