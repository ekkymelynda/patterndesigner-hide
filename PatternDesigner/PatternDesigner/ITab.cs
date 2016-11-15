using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner
{
    public interface ITab
    {
        String Name { get; set; }

        void TabMouseClick(object sender, MouseEventArgs e);
    }
}
