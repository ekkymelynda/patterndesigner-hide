using PatternDesigner.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.Commands
{
    public class Copy : Command
    {
        
        private List<DrawingObject> selectedObject;


        public Copy(ICanvas canvas)
        {
            this.canvas = canvas;
            removeRedoStack();
        }

        public override void Execute()
        {
            selectedObject = canvas.GetListSelectedObject();
            foreach(DrawingObject obj in selectedObject)
            {
                if (obj != null)
                {
                    if (obj is Vertex)
                    {
                        Vertex choosenObject = (Vertex)obj;

                        while (canvas.GetCopyStack().Count > 0)
                        {
                            canvas.GetCopyStack().Pop();
                        }

                        ICommand command = new CreateClassCopy(canvas);
                        canvas.AddCopyCommand(command);
                        //canvas.AddCommand(command);
                    }
                }
            }
        }

        public override void Unexecute()
        {
           
        }
    }
}
