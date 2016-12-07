using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDesigner.Commands
{
    public class ApplyClassProperties : ICommand
    {
        private Vertex vertex;
        private string oldName;
        private string newName;
        private List<Method> oldMethod = new List<Method>();
        private List<Attribute> oldAttribute =  new List<Attribute>();
        private List<Method> newMethod = new List<Method>();
        private List<Attribute> newAttribute = new List<Attribute>();


        public ApplyClassProperties(Vertex vertex, string newName, string oldName, List<Method> meth, List<Attribute> att,  TextBox[] newAttributeBox, TextBox[] newNameAttributebox, TextBox[] newTypeAttributeBox, TextBox[] newMethodBox, TextBox[] newNameMethodbox, TextBox[] newTypeMethodBox, int i, int j)
        {
            this.vertex = vertex;
            this.oldName = oldName;
            this.newName = newName;

            if (att.Count() != 0)
            {
                foreach (Attribute a in att)
                {
                    oldAttribute.Add(new Attribute() { visibility = a.visibility, nama = a.nama, tipe = a.tipe });
                }
            }

            if (meth.Count() != 0)
            {
                foreach (Method b in meth)
                {
                    oldMethod.Add(new Method() { visibility = b.visibility, nama = b.nama, tipe = b.tipe });
                }
            }

            if (i > 0)
            {
                for (int a = 1; a < i; a++)
                {
                    newAttribute.Add(new Attribute() { visibility = newAttributeBox[a].Text, nama = newNameAttributebox[a].Text, tipe = newTypeAttributeBox[a].Text });
                }
            }

            if (j > 0)
            {
                for (int b = 1; b < j; b++)
                {
                    newMethod.Add(new Method() { visibility = newMethodBox[b].Text, nama = newNameMethodbox[b].Text, tipe = newTypeMethodBox[b].Text });
                }
            }
        }

        public void Execute()
        {
            vertex.nama = newName;

            vertex.att.Clear();
            if (newAttribute.Count() != 0)
            {
                foreach (Attribute a in newAttribute)
                {
                    vertex.att.Add(new Attribute() { visibility = a.visibility, nama = a.nama, tipe = a.tipe });
                }
            }

            vertex.meth.Clear();
            if (newMethod.Count() != 0)
            {
                foreach (Method b in newMethod)
                {
                    vertex.meth.Add(new Method() { visibility = b.visibility, nama = b.nama, tipe = b.tipe });
                }
            }
        }

        public void Unexecute()
        {
            vertex.nama = oldName;
    
            vertex.att.Clear();
            if (oldAttribute.Count() != 0)
            {
                foreach (Attribute a in oldAttribute)
                {
                    vertex.att.Add(new Attribute() { visibility = a.visibility, nama = a.nama, tipe = a.tipe });
                }
            }

            vertex.meth.Clear();

            if (oldMethod.Count() != 0)
            {
                foreach (Method b in oldMethod)
                {
                    vertex.meth.Add(new Method() { visibility = b.visibility, nama = b.nama, tipe = b.tipe });
                }
            }
        }
    }
}
