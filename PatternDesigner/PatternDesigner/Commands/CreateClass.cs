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
    public class CreateClass : ICommand
    {
        private Vertex objek;
        private ICanvas canvas;


        public CreateClass(Vertex objek, ICanvas canvas)
        {
            this.objek = objek;
            this.canvas = canvas;
        }

        public void Execute()
        {
            this.canvas.AddDrawingObject(objek);
            this.canvas.AddDrawingObject(objek);
            this.canvas.AddDrawingObject(objek);
        }

        public void Unexecute()
        {
            this.canvas.RemoveDrawingObject(objek);
            this.canvas.RemoveDrawingObject(objek);
            this.canvas.RemoveDrawingObject(objek);
        }
    }
}
