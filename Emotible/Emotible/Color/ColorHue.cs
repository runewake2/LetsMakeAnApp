using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emotible.Color
{
    public static class ColorHue
    {
        private const float sqrt3 = 1.73205081f; // Constant value calculation of sqrt of 3
        private const float byteColorToFloatConversion = 0.00392156863f; // 1 over 255
        private const float floatColorToByteConversion = 255.0f;

        // Gets the complimentary color for current color
        public static Windows.UI.Color Compliment(this Windows.UI.Color baseColor)
        {
            float hue = baseColor.GetHue();
            float saturation = baseColor.GetSaturation();
            float brightness = baseColor.GetBrightness();

            // Rotate hue halfway around color wheel
            hue += 180.0f;

            return ColorFromHSB(hue, saturation, brightness, baseColor.A * byteColorToFloatConversion);
        }

        public static Windows.UI.Color ColorFromHSB(float hue, float saturation, float brightness, float alpha = 1.0f)
        {
            hue %= 360; // Limit hue between 0 and 360

            float max, mid, min;
            int sextant;

            if (0.5f < brightness)
            {
                max = brightness - (brightness * saturation) + saturation;
                min = brightness + (brightness * saturation) - saturation;
            }
            else
            {
                max = brightness + (brightness * saturation);
                min = brightness - (brightness * saturation);
            }

            sextant = (int)Math.Floor(hue / 60);
            if (300 <= hue)
            {
                hue -= 360f;
            }

            hue /= 60f;
            hue -= 2f * (float)Math.Floor(((sextant + 1f) % 6f) / 2f);
            if (sextant%2 == 0)
            {
                mid = (hue*(max - min) + min);
            }
            else
            {
                mid = min - (hue * (max - min));
            }

            byte alphaColor = Convert.ToByte(alpha * 255);
            byte maxColor = Convert.ToByte(max * 255);
            byte midColor = Convert.ToByte(mid * 255);
            byte minColor = Convert.ToByte(min * 255);

            switch (sextant)
            {
                case 1:
                    return Windows.UI.Color.FromArgb(alphaColor, minColor, maxColor, minColor);
                case 2:
                    return Windows.UI.Color.FromArgb(alphaColor, minColor, maxColor, midColor);
                case 3:
                    return Windows.UI.Color.FromArgb(alphaColor, minColor, midColor, maxColor);
                case 4:
                    return Windows.UI.Color.FromArgb(alphaColor, midColor, minColor, maxColor);
                case 5:
                    return Windows.UI.Color.FromArgb(alphaColor, maxColor, minColor, midColor);
                default:
                    return Windows.UI.Color.FromArgb(alphaColor, maxColor, midColor, minColor);
            }
        }

        public static float GetHue(this Windows.UI.Color baseColor)
        {
            // Formula source: https://en.wikipedia.org/wiki/Hue
            return (float)Math.Atan2(sqrt3 * (baseColor.G - baseColor.B), 2 * baseColor.R - baseColor.G - baseColor.B) * MathExtensions.Rad2Deg;
        }

        public static float GetSaturation(this Windows.UI.Color baseColor)
        {
            float r = baseColor.R * byteColorToFloatConversion;
            float g = baseColor.G * byteColorToFloatConversion;
            float b = baseColor.B * byteColorToFloatConversion;
            float max = MathExtensions.Max(r, g, b);
            float min = MathExtensions.Min(r, g, b);
            float difference = max - min;
            float luminance = baseColor.GetLuminance();
            return luminance > 0.5 ? difference / (2 - max - min) : difference / (max + min);
        }

        public static float GetBrightness(this Windows.UI.Color baseColor)
        {
            float r = baseColor.R * byteColorToFloatConversion;
            float g = baseColor.G * byteColorToFloatConversion;
            float b = baseColor.B * byteColorToFloatConversion;
            // Formula source: http://www.nbdtech.com/Blog/archive/2008/04/27/Calculating-the-Perceived-Brightness-of-a-Color.aspx
            return (float)Math.Sqrt(r * r * 0.241f +
                                    g * g * 0.691f +
                                    b * b * 0.068f);
        }

        public static float GetLuminance(this Windows.UI.Color baseColor)
        {
            float r = baseColor.R * byteColorToFloatConversion;
            float g = baseColor.G * byteColorToFloatConversion;
            float b = baseColor.B * byteColorToFloatConversion;
            return (MathExtensions.Max(r, g, b) + MathExtensions.Min(r, g, b)) * 0.5f;
}
    }
}
