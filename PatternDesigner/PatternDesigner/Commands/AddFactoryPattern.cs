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

namespace DiagramToolkit.Commands
{
    public class AddFactoryPattern : AddPattern
    {
        public AddFactoryPattern(ICanvas canvas) : base(canvas)
        {
            setCanvas(canvas);
        }

        public override void Execute()
        {
            pen = new Pen(Color.Black);
            pen.Width = 1.5f;

            string[] lines = System.IO.File.ReadAllLines("../../PatternSource/FactoryPattern.txt");

            foreach (string line in lines)
            {
                //Debug.WriteLine("\t" + line);
                // Use a tab to indent each line of the file.
                string[] item;
                item = line.Split(' ');
                Debug.WriteLine(item[0] + " " + item[1] + " " + item[2] + " " + item[3] + " " + item[4]);
                AddObjectFromFile(item[0], Convert.ToInt32(item[1]), Convert.ToInt32(item[2]), Convert.ToInt32(item[3]), Convert.ToInt32(item[4]));
                /*
                foreach (string i in item)
                {
                    Debug.WriteLine(i.ToUpper());
                }
                */
            }

            /*
            AddClass(210, 10, 100, 100);
            AddClass(110, 160, 100, 100);
            AddClass(240, 160, 100, 100);
            AddClass(370, 160, 100, 100);
            AddClass(270, 310, 100, 100);
            AddClass(400, 310, 100, 100);
            AddGeneralization(160, 160, 260, 110);
            AddGeneralization(310, 160, 260, 110);
            AddDirectedAssociation(310, 60, 420, 160);
            AddGeneralization(320, 310, 420, 260);
            AddGeneralization(450, 310, 420, 260);
            */

            Debug.WriteLine("Add Pattern 1");
            
            this.canvas.Repaint();
            canvas.DeselectAllObjects();
        }
    }
}
