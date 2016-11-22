using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PatternDesigner.Shapes
{
    class DependencyLine : Edge
    {
        public DependencyLine()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 2.0f;
        }

        public DependencyLine(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public DependencyLine(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.Endpoint = endpoint;
        }

        public override void RenderOnStaticView()
        {
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5, false);
            pen.Color = Color.Black;
            pen.Width = 2.0f;
            pen.DashStyle = DashStyle.Dash;
            pen.CustomEndCap = bigArrow;

            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }

        public override void RenderOnEditingView()
        {
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5, false);
            pen.Color = Color.Blue;
            pen.Width = 2.0f;
            pen.DashStyle = DashStyle.Dash;
            pen.CustomEndCap = bigArrow;

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
            pen.EndCap = LineCap.ArrowAnchor;

            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }
    }
}
