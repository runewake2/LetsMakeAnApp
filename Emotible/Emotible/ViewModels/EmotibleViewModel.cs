using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Emotible.Layout;
using Emotible.Model;

namespace Emotible.ViewModels
{
    public class EmotibleViewModel : BaseViewModel
    {
        private LayoutController controller = new LayoutController();

        private ObservableCollection<IEmoteViewModel> _emotes = new ObservableCollection<IEmoteViewModel>();

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

        private int _columns;

        public int Columns
        {
            get { return _columns; }
            set {
                if (_columns != value)
                {
                    _columns = value;
                    NotifyPropertyChanged();
                    UpdateEmotesAsync();
                }
            }
        }

        private double _width;

        public double Width
        {
            get { return _width; }
            set
            {
                if (_width != value)
                {
                    _width = value;
                    var gridSize = (double)App.Current.Resources["GridSize"];
                    Columns = (int)Math.Floor(_width / gridSize);
                    NotifyPropertyChanged();
                }
            }
        }

        public void UpdateEmotesAsync()
        {
            var updatedLayout = controller.BuildCollection();

                    Emotes = updatedLayout;
        }
    }
}