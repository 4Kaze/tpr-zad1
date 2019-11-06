using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class BookNotUnavailableException : Exception
    {
        public BookNotUnavailableException(StateDescription book) : base(string.Format("Book {0} is not currently borrowed.", book))
        { }
    }
}
