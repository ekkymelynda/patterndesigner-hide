using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using PatternDesigner.Commands;

namespace PatternDesigner.Tools
{
    public class SelectionTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObject;
        private int xInitial;
        private int yInitial;
        private int xMouseDown;
        private int yMouseDown;
        Guid id_object;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public SelectionTool()
        {
            this.Name = "Selection tool";
            this.ToolTipText = "Selection tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            this.xInitial = e.X;
            this.yInitial = e.Y;

            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAllObjects();
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
                if (selectedObject != null)
                {
                    if(selectedObject is Vertex)
                    {
                        this.xMouseDown = e.X;
                        this.yMouseDown = e.Y;
                    }
                    
                    id_object = selectedObject.ID;
                }
            }

        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                if (selectedObject != null)
                {
                    int xAmount = e.X - xInitial;
                    int yAmount = e.Y - yInitial;
                    xInitial = e.X;
                    yInitial = e.Y;

                    selectedObject.Translate(xAmount, yAmount);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (selectedObject is Vertex)
            {
                if (!((int)e.X - (int)this.xMouseDown == 0 && (int)e.Y - (int)this.yMouseDown == 0))
                {
                    ICommand command = new TranslateVertex((Vertex)selectedObject, (int)(e.X - this.xMouseDown), (int)(e.Y - this.yMouseDown));
                    canvas.AddCommand(command);
                }
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.xInitial = e.X;
            this.yInitial = e.Y;

            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAllObjects();
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);

                if (selectedObject != null)
                {
                    if (selectedObject is Vertex)
                    {
                        Vertex objectTerpilih = (Vertex)selectedObject;
                        Form main = Form.ActiveForm;
                        ClassProperties fm = new ClassProperties(canvas, objectTerpilih, main);
                        main.Enabled = false;
                        fm.Text = "Class Properties";
                        fm.ControlBox = false;
                        fm.Show();
                    }

                    else if (selectedObject is Edge)
                    {
                        Edge objectTerpilih = (Edge)selectedObject;
                        Form main = Form.ActiveForm;
                        RelationshipProperties fm = new RelationshipProperties(canvas, objectTerpilih, main);
                        main.Enabled = false;
                        fm.Text = "Relationship Properties";
                        fm.ControlBox = false;
                        fm.Show();
                    }
                    id_object = selectedObject.ID;
                }
            }

        }
    }
}
