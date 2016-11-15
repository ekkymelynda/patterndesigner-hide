using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner
{
    public abstract class Edge : DrawingObject, IObserver
    {
        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        public abstract void Update();
        public abstract void AddVertex(Vertex v);
    }
}
