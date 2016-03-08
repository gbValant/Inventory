using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Models;

namespace Inventory.Interfaces
{
    public interface IInventoryProvider
    {
        void AddItem(Item item);
        void RemoveItem(string label);
        IEnumerable<Item> Items { get; }
    }
}
