using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace orion.Exceptions
{
    public abstract class ConcractException : Exception
    {
        public string Error{get;set;}

        public ConcractException(string error)
        {
            Error = error;
        }
    }
}
