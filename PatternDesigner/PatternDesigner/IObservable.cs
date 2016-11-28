using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner
{
    public interface IObservable
    {
        void Subscribe(IObserver o);
        void Unsubscribe(IObserver o);
        void Broadcast();
    }
}
