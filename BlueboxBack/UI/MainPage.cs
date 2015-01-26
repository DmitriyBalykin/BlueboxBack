using BlueboxBack.UI.Components;
using BlueboxBack.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BlueboxBack.UI
{
    public partial class MainPage : Form
    {
        MatrixCalc calc = new MatrixCalc();
        public MainPage()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            calc = new MatrixCalc();

            Box leftHeaderBox = new Box(Boxs.HeaderVertical, calc);
            Box topHeaderBox = new Box(Boxs.HeaderHorizontal, calc);
            Box gridBox = new Box(Boxs.Grid, calc);

            layoutPanel.Controls.Add(topHeaderBox, 1, 0);
            layoutPanel.Controls.Add(leftHeaderBox, 0, 1);
            layoutPanel.Controls.Add(gridBox, 1, 1);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
