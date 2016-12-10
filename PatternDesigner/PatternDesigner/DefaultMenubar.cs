using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace PatternDesigner
{
    public class DefaultMenubar : MenuStrip, IMenubar, IPluginHost
    {
        public ICommand command;

        public DefaultMenubar()
        {
            this.Location = new Point(0, 0);
            this.Name = "menu";
            this.Size = new Size(624, 24);
            this.TabIndex = 0;
            this.Text = "menu";
        }

        public void AddMenuItem(IMenuItem menuItem)
        {
            this.Items.Add((ToolStripMenuItem)menuItem);
        }

        public void Register(IPlugin plugin, ICanvas canvas)
        { 
            if (plugin is ICommand)
            {
                ICommand command = (ICommand)plugin;
                this.command = command.MakeCommand(canvas);
                DefaultMenuItem Item = new DefaultMenuItem(this.command.GetCommandName());
                Item.SetCommand(this.command);
                AddMenuItem(Item);
            }
        }

    }
}
