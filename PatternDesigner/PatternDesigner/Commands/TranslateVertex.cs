using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner.Commands
{
    public class TranslateVertex : Command
    {
        private Vertex vertex;
        private int xAmount;
        private int yAmount;

        public TranslateVertex(Vertex vertex, int xAmount, int yAmount)
        {
            this.vertex = vertex;
            this.xAmount = xAmount;
            this.yAmount = yAmount;
            removeRedoStack();
        }

        public override void Execute()
        {
            vertex.X += xAmount;
            vertex.Y += yAmount;
            vertex.Broadcast();
        }

        public override void Unexecute()
        {
            vertex.X -= xAmount;
            vertex.Y -= yAmount;
            vertex.Broadcast();
        }
    }
}
