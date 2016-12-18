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
        
        private DrawingObject selectedObject;


        public Copy(ICanvas canvas)
        {
            this.canvas = canvas;
            removeRedoStack();
        }

        public override void Execute()
        {
            selectedObject = canvas.GetSelectedObject();

            if (selectedObject != null)
            {
                if (selectedObject is Vertex)
                {
                    Vertex choosenObject = (Vertex)selectedObject;

                    while(canvas.GetCopyStack().Count > 0)
                    {
                        canvas.GetCopyStack().Pop();
                    }

                    ICommand command = new CreateClassCopy(canvas);
                    canvas.AddCopyCommand(command);
                }
            }
        }

        public override void Unexecute()
        {
           
        }
    }
}
