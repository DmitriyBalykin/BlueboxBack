using BlueboxBack.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BlueboxBack.UI
{
    class GridDrawer
    {

        public static void Draw(PictureBox pictureBox, DataMatrix matrix)
        {
            Bitmap drawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = drawArea;

            Graphics g = Graphics.FromImage(drawArea);

            //TODO implement drawing
            //Draw headers
            //Draw grid

            pictureBox.Image = drawArea;
            g.Dispose();
        }
    }
}
