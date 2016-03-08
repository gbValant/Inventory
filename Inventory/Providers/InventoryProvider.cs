using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Web;
using Inventory.Models;
using Inventory.Interfaces;
using System.Threading;
using Inventory.Exceptions;

namespace Inventory.Providers
{
    public class InventoryProvider : IInventoryProvider
    {
        private INotificationProvider _notificationProvider;

        public InventoryProvider(INotificationProvider notificationProvider)
        {
            if (notificationProvider == null) throw new ArgumentException("A notification provider is required to initialize this InventoryProvider.");

            _notificationProvider = notificationProvider;
        }



        private static ConcurrentDictionary<string, InventoryItem> itemStore = new ConcurrentDictionary<string, InventoryItem>();

        public IEnumerable<Item> Items {
            get { return itemStore.Where(ii => ii.Value.ItemCount > 0).Select(ii => ii.Value.Item); }
        }

        public void AddItem(Item item)
        {
            itemStore.AddOrUpdate(item.Label, 
                (k) => { var addInventory = new InventoryItem() { Item = item }; addInventory.Increment(); return addInventory; }, 
                (k, v) => { v.Increment(); return v; });
        }

        public void RemoveItem(string label)
        {
            //TODO: This should probably be a TryUpdate and if that fails, throw a custom exception that triggers a Conflict in the API,
            //      But I'm assuming that a thread-safe datastore is not the central objective here.
            InventoryItem currentInventoryItem;
            if (itemStore.TryGetValue(label, out currentInventoryItem) && itemStore[label].ItemCount > 0)
            {
                itemStore[label].Decrement();
                _notificationProvider.SendNotification(new Notification() { Item = currentInventoryItem.Item, Type = Notification.NotificationTypes.ItemRemoved });
            }
            else
            {
                throw new InventoryExhaustedException();
            }

        }

    }
}