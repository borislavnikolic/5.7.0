using System;
using System.Collections.Generic;
using System.Text;

namespace orion.Exceptions
{
    public class ConcractCreationTypeException : ConcractException
    {
        private const string error = "Ne smete uzeti vise paketa iste vrste";

        public ConcractCreationTypeException() : base(error)
        {

        }
    }
}
