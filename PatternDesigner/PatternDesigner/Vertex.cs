using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner
{
    public abstract class Vertex : DrawingObject, IObservable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private List<Edge> edge;

        public Vertex()
        {
            edge = new List<Edge>();
        }

        public void Broadcast(int x, int y)
        {
            foreach(var a in edge)
            {
                a.Update();
            }
        }

        public void Subscribe(IObserver o)
        {
            edge.Add((Edge)o);
        }

        public void Unsubscribe(IObserver o)
        {
            edge.Remove((Edge)o);
        }

        

    }
}