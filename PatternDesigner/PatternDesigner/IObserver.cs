using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner
{
    public interface IObserver
    {
        void Update(IObservable o, int x, int y);
    }
}
