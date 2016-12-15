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
    public partial class UndoToolItem : ToolStripButton, IToolbarItem
    {
        private ICanvas canvas;
        private ICommand command;

        public UndoToolItem(ICanvas canvas)
        {
            this.canvas = canvas;
            this.Name = "Undo tool";
            this.ToolTipText = "Undo tool";
            this.Image = IconSet.curve_arrow__1_;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.Click += UndoTool_Click;
        }

        private void UndoTool_Click(object sender, EventArgs e)
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
