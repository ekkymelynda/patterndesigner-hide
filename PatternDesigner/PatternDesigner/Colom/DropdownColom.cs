using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.Colom
{
    public partial class DropdownColom : DefaultColom
    {
        public ComboBox dropDown;

        public DropdownColom(TabPage tabParam)
        {
            tab = tabParam;
            dropDown = new ComboBox();
            dropDown.Items.Add("public");
            dropDown.Items.Add("private");
            dropDown.Items.Add("protected");
            String name = this.dropDown.GetItemText(this.dropDown.SelectedItem);
            nama = name;
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
            dropDown.Text = nama;
            dropDown.Location = new Point(posX, posY);
            dropDown.Size = new Size(lebar, tinggi);
            tab.Controls.Add(dropDown);
        }

    }
}
