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
        public string nama { get; set; }
        public List<Method> meth = new List<Method>();
        public List<Attribute> att = new List<Attribute>();

        private List<Edge> edge;

        public Vertex()
        {
            edge = new List<Edge>();
        }

        public void Broadcast()
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