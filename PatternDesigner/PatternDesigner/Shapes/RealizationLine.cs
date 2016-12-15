using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace PatternDesigner.Shapes
{
    class RealizationLine : Edge
    {
        public RealizationLine()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 2.0f;
        }

        public RealizationLine(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public RealizationLine(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.Endpoint = endpoint;
        }

        public override void RenderOnStaticView()
        {
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
            pen.Color = Color.Black;
            pen.Width = 2.0f;
            pen.DashStyle = DashStyle.Dash;
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
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
            pen.Color = Color.Blue;
            pen.Width = 2.0f;
            pen.DashStyle = DashStyle.Dash;
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
            pen.EndCap = LineCap.DiamondAnchor;

            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
                //DrawName();
            }
        }
    }
}
