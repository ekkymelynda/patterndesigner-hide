using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.Commands
{
    public class OpenFile : ICommand
    {
        private ICanvas canvas;
        protected string path = @"d:\export\";

        public OpenFile(ICanvas canvas)
        {
            this.canvas = canvas;
        }

        public void Execute()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = openFileDialog.FileName;
                MessageBox.Show(fileName);

                List<DrawingObject> DrawingObject = this.canvas.GetListDrawingObject();
                DrawingObject.Clear();
                List<DrawingObject> temp = new List<DrawingObject>();

                Shapes.Rectangle rectangle = new Shapes.Rectangle();
                temp = rectangle.Unserialize(fileName);

                foreach(DrawingObject obj in temp)
                {
                    DrawingObject.Add(obj);
                    DrawingObject.Add(obj);
                    DrawingObject.Add(obj);
                    this.canvas.DeselectAllObjects();
                }
                temp.Clear();

                this.canvas.Repaint();


            }
        }

        public void Unexecute()
        {
            throw new NotImplementedException();
        }
    }
}
