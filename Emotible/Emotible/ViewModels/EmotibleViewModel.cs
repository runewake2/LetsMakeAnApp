using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emotible.ViewModels
{
    public class EmotibleViewModel : BaseViewModel
    {
        private ObservableCollection<IEmoteViewModel> _emotes = new ObservableCollection<IEmoteViewModel>(new EmoteViewModel[] {
            new EmoteViewModel() { Height = 1, Width = 1, Name = "Huzzah", Text = "Foo" },
            new EmoteViewModel() { Height = 1, Width = 1, Name = "Huzzah", Text = "Foo" },
            new EmoteViewModel() { Height = 1, Width = 1, Name = "Huzzah", Text = "Foo" },
            new EmoteViewModel() { Height = 1, Width = 1, Name = "Huzzah", Text = "Foo" },
            new EmoteViewModel() { Height = 1, Width = 1, Name = "Huzzah", Text = "Foo" },
            new EmoteViewModel() { Height = 1, Width = 1, Name = "Huzzah", Text = "Foo" }
        });

        public ObservableCollection<IEmoteViewModel> Emotes
        {
            get { return _emotes; }
            set
            {
                if (_emotes != value)
                {
                    _emotes = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}