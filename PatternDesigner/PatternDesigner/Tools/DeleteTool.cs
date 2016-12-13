using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.Tools
{
    class DeleteTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObject;
        Guid id_object;
        private int xInitial;
        private int yInitial;

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

        public DeleteTool()
        {
            this.Name = "Delete tool";
            this.ToolTipText = "Delete tool";
            this.Image = IconSet.multiply;
            this.CheckOnClick = true;
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            this.xInitial = e.X;
            this.yInitial = e.Y;

            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAllObjects();
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
                //incCount();
                if (selectedObject != null)
                {
                    if (selectedObject is Vertex)
                    {
                        Vertex objectTerpilih = (Vertex)selectedObject;
                        Form main = Form.ActiveForm;
                        DialogDelete fm = new DialogDelete(objectTerpilih, main, canvas);
                        //main.Enabled = false;
                        Debug.WriteLine("fm show");
                        fm.Show();
                    } else if (selectedObject is Edge)
                    {
                        Edge objectTerpilih = (Edge)selectedObject;
                        Form main = Form.ActiveForm;
                        DialogDelete fm = new DialogDelete(objectTerpilih, main, canvas);
                        //main.Enabled = false;
                        Debug.WriteLine("fm show");
                        fm.Show();
                    }
                    id_object = selectedObject.ID;
                    Debug.WriteLine("ID sebelum: " + selectedObject.ID.ToString());
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}
