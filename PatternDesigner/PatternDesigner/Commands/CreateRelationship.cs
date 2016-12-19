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
    public class CreateRelationship : Command
    {
        private Edge objek;
        private ICanvas canvas;


        public CreateRelationship(Edge objek, ICanvas canvas)
        {
            this.objek = objek;
            this.canvas = canvas;
            removeRedoStack();
        }

        public override void Execute()
        {
            this.canvas.AddDrawingObject(objek);
            objek.Update();
        }

        public override void Unexecute()
        {
            this.canvas.RemoveDrawingObject(objek);
        }
    }
}
