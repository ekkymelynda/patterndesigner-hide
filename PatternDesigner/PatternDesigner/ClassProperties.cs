using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PatternDesigner
{
    public partial class ClassProperties : Form
    {
        private TextBox textBox1;

        public ClassProperties(Guid id_object)
        {
            InitializeComponent();
           

            Text = "Class Properties";
          //  MessageBox.Show("class properti");
            TextBox txt = new TextBox();
            txt.Text = id_object.ToString();
            txt.AppendText("some text");
            Debug.WriteLine("idnya yang ke class properti" + id_object);

            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Multiline = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.AppendText("Some text");

        }

        private void DisplayTextBox()
        {
           

        }

        private void ClassProperties_Load(object sender, EventArgs e)
        {

        }

       
    }
}
