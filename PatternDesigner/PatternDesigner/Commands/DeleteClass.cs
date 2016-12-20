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
    public class DeleteClass : Command
    {
        //private Vertex vertex;
        private List<Vertex> vertexs;
        public DeleteClass(List<Vertex> vertexs, ICanvas canvas)
        {
            this.vertexs = vertexs;
            this.canvas = canvas;
            removeRedoStack();
        }

        public override void Execute()
        {
            foreach(Vertex vertex in vertexs)
            {
                this.canvas.RemoveDrawingObject(vertex);
                this.canvas.RemoveDrawingObject(vertex);
                this.canvas.RemoveDrawingObject(vertex);

                foreach (Edge edge in vertex.GetEdgeList())
                {

                    this.canvas.RemoveDrawingObject(edge);

                }
            }
        }

        public override void Unexecute()
        {
            foreach (Vertex vertex in vertexs)
            {
                this.canvas.AddDrawingObject(vertex);
                this.canvas.AddDrawingObject(vertex);
                this.canvas.AddDrawingObject(vertex);

                foreach (Edge edge in vertex.GetEdgeList())
                {
                    if (canvas.GetListDrawingObject().Contains(edge.GetStartVertex()) && canvas.GetListDrawingObject().Contains(edge.GetEndVertex()))
                    {
                        this.canvas.AddDrawingObject(edge);
                    }
                }
            }
            
        }
    }
}
