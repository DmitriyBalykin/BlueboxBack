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
        Label hintsLeftLabel;
        public MainPage()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            dataHandler = new DataHandler();
            hintsLeftLabel = new Label();
            hintsLeftLabel.Margin = new System.Windows.Forms.Padding(5, Constants.HEADER_SIZING/2 - 5, 0, 0);
            hintsLeftLabel.Width = Constants.HEADER_SIZING;

            leftHeaderBox = new Box(BoxTypes.HeaderVertical, dataHandler, Settings.Default.MatrixSize * Constants.CELL_SIDE);
            leftHeaderBox.SizeMode = PictureBoxSizeMode.AutoSize;
            topHeaderBox = new Box(BoxTypes.HeaderHorizontal, dataHandler, Settings.Default.MatrixSize * Constants.CELL_SIDE);
            topHeaderBox.SizeMode = PictureBoxSizeMode.AutoSize;
            gridBox = new Box(BoxTypes.Grid, dataHandler, Settings.Default.MatrixSize * Constants.CELL_SIDE, Settings.Default.MatrixSize * Constants.CELL_SIDE);
            gridBox.SizeMode = PictureBoxSizeMode.AutoSize;

            layoutPanel.Controls.Add(hintsLeftLabel, 0, 0);
            layoutPanel.Controls.Add(topHeaderBox, 1, 0);
            layoutPanel.Controls.Add(leftHeaderBox, 0, 1);
            layoutPanel.Controls.Add(gridBox, 1, 1);

            dataHandler.Refresh();

            dataHandler.Manager.HintUsed += Manager_HintUsed;
            UpdateHintsLeftText(dataHandler.Manager.HintsLeft);
        }

        void Manager_HintUsed(object sender, EventArgs e)
        {
            HintUsedEventArgs args = e as HintUsedEventArgs;
            if(args != null)
            {
                UpdateHintsLeftText(args.HintsLeft);
            }
        }
        void UpdateHintsLeftText(int hintsLeft)
        {
            if(Settings.Default.ShowLines)
            {
                hintsLeftLabel.Text = String.Format("Осталось подсказок: {0}", hintsLeft);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataHandler.GenerateNewSolution();
            UpdateHintsLeftText(dataHandler.Manager.HintsLeft);
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Dispose();
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.MatrixSize = Constants.MATRIX_SIZE_EASY;
            Settings.Default.IsEasyGame = !Settings.Default.IsEasyGame;
            Settings.Default.IsMediumGame = false;
            this.mediumToolStripMenuItem.Checked = false;
            Settings.Default.IsHardGame = false;
            this.difficultToolStripMenuItem.Checked = false;
            dataHandler.GenerateNewSolution();
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.MatrixSize = Constants.MATRIX_SIZE_MEDIUM;
            Settings.Default.IsEasyGame = false;
            this.easyToolStripMenuItem.Checked = false;
            Settings.Default.IsMediumGame = !Settings.Default.IsMediumGame;
            Settings.Default.IsHardGame = false;
            this.difficultToolStripMenuItem.Checked = false;
            dataHandler.GenerateNewSolution();
        }

        private void difficultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.MatrixSize = Constants.MATRIX_SIZE_MASTER;
            Settings.Default.IsEasyGame = false;
            this.easyToolStripMenuItem.Checked = false;
            Settings.Default.IsMediumGame = false;
            this.mediumToolStripMenuItem.Checked = false;
            Settings.Default.IsHardGame = !Settings.Default.IsHardGame;
            dataHandler.GenerateNewSolution();
        }
        private void showLinesToolStripMenuItem_CheckedChanged(object sender, System.EventArgs e)
        {
            Settings.Default.ShowLines = !Settings.Default.ShowLines;
            hintsLeftLabel.Visible = Settings.Default.ShowLines;
            dataHandler.Refresh();
        }
        private void highlightHeadersToolStripMenuItem_CheckedChanged(object sender, System.EventArgs e)
        {
            Settings.Default.HighlightHeaders = !Settings.Default.HighlightHeaders;
            dataHandler.Refresh();
        }
    }
}
