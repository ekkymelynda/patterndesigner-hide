using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace PatternDesigner
{
    public class DefaultCanvas : Control, ICanvas
    {
        private Stack<ICommand> undoCommands = new Stack<ICommand>();
        private Stack<ICommand> redoCommands = new Stack<ICommand>();
        private Stack<ICommand> copyStack = new Stack<ICommand>();

        private ITool activeTool;
        private List<DrawingObject> drawingObjects;
        private DrawingObject selectedObject;
        public List<DrawingObject> listSelectedObject;

        public DefaultCanvas()
        {
            Init();
        }

        private void Init()
        {
            
            this.drawingObjects = new List<DrawingObject>();
            this.listSelectedObject = new List<DrawingObject>();
            this.DoubleBuffered = true;

            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            this.Paint += DefaultCanvas_Paint;
            this.MouseDown += DefaultCanvas_MouseDown;
            this.MouseUp += DefaultCanvas_MouseUp;
            this.MouseMove += DefaultCanvas_MouseMove;
            this.MouseDoubleClick += DefaultCanvas_DoubleClick;
            
        }

        private void DefaultCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseMove(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseUp(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseDown(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_DoubleClick(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseDoubleClick(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (DrawingObject obj in drawingObjects)
            {
                obj.Graphics = e.Graphics;
                obj.Draw();
            }
        }

        public void Repaint()
        {
            this.Invalidate();
            this.Update();
        }

        public void SetActiveTool(ITool tool)
        {
            this.activeTool = tool;
        }

        public ITool GetActiveTool()
        {
            return this.activeTool;
        }

        public void SetBackgroundColor(Color color)
        {
            this.BackColor = color;
        }

        public void AddDrawingObject(DrawingObject drawingObject)
        {
            this.drawingObjects.Add(drawingObject);
        }

        public void RemoveDrawingObject(DrawingObject drawingObject)
        {
            this.drawingObjects.Remove(drawingObject);
        }

        public DrawingObject GetObjectAt(int x, int y)
        {
            foreach (DrawingObject obj in drawingObjects)
            {
                if (obj.Intersect(x, y))
                {
                    return obj;
                }
            }
            return null;
        }

        public DrawingObject SelectObjectAt(int x, int y)
        {
            DrawingObject obj = GetObjectAt(x, y);
           
            if (obj != null)
            {
                obj.Select();
                this.selectedObject = obj;
            }
            return obj;
        }

        public DrawingObject GetSelectedObject()
        {
            return selectedObject;
        }

        public List<DrawingObject> GetListSelectedObject()
        {
            return listSelectedObject;
        }

        public List<DrawingObject> GetListDrawingObject()
        {
            return drawingObjects;
        }

        public void DeselectAllObjects()
        {
            foreach (DrawingObject drawObj in drawingObjects)
            {
                drawObj.Deselect();
            }
        }

        public void SetSelectedObject(DrawingObject obj)
        {
            this.selectedObject = obj;
        }

        public void AddCommand(ICommand command)
        {
            undoCommands.Push(command);
        }

        public Stack<ICommand> GetUndoStack()
        {
            return undoCommands;
        }

        public Stack<ICommand> GetRedoStack()
        {
            return redoCommands;
        }

        public Stack<ICommand> GetCopyStack()
        {
            return copyStack;
        }

        public void AddCopyCommand(ICommand command)
        {
            copyStack.Push(command);
        }

        public void SetListSelectedObecjt(List<DrawingObject> listObj)
        {
            this.listSelectedObject = listObj;
        }


        public void EmptyListSelectedObject()
        {
            this.listSelectedObject.Clear();
        }
    }
}
