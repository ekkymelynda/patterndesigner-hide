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
    public partial class SaveToolbarItem : ToolStripButton, IToolbarItem
    {
        private ICanvas canvas;
        private ICommand command;

        public SaveToolbarItem(ICanvas canvas)
        {
            this.canvas = canvas;
            this.Name = "Save tool";
            this.ToolTipText = "Save tool";
            this.Image = IconSet.save_icon_silhouette;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.Click += SaveTool_Click;
        }

        private void SaveTool_Click(object sender, EventArgs e)
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
