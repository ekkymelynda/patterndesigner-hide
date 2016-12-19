using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner.Commands
{
    class TranslateListVertex : Command
    {
        private List<Vertex> vertexs;
        private int xAmount;
        private int yAmount;

        public TranslateListVertex(List<Vertex> vertexs, int xAmount, int yAmount)
        {
            this.vertexs = vertexs;
            this.xAmount = xAmount;
            this.yAmount = yAmount;
            removeRedoStack();
        }

        public override void Execute()
        {
            foreach(Vertex vertex in vertexs)
            {
                vertex.X += xAmount;
                vertex.Y += yAmount;
                vertex.Broadcast();
            }
        }

        public override void Unexecute()
        {
            foreach(Vertex vertex in vertexs)
            {
                vertex.X -= xAmount;
                vertex.Y -= yAmount;
                vertex.Broadcast();
            }
        }
    }
}
