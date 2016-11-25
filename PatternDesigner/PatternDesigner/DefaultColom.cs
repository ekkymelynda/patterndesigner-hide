using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner
{
    public abstract class DefaultColom : Control
    {
        public int index;
        public int posX, posY, tinggi, lebar;
        public TabPage tab { set; get; }

        public abstract void DrawColom();
        public abstract void init(int lokasiX, int lokasiY);
        public abstract void setSize(int ukuranLebar, int ukuranTinggi);
    }
}
