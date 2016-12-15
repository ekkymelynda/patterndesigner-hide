using PatternDesigner;
using PatternDesigner.Commands;
using PatternDesigner.Shapes;
using PatternDesigner.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner.Commands
{
    public class AddPattern1 : AddPattern
    {

        public AddPattern1(ICanvas canvas) : base(canvas)
        {
            setCanvas(canvas);
        }

        public override void Execute()
        {
            pen = new Pen(Color.Black);
            pen.Width = 1.5f;

            AddClass(10, 10, 100, 100);
            AddClass(310, 10, 100, 100);
            AddClass(310, 210, 100, 100);
            AddAssociation(110, 60, 310, 60);
            AddAssociation(310, 110, 360, 210);

            Debug.WriteLine("Add Pattern 1");
            
            this.canvas.Repaint();
            canvas.DeselectAllObjects();
        }
    }
}
