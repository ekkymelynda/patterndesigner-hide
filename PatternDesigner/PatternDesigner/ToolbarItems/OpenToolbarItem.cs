using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.ToolbarItems
{
    public partial class OpenToolbarItem : ToolStripButton, IToolbarItem
    {
        private ICanvas canvas;
        private ICommand command;

        public OpenToolbarItem(ICanvas canvas)
        {
            this.canvas = canvas;
            this.Name = "Open tool";
            this.ToolTipText = "Open tool";
            this.Image = IconSet.open;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.Click += OpenTool_Click;
        }

        private void OpenTool_Click(object sender, EventArgs e)
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
