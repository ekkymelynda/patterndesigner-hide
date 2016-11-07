using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PatternDesigner
{
    public class DefaultMenubar : MenuStrip, IMenubar
    {
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

    }
}
