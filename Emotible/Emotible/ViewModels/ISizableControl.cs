using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emotible.ViewModels
{
    internal interface ISizableControl
    {
        int Width { get; }
        int Height { get; }
    }
}
