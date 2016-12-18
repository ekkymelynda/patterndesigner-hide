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
    public class CreateClass : Command
    {
        private Vertex objek;

        public CreateClass(Vertex objek, ICanvas canvas)
        {
            this.objek = objek;
            this.canvas = canvas;
            removeRedoStack();
        }

        public override void Execute()
        {
            this.canvas.AddDrawingObject(objek);
            this.canvas.AddDrawingObject(objek);
            this.canvas.AddDrawingObject(objek);
        }

        public override void Unexecute()
        {
            this.canvas.RemoveDrawingObject(objek);
            this.canvas.RemoveDrawingObject(objek);
            this.canvas.RemoveDrawingObject(objek);
        }
    }
}
