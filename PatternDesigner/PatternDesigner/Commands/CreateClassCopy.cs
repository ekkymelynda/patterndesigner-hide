using PatternDesigner.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.Commands
{
    public class CreateClassCopy : Command
    {
        
        private List<DrawingObject> listObjectSelected;
        private Vertex choosenObject;
        private Rectangle rectangle;


        public CreateClassCopy(ICanvas canvas)
        {
            this.canvas = canvas;
            removeRedoStack();
        }

        public override void Execute()
        {
            this.listObjectSelected = canvas.GetListSelectedObject();
            List<DrawingObject> newListSelectedObject = new List<DrawingObject>();
            foreach(DrawingObject obj in listObjectSelected)
            {
                if(obj is Vertex)
                {
                    choosenObject = (Vertex)obj;
                    rectangle = new Rectangle(choosenObject.X + 10 + choosenObject.Width, choosenObject.Y, choosenObject.Width, choosenObject.Height);

                    canvas.AddDrawingObject(rectangle);
                    canvas.AddDrawingObject(rectangle);
                    canvas.AddDrawingObject(rectangle);

                    rectangle.nama = choosenObject.nama;

                    if (choosenObject.att.Count() != 0)
                    {
                        foreach (Attribute a in choosenObject.att)
                        {
                            rectangle.att.Add(new Attribute() { visibility = a.visibility, nama = a.nama, tipe = a.tipe });
                        }
                    }

                    if (choosenObject.meth.Count() != 0)
                    {
                        foreach (Method b in choosenObject.meth)
                        {
                            rectangle.meth.Add(new Method() { visibility = b.visibility, nama = b.nama, tipe = b.tipe });
                        }
                    }

                    choosenObject.Deselect();
                    rectangle.Select();
                    newListSelectedObject.Add(rectangle);
                }
            }
            canvas.GetListSelectedObject().Clear();
            ICommand command = new CreateClass(newListSelectedObject.Cast<Vertex>().ToList(), canvas);
            canvas.AddCommand(command);
            canvas.SetListSelectedObecjt(newListSelectedObject);

        }

        public override void Unexecute()
        {

        }
    }
}
