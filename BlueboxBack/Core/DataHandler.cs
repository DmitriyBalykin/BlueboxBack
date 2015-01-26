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

        MatrixCalc calc;
        public DataHandler(MatrixCalc calc)
        {
            this.calc = calc;
        }
        public void UpdateData(BoxTypes type, int x, int y)
        { 
            switch(type)
            {
                case BoxTypes.Grid:
                    break;
                case BoxTypes.HeaderHorizontal:
                    break;
                case BoxTypes.HeaderVertical:
                    break;
            }
            DataUpdated(this, new DataUpdatedEventArgs() { Data = calc.CalculateMatrix(type, x, y)});
        }
    }
}
