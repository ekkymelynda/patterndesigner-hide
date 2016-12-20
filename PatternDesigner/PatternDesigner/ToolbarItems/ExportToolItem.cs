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
    public partial class ExportToolItem : ToolStripButton, IToolbarItem
    {
        private ICanvas canvas;
        private ICommand command;

        public ExportToolItem(ICanvas canvas)
        {
            this.canvas = canvas;
            this.Name = "Export tool";
            this.ToolTipText = "Export tool";
            this.Image = IconSet.export;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.Click += ExportTool_Click;
        }

        private void ExportTool_Click(object sender, EventArgs e)
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
