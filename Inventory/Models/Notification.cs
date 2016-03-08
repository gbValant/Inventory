using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class Notification
    {
        public Item Item { get; set; }

        public NotificationTypes Type { get; set; }

        public enum NotificationTypes
        {
            ItemRemoved,
            ItemExpired
        }

    }
}