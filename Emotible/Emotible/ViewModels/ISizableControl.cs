using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emotible.ViewModels
{
    public interface ISizableControl
    {
        double Width { get; }
        double Height { get; }
    }
}
