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
        private List<DrawingObject> listSelectedObject;
        //private List<List<float>> coordinateListSelectedObject;
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
            listSelectedObject = new List<DrawingObject>();
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            this.xInitial = e.X;
            this.yInitial = e.Y;
            
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                listSelectedObject.Clear();
                canvas.DeselectAllObjects();
                
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
                if (selectedObject != null && selectedObject is Vertex)
                {
                    this.xMouseDown = e.X;
                    this.yMouseDown = e.Y;
                    listSelectedObject.Add(selectedObject);
                }
            } else if(e.Button == MouseButtons.Right && canvas != null)
            {

                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
                if (selectedObject != null && selectedObject is Vertex && !listSelectedObject.Contains(selectedObject))
                {
                    this.xMouseDown = e.X;
                    this.yMouseDown = e.Y;
                    listSelectedObject.Add(selectedObject);
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            int xAmount = e.X - xInitial;
            int yAmount = e.Y - yInitial;
            xInitial = e.X;
            yInitial = e.Y;

            if( (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && listSelectedObject.Count > 0 )
            {
                foreach (DrawingObject rectangle in listSelectedObject)
                {
                    Vertex curVertex = (Vertex)rectangle;
                    curVertex.Translate(xAmount, yAmount);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if(!((e.X - this.xMouseDown) == 0 && (e.Y -this.yMouseDown) == 0) && listSelectedObject.Count > 0)
            {
                ICommand command = new TranslateListVertex(listSelectedObject.Cast<Vertex>().ToList(), (int)(e.X - this.xMouseDown), (int)(e.Y - this.yMouseDown));
                canvas.AddCommand(command);
                listSelectedObject.Clear();
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

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            throw new NotImplementedException();
        }
    }
}
