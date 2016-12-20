using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Xml.Linq;

namespace PatternDesigner.Shapes
{
    class DirectedAssociationLine : Edge, IPersistance
    {
        public DirectedAssociationLine()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 2.0f;
        }

        public DirectedAssociationLine(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public DirectedAssociationLine(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.Endpoint = endpoint;
        }

        public override void RenderOnStaticView()
        {
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5, false);
            pen.Color = Color.Black;
            pen.Width = 2.0f;
            pen.DashStyle = DashStyle.Solid;
            pen.CustomEndCap = bigArrow;


            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
                DrawName();
            }
        }

        public override void RenderOnEditingView()
        {
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5, false);
            pen.Color = Color.Blue;
            pen.Width = 2.0f;
            pen.DashStyle = DashStyle.Solid;
            pen.CustomEndCap = bigArrow;

            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
                DrawName();
            }
        }

        public override void RenderOnPreview()
        {
            pen.Color = Color.Red;
            pen.Width = 2.0f;
            pen.DashStyle = DashStyle.DashDotDot;
            pen.EndCap = LineCap.ArrowAnchor;

            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
                //DrawName();
            }
        }

        public void Serialize(string path)
        {

            XDocument doc = XDocument.Load(path);
            XElement file = doc.Root;
            Console.WriteLine(file);

            if (doc.Root.LastNode != null)
            {
                file = (XElement)doc.LastNode;
            }

            file.Add(new XElement("relation",
                new XAttribute("id", this.ID.ToString()),
                new XAttribute("StartPointX", this.GetStartPointX()),
                new XAttribute("StartPointY", this.GetStartPointY()),
                new XAttribute("EndPointX", this.GetEndPointX()),
                new XAttribute("EndPointY", this.GetEndPointY()),
                new XAttribute("StartVertex", this.GetStartVertex().ID.ToString()),
                new XAttribute("EndVertex", this.GetEndVertex().ID.ToString()),
                new XAttribute("tipe", "Directed Association")));

            file = (XElement)file.LastNode;

            file.Add(new XElement("nama", this.name));
            file.Add(new XElement("jenisRelasiAsal", this.relationStart));
            file.Add(new XElement("jenisRelasiTujuan", this.relationEnd));

            doc.Save(path);
        }

        public List<DrawingObject> Unserialize(string path)
        {
            List<DrawingObject> DrawingObject = new List<DrawingObject>();

            Edge line = null;
            string startVertex = null, endVertex = null;
            int StartPointX = 0, StartPointY = 0, EndPointX = 0, EndPointY = 0;
            string id = null;
            string tipe = null, nama = null, jenisRelasiAsal = null, jenisRelasiTujuan = null;

            XmlTextReader reader = new XmlTextReader(path);
            reader.MoveToContent();

            try
            {
                if (reader.Name.Equals("diagram"))
                {
                    while (reader.Read())
                    {
                        if (reader.Name.Equals("relation"))
                        {
                            Boolean flag = true;

                            reader.MoveToFirstAttribute();
                            id = reader.Value;
                            reader.MoveToNextAttribute();
                            StartPointX = Int32.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            StartPointY = Int32.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            EndPointX = Int32.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            EndPointY = Int32.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            startVertex = reader.Value;
                            reader.MoveToNextAttribute();
                            endVertex = reader.Value;
                            reader.MoveToNextAttribute();
                            tipe = reader.Value;
                            reader.MoveToElement();

                            while (reader.Read() && flag)
                            {
                                reader.MoveToContent();
                                flag = true;
                                if (reader.Name.Equals("nama"))
                                {
                                    nama = reader.Value;
                                }
                                else if (reader.Name.Equals("jenisRelasiAsal"))
                                {
                                    jenisRelasiAsal = reader.Value;
                                }
                                else if (reader.Name.Equals("jenisRelasiTujuan"))
                                {
                                    jenisRelasiTujuan = reader.Value;
                                }
                                else if (reader.Name.Equals("relation"))
                                {
                                    flag = false;
                                }
                            }
                            if (id != null && tipe.Equals("Directed Association"))
                            {
                                Console.WriteLine("StartVertex: " + startVertex);
                                Console.WriteLine("EndVertex: " + endVertex);

                                Point start = new Point(StartPointX, StartPointY);
                                Point end = new Point(EndPointX, EndPointY);
                                Console.WriteLine("Directed Association : " + id);

                                DirectedAssociationLine tempLine = new DirectedAssociationLine(start, end);
                                tempLine.ID = new Guid(id);
                                tempLine.idStartVertex = startVertex;
                                tempLine.idEndVertex = endVertex;
                                tempLine.relationStart = jenisRelasiAsal;
                                tempLine.relationEnd = jenisRelasiTujuan;

                                DrawingObject.Add(tempLine);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Unserialize Association: " + ex);
            }

            reader.Close();
            return DrawingObject;

        }
    }
}
