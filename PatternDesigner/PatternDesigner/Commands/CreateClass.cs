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
        private List<Vertex> vertexs;

        public CreateClass(List<Vertex> vertexs, ICanvas canvas)
        {
            this.vertexs = vertexs;
            this.canvas = canvas;
            removeRedoStack();
        }

        public override void Execute()
        {
            foreach(Vertex objek in vertexs)
            {
                this.canvas.AddDrawingObject(objek);
                this.canvas.AddDrawingObject(objek);
                this.canvas.AddDrawingObject(objek);
            }
        }

        public override void Unexecute()
        {
            foreach(Vertex objek in vertexs)
            {
                this.canvas.RemoveDrawingObject(objek);
                this.canvas.RemoveDrawingObject(objek);
                this.canvas.RemoveDrawingObject(objek);
            }
            
        }
    }
}
