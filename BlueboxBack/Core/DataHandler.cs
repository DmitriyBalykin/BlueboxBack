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

        public MatrixManager Manager {get; set;}
        public DataHandler()
        {
            Manager = new MatrixManager();
        }
        public void UpdateData(BoxTypes boxType, int x, int y, ActionTypes actionTypes)
        { 
            DataUpdated(this, new DataUpdatedEventArgs(
               Manager.CalculateMatrix(boxType, actionTypes, x, y),
               Manager.GetSolutionMatrix(),
               ResultEvent.ResultType.Unpublished
               ));
        }
        public void Refresh()
        {
            DataUpdated(this, new DataUpdatedEventArgs(
                Manager.GetDataMatrix(),
                Manager.GetSolutionMatrix(),
                ResultEvent.ResultType.Unpublished
                ));
        }
        public void GenerateNewSolution()
        {
            Manager.GenerateNewSolution();
            Refresh();
        }
    }
}