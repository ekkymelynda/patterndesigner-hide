using PatternDesigner.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner
{
    public abstract class Edge : DrawingObject, IObserver
    {
        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }
        private Vertex startVertex;
        private Vertex endVertex;

        public const double EPSILON = 3.0;
        public Pen pen;

        public double GetSlope()
        {
            double m = (double)(Endpoint.Y - Startpoint.Y) / (double)(Endpoint.X - Startpoint.X);
            return m;
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

        public void AddVertex(Vertex v)
        {
            if (startVertex == null)
            {
                startVertex = v;
            }
            else
            {
                endVertex = v;
            }
        }

        public void Update()
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

                if (startVertex.Y < endVertex.Y)
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
            else
            {
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
