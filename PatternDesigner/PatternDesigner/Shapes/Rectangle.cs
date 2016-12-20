using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using PatternDesigner.Commands;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace PatternDesigner.Shapes
{
    public class Rectangle : Vertex, IPersistance
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
                Broadcast();

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
                Broadcast();
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

        public override void Translate(int xAmount, int yAmount)
        {
            Debug.WriteLine(this.ID);
            ICommand command = new TranslateVertex(this, xAmount, yAmount);
            command.Execute();
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

        public void GenerateFile(string path)
        {
            if (this.nama != "")
            {
                string newPath = path + this.nama + ".cs";
                //Debug.WriteLine(newPath);
                if (File.Exists(newPath))
                {
                    File.Delete(newPath);
                }

                String isi = "public class " + this.nama + " \n{";
                foreach (Attribute atr in att)
                {
                    isi += "\t " + atr.visibility + " " + atr.tipe + " " + atr.nama + ";\n";
                }

                isi += "\n";

                foreach (Method met in meth)
                {
                    isi += "\t " + met.visibility + " " + met.tipe + " " + met.nama + " {}\n";
                }

                isi += "}";

                using (FileStream fs = File.Create(newPath))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(isi);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
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


            if (this.nama == null)
            {
                file.Add(new XElement("class"));
            }

            else
            {
                file.Add(new XElement("class",
                new XAttribute("id", this.ID.ToString()),
                new XAttribute("nama", this.nama),
                new XAttribute("posX", this.X.ToString()),
                new XAttribute("posY", this.Y.ToString()),
                new XAttribute("width", this.Width.ToString()),
                new XAttribute("height", this.Height.ToString())));

                file = (XElement)file.LastNode;

                foreach (Attribute temp in this.att)
                {
                    file.Add(new XElement("attribute", new XElement("visibility", temp.visibility),
                        new XElement("type", temp.tipe),
                        new XElement("nama", temp.nama)));
                }

                foreach (Method temp in this.meth)
                {
                    file.Add(new XElement("method", new XElement("visibility", temp.visibility),
                        new XElement("return", temp.tipe),
                        new XElement("nama", temp.nama)));
                }
            }
            

            doc.Save(path);
        }

        public List<DrawingObject> Unserialize(string path)
        {
            List<DrawingObject> DrawingObject = new List<DrawingObject>();
            List<Attribute> Attribute = new List<Attribute>();
            List<Method> Method = new List<Method>();
            Rectangle rectangle = null;
            int x = 0, y = 0, width = 0, height = 0;
            string id = null;
            Boolean flag = true;
            int flagAtr = 0;
            string nama = null;

            XmlTextReader reader = new XmlTextReader(path);
            reader.MoveToContent();

            try
            {
                if (reader.Name.Equals("diagram"))
                {
                    while (reader.Read())
                    {
                        if (reader.Name.Equals("class"))
                        {
                            Boolean flagClass = true;

                            reader.MoveToFirstAttribute();
                            id = reader.Value;
                            reader.MoveToNextAttribute();
                            nama = reader.Value;
                            reader.MoveToNextAttribute();
                            x = Int32.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            y = Int32.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            height = Int32.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            width = Int32.Parse(reader.Value);
                            reader.MoveToElement();

                            while (reader.Read() && flagClass)
                            {
                                reader.MoveToContent();
                                flag = true; flagAtr = 0;
                                if (reader.Name.Equals("attribute"))
                                {
                                    Attribute atr = new Attribute();
                                    while (reader.Read() && flag)
                                    {
                                        switch (reader.NodeType)
                                        {
                                            case XmlNodeType.Element:
                                                if (reader.Name.Equals("visibility"))
                                                {
                                                    flagAtr = 1;
                                                }
                                                else if (reader.Name.Equals("type"))
                                                {
                                                    flagAtr = 2;
                                                }
                                                else if (reader.Name.Equals("nama"))
                                                {
                                                    flagAtr = 3;
                                                }
                                                break;
                                            case XmlNodeType.Text:
                                                if (flagAtr == 1)
                                                {
                                                    atr.visibility = reader.Value;
                                                }
                                                else if (flagAtr == 2)
                                                {
                                                    atr.tipe = reader.Value;
                                                }
                                                else if (flagAtr == 3)
                                                {
                                                    atr.nama = reader.Value;
                                                }
                                                break;
                                            case XmlNodeType.EndElement:
                                                if (reader.Name.Equals("attribute"))
                                                {
                                                    flag = false;
                                                    Attribute.Add(atr);
                                                }
                                                break;
                                        }
                                    }
                                }
                                else if (reader.Name.Equals("method"))
                                {
                                    Method mtd = new Method();
                                    while (reader.Read() && flag)
                                    {
                                        switch (reader.NodeType)
                                        {
                                            case XmlNodeType.Element:
                                                if (reader.Name.Equals("visibility"))
                                                {
                                                    flagAtr = 1;
                                                }
                                                else if (reader.Name.Equals("return"))
                                                {
                                                    flagAtr = 2;
                                                }
                                                else if (reader.Name.Equals("nama"))
                                                {
                                                    flagAtr = 3;
                                                }
                                                break;
                                            case XmlNodeType.Text:
                                                if (flagAtr == 1)
                                                {
                                                    mtd.visibility = reader.Value;
                                                }
                                                else if (flagAtr == 2)
                                                {
                                                    mtd.tipe = reader.Value;
                                                }
                                                else if (flagAtr == 3)
                                                {
                                                    mtd.nama = reader.Value;
                                                }
                                                break;
                                            case XmlNodeType.EndElement:
                                                if (reader.Name.Equals("method"))
                                                {
                                                    flag = false;
                                                    Method.Add(mtd);
                                                }
                                                break;
                                        }
                                    }
                                }
                                else if(reader.Name.Equals("class"))
                                {
                                    flagClass = false;
                                }
                            }
                            if (id != null)
                            {
                                Console.WriteLine("ID: " + id);
                                Console.WriteLine("x: " + x);
                                Console.WriteLine("y: " + y);
                                Console.WriteLine("width: " + width);
                                Console.WriteLine("Height" + height);
                                rectangle = new Rectangle(x, y);
                                rectangle.ID = new Guid(id);
                                rectangle.nama = nama;
                                rectangle.Width = width;
                                rectangle.Height = height;
                                foreach(Attribute attr in Attribute)
                                {
                                    rectangle.att.Add(attr);
                                }
                                foreach (Method mtd in Method)
                                {
                                    rectangle.meth.Add(mtd);
                                }

                                DrawingObject.Add(rectangle);

                                Attribute.Clear();
                                Method.Clear();

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Unserialize Rectangle: " + ex);
            }

            reader.Close();
            return DrawingObject;

        }
    }
}
