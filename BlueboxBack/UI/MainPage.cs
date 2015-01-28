using BlueboxBack.Core;
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
        DataHandler dataHandler;

        public MainPage()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            dataHandler = new DataHandler();

            Box leftHeaderBox = new Box(BoxTypes.HeaderVertical, dataHandler, Constants.MATRIX_HEIGHT * Constants.CELL_SIDE);
            Box topHeaderBox = new Box(BoxTypes.HeaderHorizontal, dataHandler, Constants.MATRIX_WIDTH * Constants.CELL_SIDE);
            Box gridBox = new Box(BoxTypes.Grid, dataHandler, Constants.MATRIX_WIDTH * Constants.CELL_SIDE, Constants.MATRIX_HEIGHT * Constants.CELL_SIDE);

            layoutPanel.Controls.Add(topHeaderBox, 1, 0);
            layoutPanel.Controls.Add(leftHeaderBox, 0, 1);
            layoutPanel.Controls.Add(gridBox, 1, 1);

            dataHandler.Refresh();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
