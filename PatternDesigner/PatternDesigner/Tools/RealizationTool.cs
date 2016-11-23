﻿using PatternDesigner.Shapes;
using System;
using System.Windows.Forms;

namespace PatternDesigner.Tools
{
    public partial class RealizationTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private RealizationLine line;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public RealizationTool()
        {
            this.Name = "Realization Line tool";
            this.ToolTipText = "Realization Line tool";
            this.Image = IconSet.realization;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                line = new RealizationLine(new System.Drawing.Point(e.X, e.Y));
                line.Endpoint = new System.Drawing.Point(e.X, e.Y);
                canvas.AddDrawingObject(line);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.line != null)
                {
                    line.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (this.line != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    line.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    line.Select();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.line);
                }
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
