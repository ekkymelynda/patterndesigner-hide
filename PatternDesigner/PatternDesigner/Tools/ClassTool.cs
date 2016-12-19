using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatternDesigner.Shapes;
using PatternDesigner.Commands;
using System.Diagnostics;

namespace PatternDesigner.Tools
{
    public class ClassTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Rectangle rectangle;

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

        public ClassTool()
        {
            this.Name = "ClassTool";
            this.ToolTipText = "ClassTool";
            this.Image = IconSet.bounding_box;
            CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.rectangle = new Rectangle(e.X, e.Y);
                this.canvas.AddDrawingObject(this.rectangle);
                this.canvas.AddDrawingObject(this.rectangle);
                this.canvas.AddDrawingObject(this.rectangle);
                canvas.GetListSelectedObject().Clear();
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.rectangle != null)
                {
                    int width = e.X - this.rectangle.X;
                    int height = e.Y - this.rectangle.Y;

                    if (width > 0 && height > 0)
                    {
                        this.rectangle.Width = width;
                        this.rectangle.Height = height;
                    }
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (rectangle != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ICommand command = new CreateClass(this.rectangle, canvas);
                    canvas.AddCommand(command);
                    canvas.DeselectAllObjects();
                    this.rectangle.Select();
                    canvas.SetSelectedObject(this.rectangle);
                    canvas.GetListSelectedObject().Add(this.rectangle);
                    
                }
                /*else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.rectangle);
                    canvas.RemoveDrawingObject(this.rectangle);
                    canvas.RemoveDrawingObject(this.rectangle);
                }*/
            }
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
