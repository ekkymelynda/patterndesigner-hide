using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PatternDesigner
{
    public interface ICanvas
    {
        String Name { get; set; }
        ITool GetActiveTool();
        
        void SetActiveTool(ITool tool);
        void Repaint();
        void SetBackgroundColor(Color color);

        void AddDrawingObject(DrawingObject drawingObject);
        void RemoveDrawingObject(DrawingObject drawingObject);

        DrawingObject GetObjectAt(int x, int y);
        DrawingObject SelectObjectAt(int x, int y);
        DrawingObject GetSelectedObject();
        List<DrawingObject> GetListSelectedObject();
        List<DrawingObject> GetListDrawingObject();
        void SetSelectedObject(DrawingObject obj);
        void SetListSelectedObecjt(List<DrawingObject> listObj);
        void EmptyListSelectedObject();
        void DeselectAllObjects();
        Stack<ICommand> GetUndoStack();
        Stack<ICommand> GetRedoStack();
        Stack<ICommand> GetCopyStack();
        void AddCommand(ICommand command);
        void AddCopyCommand(ICommand command);
    }
}
