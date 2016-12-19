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
            //nama = name;
            dropDown = new ComboBox();
            dropDown.SelectedIndexChanged += dynamicDDL_SelectedIndexChanged;
            dropDown.Items.Add("public");
            dropDown.Items.Add("private");
            dropDown.Items.Add("protected");
        }

        protected void dynamicDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //do something here
            string strINeedABreakPoint = string.Empty;
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
