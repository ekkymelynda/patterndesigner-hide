using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.Colom
{
    public partial class ButtonColom : DefaultColom
    {
        public Button tombol;

        public ButtonColom(TabPage tabParam, String name)
        {
            tab = tabParam;
            nama = name;
            tombol = new Button();
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
            tombol.Text = nama;
            tombol.Location = new Point(posX, posY);
            tombol.Size = new Size(lebar, tinggi);
            tab.Controls.Add(tombol);
        }
    }
}
