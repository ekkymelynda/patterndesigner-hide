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
using PatternDesigner.Commands;

namespace PatternDesigner
{
    public partial class ClassProperties : Form
    {
        private TextBox txt, jenisLabel, namaLabel, tipeLabel, namaMethod, tipeMethod, visibilityMethod;
        public ICanvas canvas;
        private Vertex objek;
        private Button[] deleteButton = new Button[100];
        private Button newButton, addAtributButton, cancelButton, addMethodButton, deleteButton1, deleteMethodButton;
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
        List<Baris> listBaris = new List<Baris>();
        List<ButtonColom> Tombol = new List<ButtonColom>();

        int idxBarisMethod = 0;
        int idxCollMethod = 0;
        int idxButtonColMethod = 0;
        int xMethod = 10;
        int yMethod = 65;

        Baris barisMethod;
        List<Baris> listBarisMethod = new List<Baris>();
        List<ButtonColom> TombolMethod = new List<ButtonColom>();

        private Form main;

        public ClassProperties(ICanvas canvas, Vertex obj, Form main1)
        {
            InitializeComponent();
            this.canvas = canvas;
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
            cancelButton.Click += CancelButton_Click;
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
            kotakVisibility.kotak.ReadOnly = true;
            baris.AddKolom(kotakVisibility);

            KotakInput kotakNamaAtribut = new KotakInput(Atribut);
            kotakNamaAtribut.setNama("Nama Atribut");
            kotakNamaAtribut.setSize(300, 45);
            kotakNamaAtribut.kotak.ReadOnly = true;
            baris.AddKolom(kotakNamaAtribut);

            KotakInput kotakTipe = new KotakInput(Atribut);
            kotakTipe.setNama("Tipe");
            kotakTipe.setSize(100, 45);
            kotakTipe.kotak.ReadOnly = true;
            baris.AddKolom(kotakTipe);

            KotakInput kotakAction = new KotakInput(Atribut);
            kotakAction.setNama("Action");
            kotakAction.setSize(70, 45);
            kotakAction.kotak.ReadOnly = true;
            baris.AddKolom(kotakAction);

            baris.DrawBaris();

            addAtributButton = new Button();
            addAtributButton.Location = new Point(10, 10);
            addAtributButton.Size = new Size(100, 20);
            addAtributButton.Text = "Tambah Atribut";
            Atribut.Controls.Add(addAtributButton);
            addAtributButton.Click += AddAtributButton_Click;

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

            //method area
            Baris barisMethod = new Baris(1, Method);
            barisMethod.Init(xMethod, 45);

            KotakInput kotakMethod = new KotakInput(Method);
            kotakMethod.setSize(60, 45);
            kotakMethod.setNama("Visibility");
            barisMethod.AddKolom(kotakMethod);

            KotakInput kotakMethod2 = new KotakInput(Method);
            kotakMethod2.setSize(300, 45);
            kotakMethod2.setNama("Nama");
            barisMethod.AddKolom(kotakMethod2);

            KotakInput kotakMethod3 = new KotakInput(Method);
            kotakMethod3.setSize(100, 45);
            kotakMethod3.setNama("Tipe");
            barisMethod.AddKolom(kotakMethod3);

            barisMethod.DrawBaris();

            addMethodButton = new Button();
            addMethodButton.Location = new Point(10, 10);
            addMethodButton.Size = new Size(100, 20);
            addMethodButton.Text = "Tambah Method";
            Method.Controls.Add(addMethodButton);
            addMethodButton.Click += AddMethodButton_Click;

            deleteMethodButton = new Button();
            deleteMethodButton.Location = new Point(140, 10);
            deleteMethodButton.Size = new Size(70, 20);
            deleteMethodButton.Text = "HAPUS";
            deleteMethodButton.Click += delegate (object s, EventArgs ee)
            {
                DeleteMethodButton_Click(s, ee, idxBarisMethod - 1);
            };
            
            Method.Controls.Add(deleteMethodButton);

            foreach (Method mtd in objek.meth)
            {
                barisMethod = new Baris(idxBarisMethod, Method);
                barisMethod.Init(xMethod, yMethod);
                KotakInput kotakMethodVisi = new KotakInput(Method);
                KotakInput kotakMethodNama = new KotakInput(Method);
                KotakInput kotakMethodTipe = new KotakInput(Method);
                kotakMethodVisi.setNama(mtd.visibility);
                kotakMethodVisi.kotak.Text = mtd.visibility;
                kotakMethodVisi.setSize(60, 45);

                kotakMethodNama.setNama(mtd.nama);
                kotakMethodNama.kotak.Text = mtd.nama;
                kotakMethodNama.setSize(300, 45);

                kotakMethodTipe.setNama(mtd.tipe);
                kotakMethodTipe.kotak.Text = mtd.tipe;
                kotakMethodTipe.setSize(100, 45);

                ButtonColom deleteMethodButton = new ButtonColom(Method, "HAPUS");
                deleteMethodButton.setSize(70, 20);
                deleteMethodButton.Click += delegate (object s, EventArgs ee)
                {
                    DeleteMethodButton_Click(s, ee, idxBarisMethod - 1);
                };

                barisMethod.AddKolom(kotakMethodVisi);
                barisMethod.AddKolom(kotakMethodNama);
                barisMethod.AddKolom(kotakMethodTipe);
                barisMethod.AddKolom(deleteMethodButton);
                barisMethod.DrawBaris();

                yMethod += 20;
                listBarisMethod.Add(barisMethod);
                idxBarisMethod++;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            main.Enabled = true;
            this.Close();
        }

        private void DeleteMethodButton_Click(object sender, EventArgs e, int index)
        {

        }

        private void AddMethodButton_Click(object sender, EventArgs e)
        {
            barisMethod = new Baris(idxBarisMethod, Method);
            Debug.WriteLine("ID BARIS METHOD :" + idxBarisMethod);
            barisMethod.Init(xMethod, yMethod);

            KotakInput kotakMethodVisi = new KotakInput(Method);
            kotakMethodVisi.setSize(60, 45);
            barisMethod.AddKolom(kotakMethodVisi);

            KotakInput kotakMethodNama = new KotakInput(Method);
            kotakMethodNama.setSize(300, 45);
            barisMethod.AddKolom(kotakMethodNama);


            KotakInput kotakMethodTipe = new KotakInput(Method);
            kotakMethodTipe.setSize(100, 45);
            barisMethod.AddKolom(kotakMethodTipe);

            ButtonColom deleteMethodButton = new ButtonColom(Method, "HAPUS");
            deleteMethodButton.setSize(70, 20);
            Tombol.Add(deleteMethodButton);
            deleteMethodButton.Click += delegate (object s, EventArgs ee)
            {
                DeleteMethodButton_Click(s, ee, idxBarisMethod - 1);
            };
            barisMethod.AddKolom(deleteMethodButton);

            barisMethod.DrawBaris();
            yMethod += 20;
            listBarisMethod.Add(barisMethod);
            idxBarisMethod++;


        }

        private void Delete_Click(object sender, EventArgs e, int indexBaris)
        {
            /*
                this.listBaris.Remove(listBaris[0]);
                listBaris[0].Dispose();
                Debug.WriteLine("MASUK DELETE");
                idxBaris--; //dibuat link list
                foreach(Baris baris in listBaris)
                {
                    baris.DrawBaris();
                }
            */
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
            delete.tombol.Click += delegate (object s, EventArgs ee) { Delete_click(s, ee, idxBaris - 1); } ;
            baris.AddKolom(delete);

            baris.DrawBaris();
            yAtt += 20;
            listBaris.Add(baris);
            idxBaris++;
        }

        private void Delete_click(object sender, EventArgs e, int indexBaris)
        {
            /*
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
            ICommand command = new ApplyClassProperties(this.canvas, this.objek, txt.Text, this.objek.nama, this.objek.meth, this.objek.att, 
                               this.atributBox, this.nameAtributBox, this.typeAtributBox, 
                               this.methodBox, this.namemethodBox, this.typemethodBox, i , j);
            canvas.AddCommand(command);
            command.Execute();
            canvas.Repaint();
            main.Enabled = true;
            this.Close();
        }
    }
}
