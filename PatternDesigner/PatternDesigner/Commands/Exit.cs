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
    class Exit : Command
    {

        public Exit()
        {
        }

        public override void Execute()
        {
            Application.Exit();
        }

        public override void Unexecute()
        {

        }
    }
}
