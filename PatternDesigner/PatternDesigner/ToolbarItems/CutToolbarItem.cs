using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.ToolbarItems
{
    public partial class CutToolbarItem : ToolStripButton, IToolbarItem
    {
        private ICanvas canvas;
        private ICommand command;

        public CutToolbarItem(ICanvas canvas)
        {
            this.canvas = canvas;
            this.Name = "Cut tool";
            this.ToolTipText = "Cut tool";
            this.Image = IconSet.cut;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.Click += CutTool_Click;
        }

        private void CutTool_Click(object sender, EventArgs e)
        {
            if (command != null)
            {
                this.command.Execute();
            }
        }

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }
    }
}
