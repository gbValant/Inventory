using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Interfaces
{
    public interface INotificationProvider
    {
        bool SendNotification(Inventory.Models.Notification notification);
    }
}
