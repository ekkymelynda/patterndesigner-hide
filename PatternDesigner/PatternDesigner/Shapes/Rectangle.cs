using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PatternDesigner.Shapes
{
    public class Rectangle : Vertex
    {
        public Pen pen;
        PointF ukuran = new PointF(100, 1);
        private SizeF widthTerkecil;
        
        public Rectangle()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public Rectangle(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        public Rectangle(int x, int y, int width, int height) : this(x, y)
        {
            this.Width = width;
            this.Height = height;
        }

        public override bool Intersect(int xTest, int yTest)
        {
            if ((xTest >= X && xTest <= X + Width) && (yTest >= Y && yTest <= Y + Height))
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public override void RenderOnStaticView()
        {
            widthTerkecil = new SizeF(100F, 1F);
            this.Height = 40 + this.att.Count * 15 + this.meth.Count * 15;
            this.pen.Color = Color.Black;
            this.pen.DashStyle = DashStyle.Solid;
            Font f = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            StringFormat sf = new StringFormat();
            //sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            if (this.Graphics != null)
            {
                

                if (nama != null)
                {
                    UpdateMinWidth(this.nama, f);
                    this.Graphics.DrawString(this.nama, f, drawBrush, X + Width / 2, Y, sf);
                }

                int posY = Y + 20;

                if (att.Count > 0)
                {
                    foreach (Attribute atte in att)
                    {
                        if (atte.visibility == "private")
                        {
                            UpdateMinWidth("-" + atte.tipe + " " + atte.nama, f);
                            this.Graphics.DrawString("-" + atte.tipe + " " + atte.nama, f, drawBrush, X, posY);
                        }
                        else if (atte.visibility == "protected")
                        {
                            UpdateMinWidth("#" + atte.tipe + " " + atte.nama, f);
                            this.Graphics.DrawString("#" + atte.tipe + " " + atte.nama, f, drawBrush, X, posY);
                        }
                        else
                        {
                            UpdateMinWidth("+" + atte.tipe + " " + atte.nama, f);
                            this.Graphics.DrawString("+" + atte.tipe + " " + atte.nama, f, drawBrush, X, posY);
                        }

                        posY += 15;
                    }
                }
                
                //method tampil
                int panjangY = Y + 30 + (att.Count) * 15;

                if (meth.Count > 0)
                {
                    //Debug.WriteLine("ada");
                    foreach (Method mett in meth)
                    {
                        if (mett.visibility == "private")
                        {
                            UpdateMinWidth("-" + " " + mett.nama + ":" + mett.tipe, f);
                            this.Graphics.DrawString("-" + " " + mett.nama + ":" + mett.tipe, f, drawBrush, X, panjangY);
                        }
                        else if (mett.visibility == "public")
                        {
                            UpdateMinWidth("+" + " " + mett.nama + ":" + mett.tipe, f);
                            this.Graphics.DrawString("+" + " " + mett.nama + ":" + mett.tipe, f, drawBrush, X, panjangY);
                        }
                        else
                        {
                            UpdateMinWidth("#" + " " + mett.nama + ":" + mett.tipe, f);
                            this.Graphics.DrawString("#" + " " + mett.nama + ":" + mett.tipe, f, drawBrush, X, panjangY);
                        }
                        panjangY += 15;
                    }
                }
                else
                {
                    //Debug.WriteLine("kosong");
                }
                Debug.WriteLine("lala= " + widthTerkecil.Width);

                this.Width = (int)widthTerkecil.Width;

                Graphics.DrawRectangle(this.pen, X, Y, Width, Height);

                //separator nama dengan atribut
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Point start1 = new Point(X, Y + 20);
                Point end1 = new Point(X + Width, Y + 20);
                this.Graphics.DrawLine(this.pen, start1, end1);

                //separator atribut dengan method
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Point start2 = new Point(X, Y + 10 + (att.Count + 1) * 15);
                Point end2 = new Point(X + Width, Y + 10 + (att.Count + 1) * 15);
                this.Graphics.DrawLine(this.pen, start2, end2);


                //Console.WriteLine(Y + 30 + (meth.Count) * 15 + (att.Count) * 15);
            }
        }

        public override void RenderOnEditingView()
        {
            widthTerkecil = new SizeF(100F, 1F);
            this.pen.Color = Color.Blue;
            this.pen.DashStyle = DashStyle.Solid;
            this.Height = 40 + this.att.Count * 15 + this.meth.Count * 15;
            this.pen.Color = Color.Blue;
            this.pen.DashStyle = DashStyle.Solid;
            Font f = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Blue);

            StringFormat sf = new StringFormat();
            //sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;


            if (this.Graphics != null)
            {


                if (nama != null)
                {
                    UpdateMinWidth(this.nama, f);
                    this.Graphics.DrawString(this.nama, f, drawBrush, X + Width / 2, Y, sf);
                }

                int posY = Y + 20;

                if (att.Count > 0)
                {
                    foreach (Attribute atte in att)
                    {
                        if (atte.visibility == "private")
                        {
                            UpdateMinWidth("-" + atte.tipe + " " + atte.nama, f);
                            this.Graphics.DrawString("-" + atte.tipe + " " + atte.nama, f, drawBrush, X, posY);
                        }
                        else if (atte.visibility == "protected")
                        {
                            UpdateMinWidth("#" + atte.tipe + " " + atte.nama, f);
                            this.Graphics.DrawString("#" + atte.tipe + " " + atte.nama, f, drawBrush, X, posY);
                        }
                        else
                        {
                            UpdateMinWidth("+" + atte.tipe + " " + atte.nama, f);
                            this.Graphics.DrawString("+" + atte.tipe + " " + atte.nama, f, drawBrush, X, posY);
                        }

                        posY += 15;
                    }
                }

                //method tampil
                int panjangY = Y + 30 + (att.Count) * 15;

                if (meth.Count > 0)
                {
                    //Debug.WriteLine("ada");
                    foreach (Method mett in meth)
                    {
                        if (mett.visibility == "private")
                        {
                            UpdateMinWidth("-" + " " + mett.nama + ":" + mett.tipe, f);
                            this.Graphics.DrawString("-" + " " + mett.nama + ":" + mett.tipe, f, drawBrush, X, panjangY);
                        }
                        else if (mett.visibility == "public")
                        {
                            UpdateMinWidth("+" + " " + mett.nama + ":" + mett.tipe, f);
                            this.Graphics.DrawString("+" + " " + mett.nama + ":" + mett.tipe, f, drawBrush, X, panjangY);
                        }
                        else
                        {
                            UpdateMinWidth("#" + " " + mett.nama + ":" + mett.tipe, f);
                            this.Graphics.DrawString("#" + " " + mett.nama + ":" + mett.tipe, f, drawBrush, X, panjangY);
                        }
                        panjangY += 15;
                    }
                }
                else
                {
                    //Debug.WriteLine("kosong");
                }
                Debug.WriteLine("lala= " + widthTerkecil.Width);

                this.Width = (int)widthTerkecil.Width;

                Graphics.DrawRectangle(this.pen, X, Y, Width, Height);

                //separator nama dengan atribut
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Point start1 = new Point(X, Y + 20);
                Point end1 = new Point(X + Width, Y + 20);
                this.Graphics.DrawLine(this.pen, start1, end1);

                //separator atribut dengan method
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Point start2 = new Point(X, Y + 10 + (att.Count + 1) * 15);
                Point end2 = new Point(X + Width, Y + 10 + (att.Count + 1) * 15);
                this.Graphics.DrawLine(this.pen, start2, end2);


                //Console.WriteLine(Y + 30 + (meth.Count) * 15 + (att.Count) * 15);
            }
        }

        public override void RenderOnPreview()
        {
            this.pen.Color = Color.Red;
            this.pen.DashStyle = DashStyle.DashDot;
            Graphics.DrawRectangle(this.pen, X, Y, Width, Height);
            this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Point start1 = new Point(X, Y + 20);
            Point end1 = new Point(X + Width, Y + 20);
            this.Graphics.DrawLine(this.pen, start1, end1);
            this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Point start2 = new Point(X, Y + Height / 3 * 2);
            Point end2 = new Point(X + Width, Y + Height / 3 * 2);
            this.Graphics.DrawLine(this.pen, start2, end2);
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.X += xAmount;
            this.Y += yAmount;
            Broadcast(xAmount, yAmount);
        }

        private void UpdateMinWidth(String text, Font f)
        {
            SizeF stringSize = new SizeF();
            stringSize = this.Graphics.MeasureString(text, f);
            if (stringSize.Width > widthTerkecil.Width)
            {
                widthTerkecil.Width = stringSize.Width;
            }

            if (widthTerkecil.Width < 100F)
            {
                widthTerkecil.Width = 100F;
            }
        }
    }
}
