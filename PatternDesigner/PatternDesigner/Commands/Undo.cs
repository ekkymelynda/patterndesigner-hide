using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner.Commands
{
    public class Undo : Command
    {
        protected ICanvas canvas;

        public Undo(ICanvas canvas)
        {
            this.canvas = canvas;
            removeRedoStack();
        }

        public override void Execute()
        {
            if (canvas.GetUndoStack().Count > 0)
            {
                ICommand command = canvas.GetUndoStack().Pop();
                command.Unexecute();
                canvas.Repaint();
                canvas.GetRedoStack().Push(command);
            }
        }

        public override void Unexecute()
        {
           
        }
    }
}
