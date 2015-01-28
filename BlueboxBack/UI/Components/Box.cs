﻿using BlueboxBack.Core;
using BlueboxBack.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BlueboxBack.UI.Components
{
    class Box : PictureBox
    {
        DataHandler dataHandler;
        public BoxTypes type;
        public Box(BoxTypes type, DataHandler dataHandler, int width, int height)
        {
            InitializeBox(type, dataHandler, width, height);
        }

        public Box(BoxTypes boxType, DataHandler dataHandler, int actualSizing)
        {
            switch (boxType)
            { 
                case BoxTypes.HeaderHorizontal:
                    InitializeBox(boxType, dataHandler, actualSizing, Constants.HEADER_SIZING);
                    break;
                case BoxTypes.HeaderVertical:
                    InitializeBox(boxType, dataHandler, Constants.HEADER_SIZING, actualSizing);
                    break;
            }
        }

        void dataHandler_DataUpdated(object sender, EventArgs e)
        {
            DataUpdatedEventArgs args = e as DataUpdatedEventArgs;
            if(args != null)
            {
                Drawer.Draw(this, args.Data, args.Solution);
            }
        }

        private void InitializeBox(BoxTypes type, DataHandler dataHandler, int width, int height)
        {
            this.type = type;
            this.dataHandler = dataHandler;

            Click += Box_Click;
            dataHandler.DataUpdated += dataHandler_DataUpdated;

            Width = width + 1;
            Height = height + 1;
        }

        void Box_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = e as MouseEventArgs;
            if(args != null)
            {
                dataHandler.UpdateData(type, args.X, args.Y, ActionHelper.ResolveAction(args.Button));
            }
        }
    }
}
