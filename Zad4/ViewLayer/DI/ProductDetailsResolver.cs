using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewLayer.DI
{
    class ProductDetailsResolver : IWindowResolver
    {
        public IOperationWindow GetWindow()
        {
            return new ProductDetailsWindow();
        }
    }
}
