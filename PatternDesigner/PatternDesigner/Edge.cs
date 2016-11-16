using System;
using System.Collections.Generic;
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
