using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner.Commands
{
    public abstract class Command : ICommand
    {
        public ICanvas canvas;

        public abstract void Execute();
        public abstract void Unexecute();

        public void removeRedoStack()
        {
            if(canvas != null)
                canvas.GetRedoStack().Clear();
        }
    }
}
