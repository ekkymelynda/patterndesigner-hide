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
    public partial class RelationshipProperties : Form
    {
        private Edge objek;
        private Button applyButton;
        private Form main;
        private Label relationshipNameLabel, relationLabel;
        private TextBox relationshipName, relationStart, relationEnd;

        public RelationshipProperties(Edge obj, Form main1)
        {
            InitializeComponent();
            this.main = main1;
            this.objek = obj;
            this.Size = new Size(300, 200);


            relationshipNameLabel = new Label();
            relationshipNameLabel.Text = "Nama Relationship";
            relationshipNameLabel.Location = new Point(20, 33);
            relationshipNameLabel.Size = new Size(100, 20);
            this.Controls.Add(relationshipNameLabel);

            relationshipName = new TextBox();
            relationshipName.Text = this.objek.name;
            relationshipName.WordWrap = true;
            relationshipName.Location = new Point(120, 30);
            relationshipName.Size = new Size(150, 45);
            this.Controls.Add(relationshipName);

            applyButton = new Button();
            applyButton.Text = "Apply";
            applyButton.Location = new Point(190, 110);
            applyButton.Click += applyButton_Click;
            this.Controls.Add(applyButton);

            relationLabel = new Label();
            relationLabel.Text = "Jenis Relasi";
            relationLabel.Location = new Point(20, 73);
            relationLabel.Size = new Size(100, 20);
            this.Controls.Add(relationLabel);

            relationStart = new TextBox();
            relationStart.Text = this.objek.relationStart;
            relationStart.WordWrap = true;
            relationStart.Location = new Point(120, 70);
            relationStart.Size = new Size(45, 45);
            this.Controls.Add(relationStart);

            relationEnd = new TextBox();
            relationEnd.Text = this.objek.relationEnd;
            relationEnd.WordWrap = true;
            relationEnd.Location = new Point(185, 70);
            relationEnd.Size = new Size(45, 45);
            this.Controls.Add(relationEnd);

        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            objek.name = relationshipName.Text;
            objek.relationStart = relationStart.Text;
            objek.relationEnd = relationEnd.Text;
        }
    }
}
