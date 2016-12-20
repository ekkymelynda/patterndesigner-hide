using PatternDesigner.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PatternDesigner.Commands
{
    public class Save : Command
    {
        private ICanvas canvas;
        protected string path = @"d:\export\";

        public Save(ICanvas canvas)
        {

            this.canvas = canvas;
        }

        public override void Execute()
        {
            using (var SaveFileDialog = new SaveFileDialog())
            {
                SaveFileDialog.Filter = "Pattern Designer Document(*ptd)|*.ptd";
                SaveFileDialog.Title = "Save an Document";
                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string path = SaveFileDialog.FileName;

                    List<DrawingObject> listDrawingObject = canvas.GetListDrawingObject();
                    Debug.WriteLine(listDrawingObject.Count());

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.NewLineOnAttributes = true;

                    XmlWriter writer = XmlWriter.Create(path, settings);
                    writer.WriteStartDocument();
                    writer.WriteStartElement("diagram");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();

                    for (int i = 0; i < listDrawingObject.Count; i++)
                    {
                        DrawingObject obj = listDrawingObject[i];
                        if (obj is IPersistance)
                        {
                            if (obj is Shapes.Rectangle)
                            {
                                Shapes.Rectangle tempObj = (Shapes.Rectangle)obj;
                                tempObj.Serialize(path);
                                i += 2;
                            }

                            else if (obj is AssociationLine)
                            {
                                AssociationLine tempObj1 = (AssociationLine)obj;
                                tempObj1.Serialize(path);
                            }

                            else if (obj is DependencyLine)
                            {
                                DependencyLine tempObj2 = (DependencyLine)obj;
                                tempObj2.Serialize(path);
                            }

                            else if (obj is DirectedAssociationLine)
                            {
                                DirectedAssociationLine tempObj3 = (DirectedAssociationLine)obj;
                                tempObj3.Serialize(path);
                            }

                            else if (obj is GeneralizationLine)
                            {
                                GeneralizationLine tempObj4 = (GeneralizationLine)obj;
                                tempObj4.Serialize(path);
                            }

                            else if (obj is RealizationLine)
                            {
                                RealizationLine tempObj5 = (RealizationLine)obj;
                                tempObj5.Serialize(path);
                            }

                        }
                    }
                }
            }
        }

        public override void Unexecute()
        {
            throw new NotImplementedException();
        }
    }
}
