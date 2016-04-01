using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emotible.Color
{
    public static class MathExtensions
    {
        // Convert radians to degrees
        public const float Rad2Deg = (float)(180.0f / Math.PI);

        // Convert degrees to radians
        public const float Deg2Rad = (float)(Math.PI / 180.0f);

        public static TValue Max<TValue>(params TValue[] values) where TValue : IComparable
        {
            return values.Max();
        }

        public static TValue Min<TValue>(params TValue[] values) where TValue : IComparable
        {
            return values.Min();
        }
    }
}
