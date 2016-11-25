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
using PatternDesigner.Colom;

namespace PatternDesigner
{
    public partial class ClassProperties : Form
    {
        private TextBox txt, jenisLabel, namaLabel, tipeLabel, namaMethod, tipeMethod, visibilityMethod;
        private Vertex objek;
        private Button[] deleteButton = new Button[100];
        private Button newButton, addAtributButton, cancelButton, addMethodButton;
        private TextBox[] atributBox = new TextBox[100];
        private TextBox[] nameAtributBox = new TextBox[100];
        private TextBox[] typeAtributBox = new TextBox[100];

        private TextBox[] methodBox = new TextBox[100];
        private TextBox[] namemethodBox = new TextBox[100];
        private TextBox[] typemethodBox = new TextBox[100];
        Attribute att = new Attribute();
        Method meth = new Method();
        private int xPosAttribut, yPosAttribut, xPosMethod, yPosMethod, i, j;

        private TabControl addAtributTabControl;
        private TabPage Operation, Atribut, Method;
        private Label classNama;
        
        private Form main;

        public ClassProperties(Vertex obj, Form main1)
        {
            InitializeComponent();
            this.main = main1;
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

            cancelButton = new Button();
            cancelButton.Location = new Point(440, 320);
            cancelButton.Size = new Size(50, 20);
            cancelButton.Text = "Cancel";
            this.Controls.Add(cancelButton);

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

            Baris baris = new Baris(1, Operation);
            baris.Init(20, 100);

            KotakInput kotak = new KotakInput(Operation);
            kotak.setSize(100, 100);
            baris.AddKolom(kotak);
            KotakInput kotak2 = new KotakInput(Operation);
            kotak2.setSize(100, 100);
            baris.AddKolom(kotak2);

            baris.DrawBaris();

            //Atribut area start
            i = 1;
            xPosAttribut = 10;
            yPosAttribut = 60;


            jenisLabel = new TextBox();
            jenisLabel.Location = new Point(xPosAttribut, yPosAttribut - 20);
            jenisLabel.Size = new Size(60, 45);
            jenisLabel.Text = "Visibility";
            jenisLabel.TextAlign = HorizontalAlignment.Center;
            jenisLabel.BackColor = Color.AliceBlue;
            jenisLabel.Enabled = false;
            Atribut.Controls.Add(jenisLabel);

            namaLabel = new TextBox();
            namaLabel.Location = new Point(xPosAttribut + 60, yPosAttribut - 20);
            namaLabel.Size = new Size(300, 45);
            namaLabel.Text = "Nama Atribut";
            namaLabel.TextAlign = HorizontalAlignment.Center;
            namaLabel.BackColor = Color.AliceBlue;
            namaLabel.Enabled = false;
            Atribut.Controls.Add(namaLabel);

            tipeLabel = new TextBox();
            tipeLabel.Location = new Point(xPosAttribut + 360, yPosAttribut - 20);
            tipeLabel.Size = new Size(100, 45);
            tipeLabel.Text = "Tipe";
            tipeLabel.BackColor = Color.AliceBlue;
            tipeLabel.TextAlign = HorizontalAlignment.Center;
            tipeLabel.Enabled = false;
            Atribut.Controls.Add(tipeLabel);
            if (obj.att.Count() == 0)
            {
                this.atributBox[1] = new TextBox();
                this.nameAtributBox[1] = new TextBox();
                this.typeAtributBox[1] = new TextBox();
                this.atributBox[1].Text = att.visibility;
                this.nameAtributBox[1].Text = att.nama;
                this.typeAtributBox[1].Text = att.tipe;
                this.nameAtributBox[1].WordWrap = true;
                this.atributBox[1].Location = new Point(xPosAttribut, yPosAttribut);
                this.atributBox[1].Size = new Size(60, 45);
                this.nameAtributBox[1].Location = new Point(xPosAttribut + 60, yPosAttribut);
                this.nameAtributBox[1].Size = new Size(300, 45);
                this.typeAtributBox[1].Location = new Point(xPosAttribut + 360, yPosAttribut);
                this.typeAtributBox[1].Size = new Size(100, 45);
                deleteButton[1] = new Button();
                deleteButton[1].Location = new Point(xPosAttribut + 460, yPosAttribut);
                deleteButton[1].Size = new Size(70, 20);
                deleteButton[1].Text = "HAPUS";
                Atribut.Controls.Add(this.atributBox[1]);
                Atribut.Controls.Add(this.nameAtributBox[1]);
                Atribut.Controls.Add(this.typeAtributBox[1]);
                Atribut.Controls.Add(deleteButton[1]);
                deleteButton[i].Click += delegate (object s, EventArgs ee) { DeleteButton_Click(s, ee, i - 1); };
                yPosAttribut += 20;
                i++;
            }
            addAtributButton = new Button();
            addAtributButton.Location = new Point(10, 10);
            addAtributButton.Size = new Size(100, 20);
            addAtributButton.Text = "Tambah Atribut";
            Atribut.Controls.Add(addAtributButton);




            foreach (Attribute atte in objek.att)
            {
                Console.WriteLine(atte.nama);
                this.atributBox[i] = new TextBox();
                this.nameAtributBox[i] = new TextBox();
                this.typeAtributBox[i] = new TextBox();
                this.atributBox[i].Text = atte.visibility;
                this.nameAtributBox[i].Text = atte.nama;
                this.typeAtributBox[i].Text = atte.tipe;
                this.nameAtributBox[i].WordWrap = true;
                this.atributBox[i].Location = new Point(xPosAttribut, yPosAttribut);
                this.atributBox[i].Size = new Size(60, 45);
                this.nameAtributBox[i].Location = new Point(xPosAttribut + 60, yPosAttribut);
                this.nameAtributBox[i].Size = new Size(300, 45);
                this.typeAtributBox[i].Location = new Point(xPosAttribut + 360, yPosAttribut);
                this.typeAtributBox[i].Size = new Size(100, 45);
                deleteButton[i] = new Button();
                deleteButton[i].Location = new Point(xPosAttribut + 460, yPosAttribut);
                deleteButton[i].Size = new Size(70, 20);
                deleteButton[i].Text = "HAPUS";
                Atribut.Controls.Add(this.atributBox[i]);
                Atribut.Controls.Add(this.nameAtributBox[i]);
                Atribut.Controls.Add(this.typeAtributBox[i]);
                Atribut.Controls.Add(deleteButton[i]);
                deleteButton[i].Click += delegate (object s, EventArgs ee) { DeleteButton_Click(s, ee, i - 1); };
                yPosAttribut += 20;
                i++;
            }

            addAtributButton.Click += AddAtributButton_Click;

            //Atribut area end

            newButton.Click += NewButton_Click;


            //method area start
            j = 1;
            xPosMethod = 10;
            yPosMethod = 60;

            visibilityMethod = new TextBox();
            visibilityMethod.Location = new Point(xPosMethod, yPosMethod - 20);
            visibilityMethod.Size = new Size(60, 45);
            visibilityMethod.Text = "Visibility";
            visibilityMethod.TextAlign = HorizontalAlignment.Center;
            visibilityMethod.BackColor = Color.AliceBlue;
            visibilityMethod.Enabled = false;
            Method.Controls.Add(visibilityMethod);

            namaMethod = new TextBox();
            namaMethod.Location = new Point(xPosMethod + 60, yPosMethod - 20);
            namaMethod.Size = new Size(300, 45);
            namaMethod.Text = "Nama Mathod";
            namaMethod.TextAlign = HorizontalAlignment.Center;
            namaMethod.BackColor = Color.AliceBlue;
            namaMethod.Enabled = false;
            Method.Controls.Add(namaMethod);

            tipeMethod = new TextBox();
            tipeMethod.Location = new Point(xPosMethod + 360, yPosMethod - 20);
            tipeMethod.Size = new Size(100, 45);
            tipeMethod.Text = "Tipe";
            tipeMethod.BackColor = Color.AliceBlue;
            tipeMethod.TextAlign = HorizontalAlignment.Center;
            tipeMethod.Enabled = false;
            Method.Controls.Add(tipeMethod);

            if (obj.meth.Count == 0)
            {
                this.methodBox[1] = new TextBox();
                this.namemethodBox[1] = new TextBox();
                this.typemethodBox[1] = new TextBox();
                this.methodBox[1].Text = meth.visibility;
                this.namemethodBox[1].Text = meth.nama;
                this.typemethodBox[1].Text = meth.tipe;
                this.namemethodBox[1].WordWrap = true;
                this.methodBox[1].Location = new Point(xPosMethod, yPosMethod);
                this.methodBox[1].Size = new Size(60, 45);
                this.namemethodBox[1].Location = new Point(xPosMethod + 60, yPosMethod);
                this.namemethodBox[1].Size = new Size(300, 45);
                this.typemethodBox[1].Location = new Point(xPosMethod + 360, yPosMethod);
                this.typemethodBox[1].Size = new Size(100, 45);
                deleteButton[1] = new Button();
                deleteButton[1].Location = new Point(xPosMethod + 460, yPosMethod);
                deleteButton[1].Size = new Size(70, 20);
                deleteButton[1].Text = "HAPUS";
                Method.Controls.Add(deleteButton[1]);

                //deleteButton.Click += deleteButton_C;

                Method.Controls.Add(this.methodBox[1]);
                Method.Controls.Add(this.namemethodBox[1]);
                Method.Controls.Add(this.typemethodBox[1]);
                //Method.Controls.Add(deleteButton);
                yPosMethod += 20;
                j++;
            }

            addMethodButton = new Button();
            addMethodButton.Location = new Point(10, 10);
            addMethodButton.Size = new Size(100, 20);
            addMethodButton.Text = "Add Method";
            Method.Controls.Add(addMethodButton);

            foreach (Method met in objek.meth)
            {
                this.methodBox[j] = new TextBox();
                this.namemethodBox[j] = new TextBox();
                this.typemethodBox[j] = new TextBox();
                this.methodBox[j].Text = met.visibility;
                this.namemethodBox[j].Text = met.nama;
                this.typemethodBox[j].Text = met.tipe;
                this.namemethodBox[j].WordWrap = true;
                this.methodBox[j].Location = new Point(xPosMethod, yPosMethod);
                this.methodBox[j].Size = new Size(60, 45);
                this.namemethodBox[j].Location = new Point(xPosMethod + 60, yPosMethod);
                this.namemethodBox[j].Size = new Size(300, 45);
                this.typemethodBox[j].Location = new Point(xPosMethod + 360, yPosMethod);
                this.typemethodBox[j].Size = new Size(100, 45);
                deleteButton[j] = new Button();
                deleteButton[j].Location = new Point(xPosMethod + 460, yPosMethod);
                deleteButton[j].Size = new Size(70, 20);
                deleteButton[j].Text = "HAPUS";
                Method.Controls.Add(this.methodBox[j]);
                Method.Controls.Add(this.namemethodBox[j]);
                Method.Controls.Add(this.typemethodBox[j]);
                Method.Controls.Add(deleteButton[j]);
                yPosMethod += 20;
                j++;
            }

            addMethodButton.Click += addMethodButton_C;

            //method area end

            newButton.Click += NewButton_Click;

        }

        private void deleteButton_C(object sender, EventArgs e)
        {
            this.atributBox[j] = new TextBox();
            this.nameAtributBox[j] = new TextBox();
            this.typeAtributBox[j] = new TextBox();
            this.atributBox[j].Text = meth.visibility;
            this.nameAtributBox[j].Text = meth.nama;
            this.typeAtributBox[j].Text = meth.tipe;
            this.nameAtributBox[j].WordWrap = true;
            this.atributBox[j].Location = new Point(xPosAttribut, yPosAttribut);
            this.atributBox[j].Size = new Size(60, 45);
            this.nameAtributBox[j].Location = new Point(xPosAttribut + 60, yPosAttribut);
            this.nameAtributBox[j].Size = new Size(300, 45);
            this.typeAtributBox[j].Location = new Point(xPosAttribut + 360, yPosAttribut);
            this.typeAtributBox[j].Size = new Size(100, 45);
            deleteButton[j] = new Button();
            deleteButton[j].Location = new Point(xPosAttribut + 460, yPosAttribut);
            deleteButton[j].Size = new Size(70, 20);
            deleteButton[j].Text = "HAPUS";
            Method.Controls.Add(this.atributBox[j]);
            Method.Controls.Add(this.nameAtributBox[j]);
            Method.Controls.Add(this.typeAtributBox[j]);
            Method.Controls.Add(deleteButton[j]);
            yPosAttribut += 20;
            j++;
        }

        private void addMethodButton_C(object sender, EventArgs e)
        {
            this.methodBox[j] = new TextBox();
            this.namemethodBox[j] = new TextBox();
            this.typemethodBox[j] = new TextBox();
            this.methodBox[j].Text = meth.visibility;
            this.namemethodBox[j].Text = meth.nama;
            this.typemethodBox[j].Text = meth.tipe;
            this.namemethodBox[j].WordWrap = true;
            this.methodBox[j].Location = new Point(xPosMethod, yPosMethod);
            this.methodBox[j].Size = new Size(60, 45);
            this.namemethodBox[j].Location = new Point(xPosMethod + 60, yPosMethod);
            this.namemethodBox[j].Size = new Size(300, 45);
            this.typemethodBox[j].Location = new Point(xPosMethod + 360, yPosMethod);
            this.typemethodBox[j].Size = new Size(100, 45);
            deleteButton[j] = new Button();
            deleteButton[j].Location = new Point(xPosMethod + 460, yPosMethod);
            deleteButton[j].Size = new Size(70, 20);
            deleteButton[j].Text = "HAPUS";
            Method.Controls.Add(this.methodBox[j]);
            Method.Controls.Add(this.namemethodBox[j]);
            Method.Controls.Add(this.typemethodBox[j]);
            Method.Controls.Add(deleteButton[j]);
            yPosMethod += 20;
            j++;
        }



        private void AddAtributButton_Click(object sender, EventArgs e)
        {
            this.atributBox[i] = new TextBox();
            this.nameAtributBox[i] = new TextBox();
            this.typeAtributBox[i] = new TextBox();
            this.atributBox[i].Text = att.visibility;
            this.nameAtributBox[i].Text = att.nama;
            this.typeAtributBox[i].Text = att.tipe;
            this.nameAtributBox[i].WordWrap = true;
            this.atributBox[i].Location = new Point(xPosAttribut, yPosAttribut);
            this.atributBox[i].Size = new Size(60, 45);
            this.nameAtributBox[i].Location = new Point(xPosAttribut + 60, yPosAttribut);
            this.nameAtributBox[i].Size = new Size(300, 45);
            this.typeAtributBox[i].Location = new Point(xPosAttribut + 360, yPosAttribut);
            this.typeAtributBox[i].Size = new Size(100, 45);
            deleteButton[i] = new Button();
            deleteButton[i].Location = new Point(xPosAttribut + 460, yPosAttribut);
            deleteButton[i].Size = new Size(70, 20);
            deleteButton[i].Text = "HAPUS";
            Atribut.Controls.Add(this.atributBox[i]);
            Atribut.Controls.Add(this.nameAtributBox[i]);
            Atribut.Controls.Add(this.typeAtributBox[i]);
            Atribut.Controls.Add(deleteButton[i]);
            deleteButton[i].Click += delegate (object s, EventArgs ee) { DeleteButton_Click(s, ee, i - 1); };
            yPosAttribut += 20;
            i++;
        }

        private void DeleteButton_Click(object sender, EventArgs e, int index)
        {
            //Console.WriteLine(atributBox[index]);
            this.Controls.Remove(atributBox[index]);
            atributBox[index].Dispose();
            this.Controls.Remove(nameAtributBox[index]);
            nameAtributBox[index].Dispose();
            this.Controls.Remove(typeAtributBox[index]);
            typeAtributBox[index].Dispose();
            this.Controls.Remove(deleteButton[index]);
            deleteButton[index].Dispose();
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            if (this.txt != null)
            {
                Debug.WriteLine("haloo");
                this.objek.nama = this.txt.Text;
            }
            objek.att.Clear();
            for (int a = 1; a < i; a++)
            {
                if (this.atributBox[a].Text != "" && this.nameAtributBox[a].Text != "" && this.typeAtributBox[a].Text != "")
                {
                    this.objek.att.Add(new Attribute() { visibility = this.atributBox[a].Text, nama = this.nameAtributBox[a].Text, tipe = this.typeAtributBox[a].Text });
                }
            }

            objek.meth.Clear();

            for (int b = 1; b < j; b++)
            {
                if (this.methodBox[b].Text != "" && this.namemethodBox[b].Text != "" && this.typemethodBox[b].Text != "")
                {
                    this.objek.meth.Add(new Method() { visibility = this.methodBox[b].Text, nama = this.namemethodBox[b].Text, tipe = this.typemethodBox[b].Text });
                }
            }

            /*
            Form classForm = Form.ActiveForm;
            classForm.Close();
            main.Enabled = true;
            */
        }




    }
}
