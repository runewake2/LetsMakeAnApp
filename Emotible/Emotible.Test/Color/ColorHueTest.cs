using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.SpeechRecognition;
using Windows.UI;
using Emotible.Color;
using Xunit;

namespace Emotible.Test.Color
{
    public class ColorHueTest
    {
        [Theory]
        [InlineData(255, 0, 0, 0, 255, 0)] // Red/Green compliment
        [InlineData(0, 255, 0, 255, 0, 0)] // inverse Green/Red compliment

        public void ColorComplimentTest(int r, int g, int b, int expectedR, int expectedG, int expectedB)
        {
            var color = Windows.UI.Color.FromArgb((byte)255, (byte)r, (byte)g, (byte)b);
            var expectedCompliment = Windows.UI.Color.FromArgb((byte)255, (byte)expectedR, (byte)expectedG, (byte)expectedB);
            var calculatedCompliment = color.Compliment();
            Assert.Equal(expectedCompliment, calculatedCompliment);
        }
    }
}
