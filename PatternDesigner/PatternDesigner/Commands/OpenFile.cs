using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.Commands
{
    public class OpenFile : ICommand
    {
        private ICanvas canvas;
        protected string path = @"d:\export\";

        public OpenFile(ICanvas canvas)
        {
            this.canvas = canvas;
        }

        public void Execute()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = openFileDialog.FileName;
                MessageBox.Show(fileName);

                List<DrawingObject> DrawingObject = this.canvas.GetListDrawingObject();
                DrawingObject.Clear();
                List<DrawingObject> temp = new List<DrawingObject>();

                Shapes.Rectangle rectangle = new Shapes.Rectangle();
                temp = rectangle.Unserialize(fileName);

                foreach(DrawingObject obj in temp)
                {
                    DrawingObject.Add(obj);
                    DrawingObject.Add(obj);
                    DrawingObject.Add(obj);
                }
                temp.Clear();

                List<DrawingObject>temp2 = new List<DrawingObject>();
                Shapes.AssociationLine line = new Shapes.AssociationLine();
                temp2 = line.Unserialize(fileName);
                if(temp2.Count > 0)
                {
                    foreach (Edge obj in temp2)
                    {
                        Shapes.AssociationLine drawLine = new Shapes.AssociationLine(obj.Startpoint, obj.Endpoint);
                        drawLine.ID = obj.ID;
                        drawLine.relationStart = obj.relationStart;
                        drawLine.relationEnd = obj.relationEnd;
                        foreach (DrawingObject obj2 in DrawingObject)
                        {
                            Vertex obj3;
                            if (obj2.ID.ToString().Equals(obj.idStartVertex))
                            {
                                obj3 = (Vertex)obj2;
                                drawLine.AddVertex(obj3);
                                obj3.Subscribe(drawLine);
                            }
                        }
                        foreach (DrawingObject obj2 in DrawingObject)
                        {
                            Vertex obj3;
                            if (obj2.ID.ToString().Equals(obj.idEndVertex))
                            {
                                obj3 = (Vertex)obj2;
                                drawLine.AddVertex(obj3);
                                obj3.Subscribe(drawLine);
                            }
                        }
                        temp.Clear();
                        DrawingObject.Add(drawLine);
                    }
                }

                List<DrawingObject> temp3 = new List<DrawingObject>();
                Shapes.DependencyLine line1 = new Shapes.DependencyLine();
                temp3 = line1.Unserialize(fileName);
                if (temp3.Count > 0)
                {
                    foreach (Edge obj in temp3)
                    {
                        Shapes.DependencyLine drawLine = new Shapes.DependencyLine(obj.Startpoint, obj.Endpoint);
                        drawLine.ID = obj.ID;
                        drawLine.relationStart = obj.relationStart;
                        drawLine.relationEnd = obj.relationEnd;
                        foreach (DrawingObject obj2 in DrawingObject)
                        {
                            Vertex obj3;
                            if (obj2.ID.ToString().Equals(obj.idStartVertex))
                            {
                                obj3 = (Vertex)obj2;
                                drawLine.AddVertex(obj3);
                                obj3.Subscribe(drawLine);
                            }
                        }
                        foreach (DrawingObject obj2 in DrawingObject)
                        {
                            Vertex obj3;
                            if (obj2.ID.ToString().Equals(obj.idEndVertex))
                            {
                                obj3 = (Vertex)obj2;
                                drawLine.AddVertex(obj3);
                                obj3.Subscribe(drawLine);
                            }
                        }
                        temp.Clear();
                        DrawingObject.Add(drawLine);
                    }
                }

                List<DrawingObject> temp4 = new List<DrawingObject>();
                Shapes.DirectedAssociationLine line2 = new Shapes.DirectedAssociationLine();
                temp4 = line2.Unserialize(fileName);
                if (temp4.Count > 0)
                {
                    foreach (Edge obj in temp4)
                    {
                        Shapes.DirectedAssociationLine drawLine = new Shapes.DirectedAssociationLine(obj.Startpoint, obj.Endpoint);
                        drawLine.ID = obj.ID;
                        drawLine.relationStart = obj.relationStart;
                        drawLine.relationEnd = obj.relationEnd;
                        foreach (DrawingObject obj2 in DrawingObject)
                        {
                            Vertex obj3;
                            if (obj2.ID.ToString().Equals(obj.idStartVertex))
                            {
                                obj3 = (Vertex)obj2;
                                drawLine.AddVertex(obj3);
                                obj3.Subscribe(drawLine);
                            }
                        }
                        foreach (DrawingObject obj2 in DrawingObject)
                        {
                            Vertex obj3;
                            if (obj2.ID.ToString().Equals(obj.idEndVertex))
                            {
                                obj3 = (Vertex)obj2;
                                drawLine.AddVertex(obj3);
                                obj3.Subscribe(drawLine);
                            }
                        }
                        temp.Clear();
                        DrawingObject.Add(drawLine);
                    }
                }

                List<DrawingObject> temp5 = new List<DrawingObject>();
                Shapes.RealizationLine line3 = new Shapes.RealizationLine();
                temp5 = line3.Unserialize(fileName);
                if (temp5.Count > 0)
                {
                    foreach (Edge obj in temp5)
                    {
                        Shapes.RealizationLine drawLine = new Shapes.RealizationLine(obj.Startpoint, obj.Endpoint);
                        drawLine.ID = obj.ID;
                        drawLine.relationStart = obj.relationStart;
                        drawLine.relationEnd = obj.relationEnd;
                        foreach (DrawingObject obj2 in DrawingObject)
                        {
                            Vertex obj3;
                            if (obj2.ID.ToString().Equals(obj.idStartVertex))
                            {
                                obj3 = (Vertex)obj2;
                                drawLine.AddVertex(obj3);
                                obj3.Subscribe(drawLine);
                            }
                        }
                        foreach (DrawingObject obj2 in DrawingObject)
                        {
                            Vertex obj3;
                            if (obj2.ID.ToString().Equals(obj.idEndVertex))
                            {
                                obj3 = (Vertex)obj2;
                                drawLine.AddVertex(obj3);
                                obj3.Subscribe(drawLine);
                            }
                        }
                        temp.Clear();
                        DrawingObject.Add(drawLine);
                    }
                }

                List<DrawingObject> temp6 = new List<DrawingObject>();
                Shapes.GeneralizationLine line4 = new Shapes.GeneralizationLine();
                temp6 = line4.Unserialize(fileName);
                if (temp6.Count > 0)
                {
                    foreach (Edge obj in temp6)
                    {
                        Shapes.GeneralizationLine drawLine = new Shapes.GeneralizationLine(obj.Startpoint, obj.Endpoint);
                        drawLine.ID = obj.ID;
                        drawLine.relationStart = obj.relationStart;
                        drawLine.relationEnd = obj.relationEnd;
                        foreach (DrawingObject obj2 in DrawingObject)
                        {
                            Vertex obj3;
                            if (obj2.ID.ToString().Equals(obj.idStartVertex))
                            {
                                obj3 = (Vertex)obj2;
                                drawLine.AddVertex(obj3);
                                obj3.Subscribe(drawLine);
                            }
                        }
                        foreach (DrawingObject obj2 in DrawingObject)
                        {
                            Vertex obj3;
                            if (obj2.ID.ToString().Equals(obj.idEndVertex))
                            {
                                obj3 = (Vertex)obj2;
                                drawLine.AddVertex(obj3);
                                obj3.Subscribe(drawLine);
                            }
                        }
                        temp.Clear();
                        DrawingObject.Add(drawLine);
                    }
                }

                this.canvas.DeselectAllObjects();
                this.canvas.Repaint();

            }
        }

        public void Unexecute()
        {
            throw new NotImplementedException();
        }
    }
}
