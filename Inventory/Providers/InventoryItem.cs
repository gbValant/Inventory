using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Inventory.Models;

namespace Inventory.Providers
{
    public class InventoryItem
    {

        private int _itemCount;
        public int ItemCount
        {
            get { return _itemCount; }
        }

        public Item Item { get; set; }

        public InventoryItem() { }

        public InventoryItem(int initializeCount)
        {
            _itemCount = initializeCount;
        }

        public void Increment()
        {
            Interlocked.Increment(ref _itemCount);
        }

        public void Decrement()
        {
            Interlocked.Decrement(ref _itemCount);
        }
    }
}