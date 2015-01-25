using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BlueboxBack.Utilities
{
    class GridDrawer
    {
        Bitmap drawArea;
        public GridDrawer(PictureBox pictureBox)
        {
            drawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = drawArea;
        }

        public void Draw(PictureBox pictureBox)
        {
            if(drawArea == null)
            {
                return;
            }
            Graphics g = Graphics.FromImage(drawArea);

            //TODO implement drawing
            //Draw headers
            //Draw grid

            pictureBox.Image = drawArea;
            g.Dispose();
        }
    }
}
