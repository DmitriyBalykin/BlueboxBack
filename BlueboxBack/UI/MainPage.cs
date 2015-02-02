using BlueboxBack.Core;
using BlueboxBack.Properties;
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
        Box leftHeaderBox;
        Box topHeaderBox;
        Box gridBox;
        public MainPage()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            dataHandler = new DataHandler();

            leftHeaderBox = new Box(BoxTypes.HeaderVertical, dataHandler, Settings.Default.MatrixSize * Constants.CELL_SIDE);
            leftHeaderBox.SizeMode = PictureBoxSizeMode.AutoSize;
            topHeaderBox = new Box(BoxTypes.HeaderHorizontal, dataHandler, Settings.Default.MatrixSize * Constants.CELL_SIDE);
            topHeaderBox.SizeMode = PictureBoxSizeMode.AutoSize;
            gridBox = new Box(BoxTypes.Grid, dataHandler, Settings.Default.MatrixSize * Constants.CELL_SIDE, Settings.Default.MatrixSize * Constants.CELL_SIDE);
            gridBox.SizeMode = PictureBoxSizeMode.AutoSize;

            layoutPanel.Controls.Add(topHeaderBox, 1, 0);
            layoutPanel.Controls.Add(leftHeaderBox, 0, 1);
            layoutPanel.Controls.Add(gridBox, 1, 1);

            dataHandler.Refresh();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataHandler.GenerateNewSolution();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Dispose();
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.MatrixSize = Constants.MATRIX_SIZE_EASY;
            dataHandler.GenerateNewSolution();
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.MatrixSize = Constants.MATRIX_SIZE_MEDIUM;
            dataHandler.GenerateNewSolution();
        }

        private void difficultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.MatrixSize = Constants.MATRIX_SIZE_MASTER;
            dataHandler.GenerateNewSolution();
        }
    }
}
