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
        private TextBox txt;
        private DrawingObject objek;
        private Button newButton, addAtributButton;
        private TextBox[] atributBox = new TextBox[100];
        private TextBox[] typeAtributBox = new TextBox[100];
        private int xPos, yPos, i;

        private TabControl addAtributTabControl;
        private TabPage Operation, Atribut, Method;
        private Label classNama;

        public ClassProperties(DrawingObject obj)
        {
            InitializeComponent();
            this.objek = obj;
            this.Size = new Size(600, 400);

            Text = "Class Properties";

            addAtributTabControl = new TabControl();
            addAtributTabControl.Location = new Point(10, 10);
            addAtributTabControl.Size = new Size(560, 300);
            this.Controls.Add(addAtributTabControl);

            newButton = new Button();
            newButton.Location = new Point(510, 320);
            newButton.Size = new Size(50, 20);
            newButton.Text = "OK";
            this.Controls.Add(newButton);

            addAtributButton = new Button();
            addAtributButton.Location = new Point(440, 320);
            addAtributButton.Size = new Size(50, 20);
            addAtributButton.Text = "Cancel";
            this.Controls.Add(addAtributButton);

            string operation = "TabPage " + (addAtributTabControl.TabCount + 1).ToString();
            Operation = new TabPage("Operation");
            addAtributTabControl.TabPages.Add(Operation);

            string atribut = "TabPage " + (addAtributTabControl.TabCount + 1).ToString();
            Atribut = new TabPage("Atribut");
            addAtributTabControl.TabPages.Add(Atribut);

            string method = "TabPage " + (addAtributTabControl.TabCount + 1).ToString();
            Method = new TabPage("Method");
            addAtributTabControl.TabPages.Add(Method);

            classNama = new Label();
            classNama.Text = "Nama Class";
            classNama.Location = new Point(10, 20);
            classNama.Size = new Size(70, 20);
            Operation.Controls.Add(classNama);

            txt = new TextBox();
            txt.Text = this.objek.nama;
            txt.WordWrap = true;
            txt.Location = new Point(80, 20);
            txt.Size = new Size(150, 45);
            Operation.Controls.Add(txt);          

            //addAtributButton = new Button();
            //addAtributButton.Location = new Point(10, 40);
            //addAtributButton.Size = new Size(100, 20);
            //addAtributButton.Text = "Add Method";
            //this.Controls.Add(addAtributButton);

            newButton.Click += NewButton_Click;
            //addAtributButton.Click += AddAtributButton_Click;

            /*
            objek.method.Add(new Method() { nama = "variabel", tipe = "int" });
            objek.method.Add(new Method() { nama = "variabel2", tipe = "int" });
            objek.method.Add(new Method() { nama = "variabel3", tipe = "int" });
            */
            

            i = 1;
            xPos = 10;
            yPos = 75;

            foreach (Method meth in objek.method)
            {
                Console.WriteLine(meth.nama);
                this.atributBox[i] = new TextBox();
                this.typeAtributBox[i] = new TextBox();
                this.atributBox[i].Text = meth.nama;
                this.typeAtributBox[i].Text = meth.tipe;
                this.atributBox[i].WordWrap = true;
                this.atributBox[i].Location = new Point(xPos, yPos);
                this.atributBox[i].Size = new Size(150, 45);
                this.typeAtributBox[i].Location = new Point(xPos + 160, yPos);
                this.typeAtributBox[i].Size = new Size(50, 45);
                this.Controls.Add(this.atributBox[i]);
                this.Controls.Add(this.typeAtributBox[i]);
                yPos += 25;
                i++;
            }

        }

        private void AddAtributButton_Click(object sender, EventArgs e)
        {
            this.atributBox[i] = new TextBox();
            this.typeAtributBox[i] = new TextBox();
            this.atributBox[i].WordWrap = true;
            this.atributBox[i].Location = new Point(xPos, yPos);
            this.atributBox[i].Size = new Size(150, 45);
            this.typeAtributBox[i].Location = new Point(xPos + 160, yPos);
            this.typeAtributBox[i].Size = new Size(50, 45);
            this.Controls.Add(this.atributBox[i]);
            this.Controls.Add(this.typeAtributBox[i]);
            yPos += 25;
            i++;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            if (this.txt != null)
            {
                Debug.WriteLine("haloo");
                this.objek.nama = this.txt.Text;
            }
            objek.method.Clear();
            for (int a = 1; a < i; a++)
            {
                if (this.atributBox[a].Text != "" && this.typeAtributBox[a].Text != "")
                {
                    this.objek.method.Add(new Method() { nama = this.atributBox[a].Text , tipe = this.typeAtributBox[a].Text });
                }
            }
        }

        private void DisplayTextBox()
        {
           

        }

        private void ClassProperties_Load(object sender, EventArgs e)
        {

        }

       
    }
}
