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
using PatternDesigner.Commands;

namespace PatternDesigner
{
    public partial class RelationshipProperties : Form
    {
        private ICanvas canvas;
        private Edge edge;
        private Button applyButton, cancelButton;
        private Form main;
        private Label relationshipNameLabel, relationLabel;
        private TextBox relationshipName, relationStart, relationEnd;

        public RelationshipProperties(ICanvas canvas, Edge obj, Form main1)
        {
            InitializeComponent();
            this.canvas = canvas;
            this.main = main1;
            this.edge = obj;
            this.Size = new Size(300, 200);


            relationshipNameLabel = new Label();
            relationshipNameLabel.Text = "Nama Relationship";
            relationshipNameLabel.Location = new Point(20, 33);
            relationshipNameLabel.Size = new Size(100, 20);
            this.Controls.Add(relationshipNameLabel);

            relationshipName = new TextBox();
            relationshipName.Text = this.edge.name;
            relationshipName.WordWrap = true;
            relationshipName.Location = new Point(120, 30);
            relationshipName.Size = new Size(150, 45);
            this.Controls.Add(relationshipName);

            applyButton = new Button();
            applyButton.Text = "Ok";
            applyButton.Location = new Point(190, 110);
            applyButton.Click += ApplyButton_Click;
            this.Controls.Add(applyButton);

            cancelButton = new Button();
            cancelButton.Text = "Cancel";
            cancelButton.Location = new Point(100, 110);
            cancelButton.Click += CancelButton_Click;
            this.Controls.Add(cancelButton);

            relationLabel = new Label();
            relationLabel.Text = "Jenis Relasi";
            relationLabel.Location = new Point(20, 73);
            relationLabel.Size = new Size(100, 20);
            this.Controls.Add(relationLabel);

            relationStart = new TextBox();
            relationStart.Text = this.edge.relationStart;
            relationStart.WordWrap = true;
            relationStart.Location = new Point(120, 70);
            relationStart.Size = new Size(45, 45);
            this.Controls.Add(relationStart);

            relationEnd = new TextBox();
            relationEnd.Text = this.edge.relationEnd;
            relationEnd.WordWrap = true;
            relationEnd.Location = new Point(185, 70);
            relationEnd.Size = new Size(45, 45);
            this.Controls.Add(relationEnd);

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            ICommand command = new ApplyRelationshipProperties(canvas, edge, edge.name, relationshipName.Text, edge.relationStart, relationStart.Text, edge.relationEnd, relationEnd.Text);
            canvas.AddCommand(command);
            command.Execute();
            canvas.Repaint();
            main.Enabled = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            main.Enabled = true;
            this.Close();
        }
    }
}
