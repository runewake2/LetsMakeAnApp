using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emotible.ViewModels
{
    internal class EmoteViewModel : BaseViewModel, IEmoteViewModel, ISizableControl
    {
        private string _name;
        private string _text;
        private int _width;
        private int _height;

        public string Name
        {
            get { return _name; }
            set {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int Width
        {
            get { return _width; }
            set
            {
                if (_width != value)
                {
                    _width = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                if (_height != value)
                {
                    _height = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
