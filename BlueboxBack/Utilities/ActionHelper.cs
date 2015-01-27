using BlueboxBack.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BlueboxBack.Utilities
{
    class ActionHelper
    {
        public static ActionTypes ResolveAction(MouseButtons clickedButton)
        {
            switch(clickedButton)
            {
                case MouseButtons.Left:
                    return ActionTypes.Main;
                case MouseButtons.Right:
                    return ActionTypes.Alter;
                case MouseButtons.Middle:
                    return ActionTypes.Medium;
                default:
                    return ActionTypes.Undefined;
            }
        }
    }
}
