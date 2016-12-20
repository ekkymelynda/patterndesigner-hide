using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner
{
    public interface IPersistance
    {
        void Serialize(string path); //path untuk xml
        List<DrawingObject>Unserialize(string path); //path untuk xml
    }
}
