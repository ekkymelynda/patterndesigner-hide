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
        private Button newButton, addAtributButton, cancelButton, addMethodButton, deleteButton1;
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

        int idxBaris = 0;
        int bar = 0;
        int idxColl = 0;
        int idxButtonCol = 0;
        int xAtt = 10;
        int yAtt = 65;

        Baris baris;
        List<KotakInput> kotakAttVisi = new List<KotakInput>();
        List<KotakInput> kotakAttNama = new List<KotakInput>();
        List<KotakInput> kotakAttTipe = new List<KotakInput>();
        List<Baris> listBaris = new List<Baris>();
        List<ButtonColom> Tombol = new List<ButtonColom>();

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
            newButton.Click += NewButton_Click;
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


            Baris baris = new Baris(1, Atribut);
            baris.Init(xAtt, 45);

            KotakInput kotakVisibility = new KotakInput(Atribut);
            kotakVisibility.setNama("Visibility");
            kotakVisibility.setSize(60, 45);
            baris.AddKolom(kotakVisibility);

            KotakInput kotakNamaAtribut = new KotakInput(Atribut);
            kotakNamaAtribut.setNama("Nama Atribut");
            kotakNamaAtribut.setSize(300, 45);
            baris.AddKolom(kotakNamaAtribut);

            KotakInput kotakTipe = new KotakInput(Atribut);
            kotakTipe.setNama("Tipe");
            kotakTipe.setSize(100, 45);
            baris.AddKolom(kotakTipe);

            KotakInput kotakAction = new KotakInput(Atribut);
            kotakAction.setNama("Action");
            kotakAction.setSize(70, 45);
            baris.AddKolom(kotakAction);

            baris.DrawBaris();

            addAtributButton = new Button();
            addAtributButton.Location = new Point(10, 10);
            addAtributButton.Size = new Size(100, 20);
            addAtributButton.Text = "Tambah Atribut";
            Atribut.Controls.Add(addAtributButton);
            addAtributButton.Click += AddAtributButton_Click;

            deleteButton1 = new Button();
            deleteButton1.Location = new Point(140, 10);
            deleteButton1.Size = new Size(70, 20);
            deleteButton1.Text = "HAPUS";
            deleteButton1.Click += delegate (object s, EventArgs ee) { Delete_Click(s, ee, idxBaris); };
            Atribut.Controls.Add(deleteButton1);

            foreach (Attribute atte in objek.att)
            {
                baris = new Baris(idxBaris, Atribut);
                baris.Init(xAtt, yAtt);
                KotakInput kotakAttribut = new KotakInput(Atribut);
                KotakInput kotakAttribut1 = new KotakInput(Atribut);
                KotakInput kotakAttribut2 = new KotakInput(Atribut);
                kotakAttribut.setNama(atte.visibility);
                kotakAttribut.kotak.Text = atte.visibility;
                kotakAttribut1.setNama(atte.nama);
                kotakAttribut1.kotak.Text = atte.nama;
                kotakAttribut2.setNama(atte.tipe);
                kotakAttribut2.kotak.Text = atte.tipe;
                kotakAttribut.setSize(60, 45);
                kotakAttribut1.setSize(300, 45);
                kotakAttribut2.setSize(100, 45);
                ButtonColom delete = new ButtonColom(Atribut, "HAPUS");
                delete.setSize(70, 20);
                delete.tombol.Click += delegate (object s, EventArgs ee) { Delete_Click(s, ee, idxBaris - 1); };
                baris.AddKolom(kotakAttribut);
                baris.AddKolom(kotakAttribut1);
                baris.AddKolom(kotakAttribut2);
                baris.AddKolom(delete);
                baris.DrawBaris();

                yAtt += 20;
                listBaris.Add(baris);
                idxBaris++;
            }


        }

        private void AddAtributButton_Click(object sender, EventArgs e)
        {
            baris = new Baris(idxBaris, Atribut);
            Debug.WriteLine("ID BARIS :" + idxBaris);
            baris.Init(xAtt, yAtt);

            KotakInput kotakAttribut = new KotakInput(Atribut);
            kotakAttribut.setSize(60, 45);
            baris.AddKolom(kotakAttribut);

            KotakInput kotakAttribut1 = new KotakInput(Atribut);
            kotakAttribut1.setSize(300, 45);
            baris.AddKolom(kotakAttribut1);


            KotakInput kotakAttribut2 = new KotakInput(Atribut);
            kotakAttribut2.setSize(100, 45);
            baris.AddKolom(kotakAttribut2);

            ButtonColom delete = new ButtonColom(Atribut, "HAPUS");
            delete.setSize(70, 20);
            Tombol.Add(delete);
            delete.tombol.Click += delegate (object s, EventArgs ee) { Delete_Click(s, ee, idxBaris - 1); };
            baris.AddKolom(delete);

            baris.DrawBaris();
            yAtt += 20;
            listBaris.Add(baris);
            idxBaris++;
        }

        private void Delete_Click(object sender, EventArgs e, int indexBaris)
        {/*
            this.listBaris.Remove(listBaris[0]);
            listBaris[0].Dispose();
            Debug.WriteLine("MASUK DELETE");
            idxBaris--; //dibuat link list
            foreach(Baris baris in listBaris)
            {
                baris.DrawBaris();
            }*/

        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            if (this.txt != null)
            {
                Debug.WriteLine("haloo");
                this.objek.nama = this.txt.Text;
            }
            objek.att.Clear();
            for (int a = 0; a < idxBaris; a++)
            {
                if (((KotakInput)listBaris[a].kolom[0]).kotak.Text != "" && ((KotakInput)listBaris[a].kolom[1]).kotak.Text != "" && ((KotakInput)listBaris[a].kolom[2]).kotak.Text != "")
                {
                    this.objek.att.Add(new Attribute() { visibility = ((KotakInput)listBaris[a].kolom[0]).kotak.Text, nama = ((KotakInput)listBaris[a].kolom[1]).kotak.Text, tipe = ((KotakInput)listBaris[a].kolom[2]).kotak.Text });
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
        }

    }
}
