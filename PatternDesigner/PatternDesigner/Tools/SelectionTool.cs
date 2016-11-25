using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PatternDesigner.Tools
{
    public class SelectionTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObject;
        private int xInitial;
        private int yInitial;
<<<<<<< HEAD
        //private ClassProperties fm;
        int count = 0;
=======
>>>>>>> b53e310cb2d00ff97e9e2cb0529d617a0990094d
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
<<<<<<< HEAD
                //Debug.WriteLine("id sesudah" + selectedObject.ID.ToString());
                incCount();
=======
                //incCount();
>>>>>>> b53e310cb2d00ff97e9e2cb0529d617a0990094d
                if (selectedObject != null)
                {
                    id_object = selectedObject.ID;
                    Debug.WriteLine("ID sebelum: " + selectedObject.ID.ToString());
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

                    selectedObject.Translate(e.X, e.Y, xAmount, yAmount);
                }
            }
        }
<<<<<<< HEAD

        
        protected void incCount()
        {
            count++;
            if (selectedObject != null)
            {
                if (id_object == selectedObject.ID)
                {

                    if (count == 2)
                    {
                        //MessageBox.Show("middle double click");
                        Debug.WriteLine("count = 2");
                        ClassProperties fm = new ClassProperties(selectedObject);
                        Debug.WriteLine("fm show");
                        fm.Show();
                    }

                    count = 0;
                }
            }
            Debug.WriteLine("COUNTNYA " + count);
        }
        
=======
>>>>>>> b53e310cb2d00ff97e9e2cb0529d617a0990094d

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {

        }

        
        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
<<<<<<< HEAD
            /*   
            fm = new ClassProperties(id_object);
            Debug.WriteLine("fm show");
            Form af = Form.ActiveForm;
            af.Enabled = false;
            fm.Show();
            */
=======
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
                        ClassProperties fm = new ClassProperties(objectTerpilih, main);
                        //main.Enabled = false;
                        Debug.WriteLine("fm show");
                        fm.Show();
                    }
                    id_object = selectedObject.ID;
                    Debug.WriteLine("ID sebelum: " + selectedObject.ID.ToString());
                }
            }

>>>>>>> b53e310cb2d00ff97e9e2cb0529d617a0990094d
        }
        
    }
}
