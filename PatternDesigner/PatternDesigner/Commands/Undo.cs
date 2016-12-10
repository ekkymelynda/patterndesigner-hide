using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner.Commands
{
    public class Undo : ICommand
    {
        protected ICanvas canvas;

        public Undo(ICanvas canvas)
        {
            this.canvas = canvas;
        }

        public void Execute()
        {
            if (canvas.GetUndoStack().Count > 0)
            {
                ICommand command = canvas.GetUndoStack().Pop();
                command.Unexecute();
                canvas.Repaint();
                canvas.GetRedoStack().Push(command);
            }
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
           
        }
    }
}
