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
    public class DeleteClass : ICommand
    {
        private Vertex vertex;
        private ICanvas canvas;


        public DeleteClass(Vertex vertex, ICanvas canvas)
        {
            this.vertex = vertex;
            this.canvas = canvas;
        }

        public void Execute()
        {
            this.canvas.RemoveDrawingObject(vertex);
            this.canvas.RemoveDrawingObject(vertex);
            this.canvas.RemoveDrawingObject(vertex);

            foreach(Edge edge in vertex.GetEdgeList())
            {
               
                this.canvas.RemoveDrawingObject(edge);
                
            }
        }

        public void Unexecute()
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
