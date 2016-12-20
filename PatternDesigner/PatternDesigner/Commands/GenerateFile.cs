using PatternDesigner;
using PatternDesigner.Commands;
using PatternDesigner.Shapes;
using PatternDesigner.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.Commands
{
    public class GenerateFile : Command
    {

        //protected string path = @"d:\export\";
        protected string path = @"d:\export\";

        public GenerateFile(ICanvas canvas)
        {
            
            setCanvas(canvas);
            removeRedoStack();
        }

        private void setCanvas(ICanvas canvas)
        {
            this.canvas = canvas;
        }

        public override void Execute()
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    path = folderDialog.SelectedPath;
                    path += "\\";
                    Debug.WriteLine("direktory: " + path);
                }
            }

            List<DrawingObject> listDrawingObject = canvas.GetListDrawingObject();

            foreach (DrawingObject obj in listDrawingObject)
            {
                if(obj is Vertex)
                {
                    Debug.WriteLine("OBJEK VERTEX: " + obj.ID.ToString());
                    Shapes.Rectangle tempObj = new Shapes.Rectangle();
                    tempObj = (Shapes.Rectangle) obj;
                    tempObj.GenerateFile(this.path);
                }
            }
            //SuccessDialog();
        }

        private void SuccessDialog()
        {
            Form main = Form.ActiveForm;
            Form popUp = new Form();
            //main.Enabled = false;
            popUp.Text = "Class Properties";
            popUp.ControlBox = true;
            popUp.Show();
        }

        public override void Unexecute()
        {
            
        }
    }
}
