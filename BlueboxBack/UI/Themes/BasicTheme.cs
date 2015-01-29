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
        public static Brush HighlightedFilledBrush = Brushes.DarkCyan;
        public static Brush HighlightedClearedBrush = new SolidBrush(Color.FromArgb(0xff, 0xea, 0xaa));
        public static Brush HeaderBackground = Brushes.LightGray;
        public static Brush HeaderForeground = Brushes.Black;
        public static Pen GridPen = new Pen(Color.FromArgb(0xf0, 0xf0, 0xf0));
    }
}
