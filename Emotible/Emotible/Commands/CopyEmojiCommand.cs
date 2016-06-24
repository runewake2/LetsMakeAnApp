using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.DataTransfer;
using Emotible.ViewModels;

namespace Emotible.Commands
{
    public class CopyEmojiCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var text = (string)parameter;

            DataPackage copyContent = new DataPackage();
            copyContent.SetText(text);
            Clipboard.SetContent(copyContent);
        }

        public event EventHandler CanExecuteChanged;
    }
}
