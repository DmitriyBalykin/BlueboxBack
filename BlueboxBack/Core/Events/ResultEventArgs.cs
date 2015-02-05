using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Core
{
    class ResultEvent
    {
        public enum ResultType
        { 
            Correct,
            Incorrect,
            Alternative,
            Unpublished
        }
        public ResultEvent(ResultType result)
        {
            Result = result;
        }
        public ResultType Result { get; set; }
    }
}
