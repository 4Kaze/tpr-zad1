using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class BookUnavailableException : Exception
    {
        public BookUnavailableException(StateDescription book) : base(string.Format("Book {0} is currently borrowed.", book))
        { }
    }
}
