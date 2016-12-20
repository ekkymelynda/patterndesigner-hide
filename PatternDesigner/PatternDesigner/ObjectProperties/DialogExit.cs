using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.ObjectProperties
{
    public partial class DialogExit : Form
    {
        private Label Dialog;
        private Button Ok, Cancel;
        private Form main;
        private ICanvas canvas;

        public DialogExit(Form main1, ICanvas canvas)
        {
            this.main = main1;
            this.canvas = canvas;
            this.Size = new Size(300, 130);

            Text = "Dialog Exit";

            Dialog = new Label();
            Dialog.Text = "Are you sure you want to exit this project?";
            Dialog.Location = new Point(10, 20);
            Dialog.Size = new Size(400, 20);
            Controls.Add(Dialog);

            Cancel = new Button();
            Cancel.Location = new Point(130, 50);
            Cancel.Size = new Size(60, 30);
            Cancel.Text = "Cancel";
            Controls.Add(Cancel);

            Ok = new Button();
            Ok.Location = new Point(200, 50);
            Ok.Size = new Size(60, 30);
            Ok.Text = "Yes";
            Controls.Add(Ok);

            Ok.Click += okButton_Click;
            Cancel.Click += cancelButton_Click;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            main.Enabled = true;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
