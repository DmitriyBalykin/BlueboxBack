using BlueboxBack.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BlueboxBack.UI.Components
{
    class Box : PictureBox
    {
        MatrixCalc calc;
        Boxs type;
        public Box(Boxs type, MatrixCalc calc)
        {
            InitializeBox(type, calc);

            this.type = type;
            this.calc = calc;

            Click += Box_Click;
        }

        private void InitializeBox(Boxs type, MatrixCalc calc)
        {
            throw new NotImplementedException();
        }

        void Box_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = e as MouseEventArgs;
            if(args != null)
            {
                calc.CalculateMatrix(args.X, args.Y, type);
                updateBox(calc);
            }
        }

        private void updateBox(MatrixCalc calc)
        {
            GridDrawer
        }
    }
}
