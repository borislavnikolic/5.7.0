
using System;


namespace orion.Exceptions
{
    public class UserExistsException : ConcractException
    {
        private const string error = "Korisnik ve ima aktivan ugovor";

        public int Id { get; set; }
        public UserExistsException(int id) :base(error)
        {
            Id = id;
        }
    }
}
