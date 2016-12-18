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
        public TextBox kotak;
        public String nilai = null;
        Attribute att = new Attribute();

        public KotakInput(TabPage tabParam)
        {
            tab = tabParam;
            kotak = new TextBox();
        }
        public void setNama(String nama)
        {
            this.nama = nama;
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
            kotak.Text = this.nama;
            kotak.TextAlign = HorizontalAlignment.Center;
            kotak.WordWrap = true;
            kotak.Location = new Point(posX, posY);
            kotak.Size = new Size(lebar, tinggi);
            tab.Controls.Add(kotak);
        }

        public String getNama()
        {
            return this.nama;
        }
    }
}
