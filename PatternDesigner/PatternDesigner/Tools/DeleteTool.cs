using PatternDesigner.ObjectProperties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.Tools
{
    class DeleteTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private List<DrawingObject> selectedObject;
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

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAllObjects();
                selectedObject.Add(canvas.SelectObjectAt(e.X, e.Y));
                if (selectedObject.First() != null)
                {
                    Form main = Form.ActiveForm;
                    //DialogDelete fm = new DialogDelete(selectedObject.Cast<Vertex>().ToList(), main, canvas);
                    //main.Enabled = false;
                    //fm.ControlBox = false;
                    //fm.Show();
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            
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
