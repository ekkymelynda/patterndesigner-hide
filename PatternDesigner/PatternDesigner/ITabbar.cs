using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner
{
    public delegate void TabSelectedEventHandler(ITab tab);

    public interface ITabbar
    {
        event TabSelectedEventHandler TabSelected;
        void AddTab(ITab tab);
        void RemoveTab(ITab tab);
        void AddSeparator();
        ITab ActiveTab { get; set; }
    }
}
