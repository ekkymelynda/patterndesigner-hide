﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            if (this.name == null)
            {
                file.Add(new XElement("relation"));
            }

            else
            {

                file.Add(new XElement("relation",
                    new XAttribute("id", this.ID.ToString()),
                    new XAttribute("StartPointX", this.GetStartPointX()),
                    new XAttribute("StartPointY", this.GetStartPointY()),
                    new XAttribute("EndPointX", this.GetEndPointX()),
                    new XAttribute("EndPointY", this.GetEndPointY()),
                    new XAttribute("tipe", "Directed Association")));

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
