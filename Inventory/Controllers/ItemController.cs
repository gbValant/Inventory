using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory.Interfaces;
using Inventory.Models;
using Microsoft.Practices.Unity;

namespace Inventory.Controllers
{
    public class ItemController : ApiController
    {
        private IInventoryProvider _inventoryProvider;

        [InjectionConstructor]
        public ItemController(IInventoryProvider inventoryProvider)
        {
            if (inventoryProvider == null) throw new ArgumentNullException("inventoryProvider");
            _inventoryProvider = inventoryProvider;
        }

        // GET api/item
        public IEnumerable<Item> Get()
        {
            return _inventoryProvider.Items;
        }

        // GET api/item/freshFish
        public string Get(string label)
        {
            throw new NotImplementedException();
        }

        // POST api/item
        public void Post([FromBody]Item value)
        {
            _inventoryProvider.AddItem(value);
        }

        // PUT api/item/freshFish
        public void Put(int id, [FromBody]Item value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/item/freshFish
        public void Delete(string label)
        {
            _inventoryProvider.RemoveItem(label);
        }
    }
}
