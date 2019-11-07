using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class ItemAlreadyExistsException : Exception
    {
        public ItemAlreadyExistsException(object item, IEnumerable collection) : base(string.Format("Item with the same code as {0} already exists in {1}", item, collection))
        {

        }
    }
}
