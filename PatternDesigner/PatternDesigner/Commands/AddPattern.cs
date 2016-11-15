using PatternDesigner.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner.Commands
{
    public class AddPattern : ICommand
    {
        protected ICanvas canvas;
        protected Pen pen;

        public AddPattern(ICanvas canvas) 
        {
            this.canvas = canvas;
        }

        public void setCanvas(ICanvas canvas)
        {
            this.canvas = canvas;
        }

        public void AddObjectFromFile(string jenis, int param1, int param2, int param3, int param4)
        {
            if (jenis == "Kelas")
            {
                AddClass(param1, param2, param3, param4);
            }
            else if(jenis == "Association")
            {
                AddAssociation(param1, param2, param3, param4);
            }
            else if (jenis == "Dependency")
            {
                AddDependency(param1, param2, param3, param4);
            }
            else if (jenis == "DirectedAssociation")
            {
                AddDirectedAssociation(param1, param2, param3, param4);
            }
            else if (jenis == "Generalization")
            {
                AddGeneralization(param1, param2, param3, param4);
            }
            else if (jenis == "Realization")
            {
                AddRealization(param1, param2, param3, param4);
            }
        }

        public void AddClass(int x, int y, int width, int height)
        {
            PatternDesigner.Shapes.Rectangle rec = new PatternDesigner.Shapes.Rectangle();
            rec.X = x;
            rec.Y = y;
            rec.Height = height;
            rec.Width = width;
            rec.pen = this.pen;
            canvas.AddDrawingObject(rec);
            rec.RenderOnEditingView();
        }

        public void AddAssociation (int xStart, int yStart, int xEnd, int yEnd)
        {
            AssociationLine line = new AssociationLine();
            line.Startpoint = new Point(xStart, yStart);
            line.Endpoint = new Point(xEnd, yEnd);
            canvas.AddDrawingObject(line);
            line.RenderOnEditingView();
        }

        public void AddDependency(int xStart, int yStart, int xEnd, int yEnd)
        {
            DependencyLine line = new DependencyLine();
            line.Startpoint = new Point(xStart, yStart);
            line.Endpoint = new Point(xEnd, yEnd);
            canvas.AddDrawingObject(line);
            line.RenderOnEditingView();
        }

        public void AddDirectedAssociation(int xStart, int yStart, int xEnd, int yEnd)
        {
            DirectedAssociationLine line = new DirectedAssociationLine();
            line.Startpoint = new Point(xStart, yStart);
            line.Endpoint = new Point(xEnd, yEnd);
            canvas.AddDrawingObject(line);
            line.RenderOnEditingView();
        }

        public void AddGeneralization(int xStart, int yStart, int xEnd, int yEnd)
        {
            GeneralizationLine line = new GeneralizationLine();
            line.Startpoint = new Point(xStart, yStart);
            line.Endpoint = new Point(xEnd, yEnd);
            canvas.AddDrawingObject(line);
            line.RenderOnEditingView();
        }

        public void AddRealization(int xStart, int yStart, int xEnd, int yEnd)
        {
            RealizationLine line = new RealizationLine();
            line.Startpoint = new Point(xStart, yStart);
            line.Endpoint = new Point(xEnd, yEnd);
            canvas.AddDrawingObject(line);
            line.RenderOnEditingView();
        }

        public virtual void Execute()
        {
            
        }
    }
}
