using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner
{
    public class DefaultMenuItem : ToolStripMenuItem, IMenuItem, IPluginHost
    {
        private ICommand command;
        public ICommand commands;

        public DefaultMenuItem()
        {
            this.Name = "exampleToolStripMenuItem";
            this.Size = new System.Drawing.Size(37, 20);

            this.Click += DefaultMenuItem_Click;
        }

        private void DefaultMenuItem_Click(object sender, EventArgs e)
        {
            if (command != null)
            {
                this.command.Execute();
            }
        }

        public DefaultMenuItem(string text) : this()
        {
            this.Text = text;
        }

        public void AddMenuItem(IMenuItem menuItem)
        {
            this.DropDownItems.Add((ToolStripMenuItem)menuItem);
        }

        public void AddSeparator()
        {
            this.DropDownItems.Add(new ToolStripSeparator());
        }

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void Register(IPlugin plugin, ICanvas canvas)
        {
            if (plugin is ICommand)
            {
                ICommand command = (ICommand)plugin;
                this.commands = command.MakeCommand(canvas);
                Debug.WriteLine("Command Name: "+this.commands.GetCommandName());
                DefaultMenuItem Item = new DefaultMenuItem(this.commands.GetCommandName());
                Item.SetCommand(this.commands);
                AddMenuItem(Item);
            }    
        }
    }
}
