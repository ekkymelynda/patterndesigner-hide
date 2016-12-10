using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesigner
{
    public interface IPluginHost
    {
        void Register(IPlugin plugin, ICanvas canvas);
    }
}
