using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace orion.Exceptions
{
    public class ConcractCreationSizeException : ConcractException
    {
        private const string  error = "Ugovor moze sadrati minimalno 1 a maksmalno 3 paketa";

        public ConcractCreationSizeException() : base(error)
        {

        }
    }
}
