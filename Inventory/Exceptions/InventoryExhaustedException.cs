using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Exceptions
{
    public class InventoryExhaustedException : Exception
    {
        public InventoryExhaustedException()
        {
        }

        public InventoryExhaustedException(string message)
            : base(message)
        {
        }

        public InventoryExhaustedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}