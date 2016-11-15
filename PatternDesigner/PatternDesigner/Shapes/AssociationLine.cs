using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PatternDesigner.Shapes
{
    class AssociationLine : Edge
    {
        private const double EPSILON = 3.0;

        private Pen pen;
        private Vertex startVertex;
        private Vertex endVertex;

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
            }
        }

        public override bool Intersect(int xTest, int yTest)
        {
            double m = GetSlope();
            double b = Endpoint.Y - m * Endpoint.X;
            double y_point = m * xTest + b;

            if (Math.Abs(yTest - y_point) < EPSILON)
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public double GetSlope()
        {
            double m = (double)(Endpoint.Y - Startpoint.Y) / (double)(Endpoint.X - Startpoint.X);
            return m;
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            if (startVertex == null || endVertex == null)
            {
                this.Startpoint = new Point(this.Startpoint.X + xAmount, this.Startpoint.Y + yAmount);
                this.Endpoint = new Point(this.Endpoint.X + xAmount, this.Endpoint.Y + yAmount);
            }
        }

        public override void AddVertex(Vertex v)
        {
            if(startVertex == null)
            {
                startVertex = v;
            }
            else
            {
                endVertex = v;
            }
        }

        public override void Update()
        {
            int startPointX, startPointY, endPointX, endPointY;
            int startVertexMin, startVertexMax, endVertexMin, endVertexMax;
            startVertexMin = startVertex.X;
            startVertexMax = startVertex.X + startVertex.Width;
            endVertexMin = endVertex.X;
            endVertexMax = endVertex.X + endVertex.Width;

            if ((startVertexMin < endVertexMax && startVertexMin > endVertexMin) || (startVertexMax > endVertexMin && startVertexMax < endVertexMax) || (startVertexMin <= endVertexMin && startVertexMax >= endVertexMax) || (endVertexMin <= startVertexMin && endVertexMax >= startVertexMax))
            {

                startPointX = startVertex.X + (startVertex.Width / 2);
                endPointX = endVertex.X + (endVertex.Width / 2);
                
                if(startVertex.Y < endVertex.Y)
                {
                    startPointY = startVertex.Y + startVertex.Height;
                    endPointY = endVertex.Y;
                }
                else
                {
                    startPointY = startVertex.Y;
                    endPointY = endVertex.Y + endVertex.Height;
                }
                
            }
            else if (startVertex.X < endVertex.X)
            {
                startPointX = startVertex.Width + startVertex.X;
                startPointY = (startVertex.Height / 2) + startVertex.Y;
                endPointX = endVertex.X;
                endPointY = (endVertex.Height / 2) + endVertex.Y;

            }
            else {
                startPointX = startVertex.X;
                startPointY = (startVertex.Height / 2) + startVertex.Y;
                endPointX = endVertex.X + endVertex.Width;
                endPointY = (endVertex.Height / 2) + endVertex.Y;
            }

            this.Startpoint = new Point(startPointX, startPointY);
            this.Endpoint = new Point(endPointX, endPointY);
        }
    }
}
