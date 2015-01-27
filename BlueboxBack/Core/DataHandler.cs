using BlueboxBack.UI.Components;
using BlueboxBack.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Core
{
    class DataHandler
    {
        public event EventHandler<DataUpdatedEventArgs> DataUpdated;

        MatrixManager calc;
        public DataHandler()
        {
            this.calc = new MatrixManager();
        }
        public void UpdateData(BoxTypes boxType, int x, int y, ActionTypes actionTypes)
        { 
            switch(boxType)
            {
                case BoxTypes.Grid:
                    break;
                case BoxTypes.HeaderHorizontal:
                    break;
                case BoxTypes.HeaderVertical:
                    break;
            }
            DataUpdated(this, new DataUpdatedEventArgs() { Data = calc.CalculateMatrix(boxType, actionTypes, x, y)});
        }
    }
}