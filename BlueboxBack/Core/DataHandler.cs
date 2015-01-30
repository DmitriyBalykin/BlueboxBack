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

        MatrixManager manager;
        public DataHandler()
        {
            this.manager = new MatrixManager();
        }
        public void UpdateData(BoxTypes boxType, int x, int y, ActionTypes actionTypes)
        { 
            DataUpdated(this, new DataUpdatedEventArgs() {
                Data = manager.CalculateMatrix(boxType, actionTypes, x, y),
                Solution = manager.GetSolutionMatrix()
            });
        }
        public void Refresh()
        {
            DataUpdated(this, new DataUpdatedEventArgs() {
                Data = manager.GetDataMatrix(),
                Solution = manager.GetSolutionMatrix()
            });
        }
        public void GenerateNewSolution()
        {
            manager.GenerateNewSolution();
            Refresh();
        }
    }
}