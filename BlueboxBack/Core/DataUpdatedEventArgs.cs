using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Core
{
    class DataUpdatedEventArgs : EventArgs
    {
        public Matrix Data {get; set;}
    }
}
