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
    public class Paste : ICommand
    {
        private ICanvas canvas;


        public Paste(ICanvas canvas)
        {
            this.canvas = canvas;
        }

        public void Execute()
        {
            if (canvas.GetCopyStack().Count > 0)
            {
                ICommand command = canvas.GetCopyStack().Peek();
                command.Execute();
                canvas.Repaint();
            }
        }

        public void Unexecute()
        {
           
        }
    }
}
