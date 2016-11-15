using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner
{
    public abstract class Edge : DrawingObject, IObserver
    {
        public abstract void Update(IObservable o, int x, int y);
        public abstract void AddVertex(Vertex v);
    }
}
