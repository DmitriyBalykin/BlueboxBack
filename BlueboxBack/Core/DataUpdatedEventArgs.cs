using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Core
{
    class DataUpdatedEventArgs : EventArgs
    {
        public DataMatrix Data {get; set;}
    }
}
