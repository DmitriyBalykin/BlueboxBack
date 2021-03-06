﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BlueboxBack.UI.Themes
{
    struct BasicTheme
    {
        public static Brush UndefinedBrush = new SolidBrush(Color.FromArgb(0xc0, 0xc0, 0xc0));
        public static Brush FilledBrushDefault = Brushes.Blue;
        public static Brush FilledBrushCorrectResult = Brushes.Green;
        public static Brush FilledBrushIncorrectResult = Brushes.Red;
        public static Brush FilledBrushAlternativeResult = Brushes.Orange;
        public static Brush ClearedBrush = Brushes.White;
        public static Brush HighlightedFilledBrush = Brushes.DarkCyan;
        public static Brush HighlightedClearedBrush = new SolidBrush(Color.FromArgb(0xff, 0xea, 0xaa));
        public static Brush HeaderBackground = Brushes.LightGray;
        public static Brush HeaderForeground = Brushes.Black;
        public static Pen GridPen = new Pen(Color.FromArgb(0xf0, 0xf0, 0xf0), 1);
        public static Pen GridPenThich = new Pen(Color.FromArgb(0xff, 0xff, 0xff), 2);
        public static Font HeaderFont = SystemFonts.MenuFont;
        public static Brush HeaderBrush = Brushes.Black;
        public static Brush HeaderBrushHighlighted = Brushes.Orange;
        public static Font HeaderFontHighlighted = new Font(HeaderFont, FontStyle.Bold);
    }
}
