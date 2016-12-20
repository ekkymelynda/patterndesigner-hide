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
using System.Windows.Forms;

namespace PatternDesigner.CommandPattern
{
    public class CommandPattern : ICommand, IPlugin
    {

        public ICanvas canvas;
        public Pen pen;
        public string Name;

        public IPluginHost Host
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CommandPattern()
        {
            this.Name = "Command Pattern";
        }

        public CommandPattern(ICanvas canvas): this()
        {
            this.canvas = canvas;
        }

        public void Execute()
        {
            pen = new Pen(Color.Black);
            pen.Width = 1.5f;

            string[] lines = System.IO.File.ReadAllLines(Application.StartupPath + "\\Plugin\\CommandPattern.txt");

            foreach (string line in lines)
            {
                string[] item;
                item = line.Split(' ');
                Debug.WriteLine(item[0] + " " + item[1] + " " + item[2] + " " + item[3] + " " + item[4]);
                AddObjectFromFile(item[0], Convert.ToInt32(item[1]), Convert.ToInt32(item[2]), Convert.ToInt32(item[3]), Convert.ToInt32(item[4]));
                
            }
            
            this.canvas.Repaint();
            canvas.DeselectAllObjects();
        }

        public ICommand MakeCommand(ICanvas canvas)
        {
            return new CommandPattern(canvas);
        }

        public string GetCommandName()
        {
            return this.Name;
        }

        public void Unexecute()
        {
            throw new NotImplementedException();
        }

        public void AddObjectFromFile(string jenis, int param1, int param2, int param3, int param4)
        {
            if (jenis == "Kelas")
            {
                AddClass(param1, param2, param3, param4);
            }
            else if (jenis == "Association")
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

        public void AddAssociation(int xStart, int yStart, int xEnd, int yEnd)
        {
            AssociationTool lineTools = new AssociationTool();
            lineTools.StartingObject = (Vertex)canvas.GetObjectAt(xStart, yStart);
            lineTools.MakeLine();
            lineTools.line.Endpoint = new Point(xEnd, yEnd);
            canvas.AddDrawingObject(lineTools.line);

            lineTools.EndingObject = (Vertex)canvas.GetObjectAt(xEnd, yEnd);
            lineTools.line.Endpoint = new System.Drawing.Point(lineTools.EndingObject.X, (lineTools.EndingObject.Height / 2) + lineTools.EndingObject.Y);
            lineTools.line.Select();

            lineTools.StartingObject.Subscribe(lineTools.line);
            lineTools.line.AddVertex(lineTools.StartingObject);

            lineTools.EndingObject.Subscribe(lineTools.line);
            lineTools.line.AddVertex(lineTools.EndingObject);
        }

        public void AddDependency(int xStart, int yStart, int xEnd, int yEnd)
        {
            DependencyTool lineTools = new DependencyTool();
            lineTools.StartingObject = (Vertex)canvas.GetObjectAt(xStart, yStart);
            lineTools.MakeLine();
            lineTools.line.Endpoint = new Point(xEnd, yEnd);
            canvas.AddDrawingObject(lineTools.line);

            lineTools.EndingObject = (Vertex)canvas.GetObjectAt(xEnd, yEnd);
            lineTools.line.Endpoint = new Point(lineTools.EndingObject.X, (lineTools.EndingObject.Height / 2) + lineTools.EndingObject.Y);
            lineTools.line.Select();

            lineTools.StartingObject.Subscribe(lineTools.line);
            lineTools.line.AddVertex(lineTools.StartingObject);

            lineTools.EndingObject.Subscribe(lineTools.line);
            lineTools.line.AddVertex(lineTools.EndingObject);
        }

        public void AddDirectedAssociation(int xStart, int yStart, int xEnd, int yEnd)
        {
            DirectedTool directTools = new DirectedTool();
            directTools.StartingObject = (Vertex)canvas.GetObjectAt(xStart, yStart);
            directTools.MakeLine();
            directTools.line.Endpoint = new Point(xEnd, yEnd);
            canvas.AddDrawingObject(directTools.line);

            directTools.EndingObject = (Vertex)canvas.GetObjectAt(xEnd, yEnd);
            directTools.line.Endpoint = new System.Drawing.Point(directTools.EndingObject.X, (directTools.EndingObject.Height / 2) + directTools.EndingObject.Y);
            directTools.line.Select();

            directTools.StartingObject.Subscribe(directTools.line);
            directTools.line.AddVertex(directTools.StartingObject);

            directTools.EndingObject.Subscribe(directTools.line);
            directTools.line.AddVertex(directTools.EndingObject);

        }

        public void AddGeneralization(int xStart, int yStart, int xEnd, int yEnd)
        {
            GeneralizationTool directTools = new GeneralizationTool();
            directTools.StartingObject = (Vertex)canvas.GetObjectAt(xStart, yStart);
            directTools.MakeLine();
            directTools.line.Endpoint = new Point(xEnd, yEnd);
            canvas.AddDrawingObject(directTools.line);

            directTools.EndingObject = (Vertex)canvas.GetObjectAt(xEnd, yEnd);
            directTools.line.Endpoint = new System.Drawing.Point(directTools.EndingObject.X, (directTools.EndingObject.Height / 2) + directTools.EndingObject.Y);
            directTools.line.Select();

            directTools.StartingObject.Subscribe(directTools.line);
            directTools.line.AddVertex(directTools.StartingObject);

            directTools.EndingObject.Subscribe(directTools.line);
            directTools.line.AddVertex(directTools.EndingObject);
        }

        public void AddRealization(int xStart, int yStart, int xEnd, int yEnd)
        {
            RealizationTool directTools = new RealizationTool();
            directTools.StartingObject = (Vertex)canvas.GetObjectAt(xStart, yStart);
            directTools.MakeLine();
            directTools.line.Endpoint = new Point(xEnd, yEnd);
            canvas.AddDrawingObject(directTools.line);

            directTools.EndingObject = (Vertex)canvas.GetObjectAt(xEnd, yEnd);
            directTools.line.Endpoint = new Point(directTools.EndingObject.X, (directTools.EndingObject.Height / 2) + directTools.EndingObject.Y);
            directTools.line.Select();

            directTools.StartingObject.Subscribe(directTools.line);
            directTools.line.AddVertex(directTools.StartingObject);

            directTools.EndingObject.Subscribe(directTools.line);
            directTools.line.AddVertex(directTools.EndingObject);
        }
    }
}
