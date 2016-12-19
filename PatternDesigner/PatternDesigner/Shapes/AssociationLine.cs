using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace PatternDesigner.Shapes
{
    class AssociationLine : Edge, IPersistance
    {
        public AssociationLine()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 2.0f;
        }

        public AssociationLine(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public AssociationLine(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.Endpoint = endpoint;
        }

        public override void RenderOnStaticView()
        {
            pen.Color = Color.Black;
            pen.Width = 2.0f;
            pen.DashStyle = DashStyle.Solid;

            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
                DrawName();
            }
        }

        public override void RenderOnEditingView()
        {
            pen.Color = Color.Blue;
            pen.Width = 2.0f;
            pen.DashStyle = DashStyle.Solid;

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

            if (this.name==null)
            {
                file.Add(new XElement("relation"));
            }
            else
            {
                file.Add(new XElement("relation",
                new XAttribute("id", this.ID.ToString()),
                new XAttribute("startPointX", this.GetStartPointX()),
                new XAttribute("startPointY", this.GetStartPointY()),
                new XAttribute("startEndX", this.GetEndPointX()),
                new XAttribute("startEndY", this.GetEndPointY()),
                new XAttribute("tipe", "Association")));

                file = (XElement)file.LastNode;

                file.Add(new XElement("nama", this.name));
                file.Add(new XElement("jenisRelasiAsal", this.relationStart));
                file.Add(new XElement("jenisRelasiTujuan", this.relationEnd));
            }
            

            doc.Save(path);
        }

        public List<DrawingObject> Unserialize(string path)
        {
            throw new NotImplementedException();
        }
    }
}
