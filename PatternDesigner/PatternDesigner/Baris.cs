using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner
{
    public class Baris: Control
    {
        private List<DefaultColom> kolom = new List<DefaultColom>();
        public int index;
        private TabPage tab { set; get; }
        private int startX, startY;
        private int currX;

        public Baris(int idx, TabPage t)
        {
            index = idx;
            tab = t;
        }

        public void Init(int x, int y)
        {
            this.startX = x;
            this.startY = y;
            this.currX = x;
        }

        public void AddKolom(DefaultColom kolomDitambah)
        {
            kolomDitambah.tab = tab;
            this.kolom.Add(kolomDitambah);
        }

        public void HapusBaris(DefaultColom kolomDihapus)
        {

        }

        public void DrawBaris()
        {
            foreach (DefaultColom listKolom in kolom)
            {
                listKolom.init(currX, startY);
                listKolom.DrawColom();
                currX += listKolom.lebar;
            }
        }
    }
}
