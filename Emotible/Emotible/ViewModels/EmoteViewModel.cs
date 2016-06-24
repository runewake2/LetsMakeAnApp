using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Emotible.Commands;

namespace Emotible.ViewModels
{
    public class EmoteViewModel : BaseViewModel, IEmoteViewModel, ISizableControl
    {
        private int _id;
        private string _name;
        private string _text;
        private ICommand _command = new CopyEmojiCommand();
        private double _width;
        private double _height;
        private int _columnSpan;
        private int _rowSpan;
        private int _timesUsed;

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged();
                }
            }
        }

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

        public ICommand Command => _command;

        public double Width
        {
            get { return _width; }
            set
            {
                if (_width != value)
                {
                    _width = value;
                    NotifyPropertyChanged();
                    UpdateColumns();
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
                    UpdateRows();
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

        public int TimesUsed
        {
            get { return _timesUsed; }
            set
            {
                if (_timesUsed != value)
                {
                    _timesUsed = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void UpdateRows()
        {
            var gridSize = (double)App.Current.Resources["GridSize"];
            var sizeReduce = (double)App.Current.Resources["SizeReduction"];
            RowSpan = (int)Math.Ceiling((Height + sizeReduce) / gridSize);
        }

        private void UpdateColumns()
        {
            var gridSize = (double)App.Current.Resources["GridSize"];
            var sizeReduce = (double)App.Current.Resources["SizeReduction"];
            ColumnSpan = (int)Math.Ceiling((Width + sizeReduce) / gridSize);
        }
    }
}
