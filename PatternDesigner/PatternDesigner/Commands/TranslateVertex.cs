using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner.Commands
{
    public class TranslateVertex : ICommand
    {
        private Vertex vertex;
        private int xAmount;
        private int yAmount;

        public TranslateVertex(Vertex vertex, int xAmount, int yAmount)
        {
            this.vertex = vertex;
            this.xAmount = xAmount;
            this.yAmount = yAmount;
        }

        public void Execute()
        {
            vertex.X += xAmount;
            vertex.Y += yAmount;
            vertex.Broadcast();
        }

        public string GetCommandName()
        {
            throw new NotImplementedException();
        }

        public ICommand MakeCommand(ICanvas canvas)
        {
            throw new NotImplementedException();
        }

        public void Unexecute()
        {
            vertex.X -= xAmount;
            vertex.Y -= yAmount;
            vertex.Broadcast();
        }
    }
}
