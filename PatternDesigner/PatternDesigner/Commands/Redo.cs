using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner.Commands
{
    public class Redo : ICommand
    {
        protected ICanvas canvas;

        public Redo(ICanvas canvas)
        {
            this.canvas = canvas;
        }

        public void Execute()
        {
            if (canvas.GetRedoStack().Count > 0)
            {
                ICommand command = canvas.GetRedoStack().Pop();
                command.Execute();
                canvas.Repaint();
                canvas.GetUndoStack().Push(command);
            }
        }

        public void Unexecute()
        {

        }
    }
}
