using PatternDesigner.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatternDesigner.ObjectProperties;

namespace PatternDesigner.Commands
{
    class Exit : Command
    {

        public Exit()
        {
        }

        public override void Execute()
        {
            Form main = Form.ActiveForm;
            DialogExit fm = new DialogExit(main, canvas);
            fm.ControlBox = false;
            fm.Show();
        }

        public override void Unexecute()
        {

        }
    }
}
