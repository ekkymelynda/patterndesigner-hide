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
    public class DeleteRelationship : ICommand
    {
        private Edge edge;
        private ICanvas canvas;

        public DeleteRelationship(Edge edge, ICanvas canvas)
        {
            this.edge = edge;
            this.canvas = canvas;
        }

        public void Execute()
        {
            canvas.RemoveDrawingObject(edge);
            edge.GetStartVertex().Unsubscribe(edge);
            edge.GetEndVertex().Unsubscribe(edge);
        }

        public void Unexecute()
        {
            canvas.AddDrawingObject(edge);
            edge.GetStartVertex().Subscribe(edge);
            edge.GetEndVertex().Subscribe(edge);
        }
    }
}
