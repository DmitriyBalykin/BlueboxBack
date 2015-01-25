using BlueboxBack.Core;
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
        ClickHandler clickHandler;
        public MainPage()
        {
            InitializeComponent();

            clickHandler = new ClickHandler();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = e as MouseEventArgs;
            if (args == null)
            {
                return;
            }
            clickHandler.Handle(args.X, args.Y);
        }
    }
}
