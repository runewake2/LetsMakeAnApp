using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Emotible.Views
{
    public sealed partial class EmoteControl : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text), typeof (string), typeof (EmoteControl), new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            nameof(Command), typeof (ICommand), typeof (EmoteControl), new PropertyMetadata(default(ICommand)));

        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public EmoteControl()
        {
            this.InitializeComponent();
            TileEnterStoryboard.Begin();
        }

        public Size MeasureString(string text)
        {
            emoteText.Text = text;
            emoteText.Measure(Size.Empty);
            return new Size(emoteText.ActualWidth, emoteText.ActualHeight);
        }
    }
}
