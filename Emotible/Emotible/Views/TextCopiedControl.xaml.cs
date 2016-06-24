using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class TextCopiedControl : UserControl
    {
        public static readonly DependencyProperty CopiedStringProperty = DependencyProperty.Register(
            nameof(CopiedString), typeof (string), typeof (TextCopiedControl), new PropertyMetadata(default(string)));

        public string CopiedString
        {
            get { return (string) GetValue(CopiedStringProperty); }
            set { SetValue(CopiedStringProperty, value); }
        }

        public TextCopiedControl()
        {
            this.InitializeComponent();
        }

        private void OnAnimationCompleted(object sender, object e)
        {
            var panel = this.Parent as Panel;
            panel?.Children.Remove(this);
        }
    }
}
