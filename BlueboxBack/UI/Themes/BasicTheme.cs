using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BlueboxBack.UI.Themes
{
    struct BasicTheme
    {
        public static Brush UndefinedBrush = new SolidBrush(Color.FromArgb(0xc0, 0xc0, 0xc0));
        public static Brush FilledBrush = Brushes.Blue;
        public static Brush ClearedBrush = Brushes.White;
        public static Brush HighlightedFilledBrush = Brushes.LightCyan;
        public static Brush HighlightedClearedBrush = Brushes.LightPink;
        public static Brush HeaderBackground = Brushes.LightGray;
        public static Brush HeaderForeground = Brushes.Black;
        public static Pen GridPen = new Pen(Color.FromArgb(0xf0, 0xf0, 0xf0));
    }
}
