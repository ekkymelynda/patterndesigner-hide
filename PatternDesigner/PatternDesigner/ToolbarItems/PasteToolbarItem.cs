using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.ToolbarItems
{
    public partial class PasteToolbarItem : ToolStripButton, IToolbarItem
    {
        private ICanvas canvas;
        private ICommand command;

        public PasteToolbarItem(ICanvas canvas)
        {
            this.canvas = canvas;
            this.Name = "Paste tool";
            this.ToolTipText = "Paste tool";
            this.Image = IconSet.paste;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.Click += PasteTool_Click;
        }

        private void PasteTool_Click(object sender, EventArgs e)
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
