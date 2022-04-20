using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Demo.Helpers
{
    public static class ColorHelper
    {
        static Random rnd = new Random();

        public static Color GetRandomColor()
        {
            return Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
    }
}
