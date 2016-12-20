using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner.Commands
{
    public class DeleteObject : Command
    {
        List<DrawingObject> listObject;

        public DeleteObject(ICanvas canvas)
        {
            this.listObject = new List<DrawingObject>();
            this.canvas = canvas;
            removeRedoStack();
        }

        public override void Execute()
        {
            this.listObject = canvas.GetListSelectedObject();
            foreach (DrawingObject obj in listObject)
            {
                if(obj is Vertex)
                {
                    Vertex vertex = (Vertex)obj;
                    this.canvas.RemoveDrawingObject(vertex);
                    this.canvas.RemoveDrawingObject(vertex);
                    this.canvas.RemoveDrawingObject(vertex);

                    foreach (Edge edge in vertex.GetEdgeList())
                    {
                        this.canvas.RemoveDrawingObject(edge);
                    }
                } else if(obj is Edge)
                {
                    Edge edge = (Edge)obj;
                    canvas.RemoveDrawingObject(edge);
                    edge.GetStartVertex().Unsubscribe(edge);
                    edge.GetEndVertex().Unsubscribe(edge);
                }
                
            }
            canvas.Repaint();
        }

        public override void Unexecute()
        {
            foreach(DrawingObject obj in listObject)
            {
                if(obj is Vertex)
                {
                    Vertex vertex = (Vertex)obj;
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
                    vertex.Deselect();
                } else if(obj is Edge)
                {
                    Edge edge = (Edge)obj;
                    canvas.AddDrawingObject(edge);
                    edge.GetStartVertex().Subscribe(edge);
                    edge.GetEndVertex().Subscribe(edge);
                    edge.Deselect();
                }
            }
        }
    }
}
