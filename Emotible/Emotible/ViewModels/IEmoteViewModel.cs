using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emotible.ViewModels
{
    public interface IEmoteViewModel
    {
        string Name { get; }
        string Text { get; }
    }
}
