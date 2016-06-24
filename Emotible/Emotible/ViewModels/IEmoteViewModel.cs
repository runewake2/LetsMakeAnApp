using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emotible.ViewModels
{
    public interface IEmoteViewModel
    {
        int Id { get; }
        string Name { get; }
        string Text { get; }
        double Width { get; }
        double Height { get; }
        int ColumnSpan { get; }
        int RowSpan { get; }
        int TimesUsed { get; }
    }
}
