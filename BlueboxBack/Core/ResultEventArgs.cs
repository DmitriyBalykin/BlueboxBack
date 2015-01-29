using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Core
{
    class ResultEventArgs : EventArgs
    {
        public enum ResultTypes
        { 
            Correct,
            Incorrect
        }

        public ResultTypes Result { get; set; }
    }
}
