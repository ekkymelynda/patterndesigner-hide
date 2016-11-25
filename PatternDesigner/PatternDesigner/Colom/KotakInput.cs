using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.Colom
{
    class KotakInput : DefaultColom
    {
        private TextBox kotak;
        public String nilai = null; 

        public KotakInput(TabPage tabParam)
        {
            tab = tabParam;
        }

        public override void init(int lokasiX, int lokasiY)
        {
            posX = lokasiX;
            posY = lokasiY;
        }

        public override void setSize(int ukuranLebar, int ukuranTinggi)
        {
            lebar = ukuranLebar;
            tinggi = ukuranTinggi;
        }

        public override void DrawColom()
        {
            kotak = new TextBox();
            //kotak.Text = this.objek.nama;
            kotak.WordWrap = true;
            kotak.Location = new Point(posX, posY);
            kotak.Size = new Size(lebar, tinggi);
            tab.Controls.Add(kotak);
        }
    }
}
