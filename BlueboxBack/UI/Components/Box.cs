using BlueboxBack.Core;
using BlueboxBack.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BlueboxBack.UI.Components
{
    class Box : PictureBox
    {
        private bool MousePressed = false;

        DataHandler dataHandler;
        public BoxTypes type;
        public Box(BoxTypes boxType, DataHandler dataHandler, int actualSizing)
        {
            InitializeBox(boxType, dataHandler);
            SetSize(boxType, actualSizing);
        }
        public void SetSize(BoxTypes boxType, int size)
        {
            InitializeBox(boxType, dataHandler);
            switch (boxType)
            {
                case BoxTypes.HeaderHorizontal:
                    Width = size;
                    Height = Constants.HEADER_SIZING;
                    break;
                case BoxTypes.HeaderVertical:
                    Width = Constants.HEADER_SIZING;
                    Height = size;
                    break;
                case BoxTypes.Grid:
                    Width = size;
                    Height = size;
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

        private void InitializeBox(BoxTypes type, DataHandler dataHandler)
        {
            this.type = type;
            this.dataHandler = dataHandler;

            Click += Box_Click;
            MouseDown += Box_MouseDown;
            MouseUp += Box_MouseUp;
            MouseMove += Box_MouseMove;
            dataHandler.DataUpdated += dataHandler_DataUpdated;

            dataHandler.Manager.ResultPublished += Manager_ResultPublished;
        }

        void Manager_ResultPublished(object sender, EventArgs e)
        {
            DataUpdatedEventArgs args = e as DataUpdatedEventArgs;
            if (args != null)
            {
                Drawer.Draw(this, args.Data, args.Solution, args.Result);
            }
        }

        void Box_MouseMove(object sender, MouseEventArgs e)
        {
            MouseEventArgs args = e as MouseEventArgs;
            if (MousePressed && args != null)
            {
                dataHandler.UpdateData(type, args.X, args.Y, ActionHelper.ResolveAction(args.Button));
            }
        }

        void Box_MouseUp(object sender, MouseEventArgs e)
        {
            MousePressed = false;
        }

        void Box_MouseDown(object sender, MouseEventArgs e)
        {
            MousePressed = true;
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
