using PatternDesigner;
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
    public class AddPattern1 : ICommand
    {
        private ICanvas canvas;
        private Pen pen;

        public AddPattern1(ICanvas canvas)
        {
            this.canvas = canvas;
        }

        public void Execute()
        {
            pen = new Pen(Color.Black);
            pen.Width = 1.5f;

            AssociationLine ls1 = new AssociationLine();
            AssociationLine ls2 = new AssociationLine();
            AssociationLine ls3 = new AssociationLine();
            AssociationLine ls4 = new AssociationLine();
            PatternDesigner.Shapes.Rectangle rc1 = new PatternDesigner.Shapes.Rectangle();
            PatternDesigner.Shapes.Rectangle rc2 = new PatternDesigner.Shapes.Rectangle();
            PatternDesigner.Shapes.Rectangle rc3 = new PatternDesigner.Shapes.Rectangle();
            PatternDesigner.Shapes.Rectangle rc4 = new PatternDesigner.Shapes.Rectangle();

            rc1.X = 10;
            rc1.Y = 10;
            rc1.Height = 100;
            rc1.Width = 100;
            rc1.pen = this.pen;
            canvas.AddDrawingObject(rc1);
            rc1.RenderOnStaticView();

            ls1.Startpoint = new Point(110,60);
            ls1.Endpoint = new Point(310,60);
            canvas.AddDrawingObject(ls1);
            ls1.RenderOnStaticView();

            rc2.X = 310;
            rc2.Y = 10;
            rc2.Height = 100;
            rc2.Width = 100;
            rc2.pen = this.pen;
            canvas.AddDrawingObject(rc2);
            rc2.RenderOnStaticView();

            ls2.Startpoint = new Point(360, 110);
            ls2.Endpoint = new Point(360, 210);
            canvas.AddDrawingObject(ls2);
            ls2.RenderOnStaticView();

            rc3.X = 310;
            rc3.Y = 210;
            rc3.Height = 100;
            rc3.Width = 100;
            rc3.pen = this.pen;
            canvas.AddDrawingObject(rc3);
            rc3.RenderOnStaticView();


            Debug.WriteLine("Add Pattern 1");
            this.canvas.Repaint();
        }
    }
}
