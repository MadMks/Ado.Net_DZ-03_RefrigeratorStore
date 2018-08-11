using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_RefrigeratorStore
{

    [Serializable]
    public class NoProductsException : Exception
    {
        public NoProductsException() : this("Недостаточно товаров на складе!") { }
        public NoProductsException(string message) : base(message) { }
        public NoProductsException(string message, Exception inner) : base(message, inner) { }
        protected NoProductsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
