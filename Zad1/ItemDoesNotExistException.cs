using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class ItemDoesNotExistException: Exception
    {
        public ItemDoesNotExistException(object item, IEnumerable collection): base(string.Format("Item {0} does not exist in {1}", item, collection))
        {

        }

        public ItemDoesNotExistException(object item): base(string.Format("Item {0} does not exist.", item))
        {

        }

        public ItemDoesNotExistException(long key, IEnumerable collection) : base(string.Format("Item with key {0} does not exist in {1}", key, collection))
        {

        }
    }
}
