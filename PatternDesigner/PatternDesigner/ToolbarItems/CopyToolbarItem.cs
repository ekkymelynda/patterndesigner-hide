using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.ToolbarItems
{
    public partial class CopyToolbarItem : ToolStripButton, IToolbarItem
    {
        private ICanvas canvas;
        private ICommand command;

        public CopyToolbarItem(ICanvas canvas)
        {
            this.canvas = canvas;
            this.Name = "Copy tool";
            this.ToolTipText = "Copy tool";
            this.Image = IconSet.copy;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.Click += CopyTool_Click;
        }

        private void CopyTool_Click(object sender, EventArgs e)
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
