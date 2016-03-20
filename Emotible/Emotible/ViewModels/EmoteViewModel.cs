using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emotible.ViewModels
{
    public class EmoteViewModel : BaseViewModel, IEmoteViewModel, ISizableControl
    {
        private string _name;
        private string _text;
        private double _width;
        private double _height;
        private int _columnSpan;
        private int _rowSpan;

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

        public double Width
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

        public double Height
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

        public int ColumnSpan
        {
            get { return _columnSpan; }
            set
            {
                if (_columnSpan != value)
                {
                    _columnSpan = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int RowSpan
        {
            get { return _rowSpan; }
            set
            {
                if (_rowSpan != value)
                {
                    _rowSpan = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
