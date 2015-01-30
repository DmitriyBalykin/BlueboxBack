using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Core
{
    class DataUpdatedEventArgs : EventArgs
    {
        public DataMatrix Data {get; set;}
        public DataMatrix Solution { get; set; }

        public ResultEvent.ResultType Result { get; set; }

        public DataUpdatedEventArgs(DataMatrix data, DataMatrix solution, ResultEvent.ResultType result)
        {
            Data = data;
            Solution = solution;
            Result = result;
        }
    }
}
