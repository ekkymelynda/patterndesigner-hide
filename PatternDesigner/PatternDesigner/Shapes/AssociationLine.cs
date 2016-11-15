using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PatternDesigner.Shapes
{
    class AssociationLine : Edge
    {
        private const double EPSILON = 3.0;

        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        private Pen pen;
        private Vertex a;
        private Vertex b;

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
            Debug.WriteLine("text");
            if (a == null || b == null)
            {
                this.Startpoint = new Point(this.Startpoint.X + xAmount, this.Startpoint.Y + yAmount);
                this.Endpoint = new Point(this.Endpoint.X + xAmount, this.Endpoint.Y + yAmount);
            }
        }

        public override void AddVertex(Vertex v)
        {
            if(a == null)
            {
                a = v;
            }
            else
            {
                b = v;
            }
        }

        public override void Update(IObservable o, int x, int y)
        {
            if(a == o)
            {
                this.Startpoint = new Point(this.Startpoint.X + x, this.Startpoint.Y + y);
            }
            if(b == o)
            {
                this.Endpoint = new Point(this.Endpoint.X + x, this.Endpoint.Y + y);
            }
        }
    }
}
