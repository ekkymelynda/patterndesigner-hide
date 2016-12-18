using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PatternDesigner.ToolbarItems
{
    public partial class RedoToolItem : ToolStripButton, IToolbarItem
    {
        private ICanvas canvas;
        private ICommand command;

        public RedoToolItem(ICanvas canvas)
        {
            this.canvas = canvas;
            this.Name = "Redo tool";
            this.ToolTipText = "Redo tool";
            this.Image = IconSet.curve_arrow;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.Click += RedoTool_Click;
        }

        private void RedoTool_Click(object sender, EventArgs e)
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
