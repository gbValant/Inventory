using System;
using System.Linq;
using Inventory.Interfaces;
using Inventory.Models;
using Inventory.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Inventory.UnitTest
{
    [TestClass]
    public class InventoryProviderTests
    {
        [TestMethod]
        public void InventoryProvider_shouldAddItemToInventory_whenFirstItemAdded()
        {
            //Arrange
            var mockNotificationProvider = new Mock<INotificationProvider>();
            mockNotificationProvider.Setup(m => m.SendNotification(It.IsAny<Notification>())).Returns(true);

            var inventoryProvider = new InventoryProvider(mockNotificationProvider.Object);

            //Act
            var testLabel = "FakeItemAdd";
            var testItem = new Item() { Label = testLabel, Type = "FakeType", Expiration = DateTime.Now.AddHours(10) };
            inventoryProvider.AddItem(testItem);
            

            //Assert
            Assert.AreEqual(1, inventoryProvider.Items.Count());

        }

        [TestMethod]
        public void InventoryProvider_shouldRemoveItemAndSendNotification_whenRemoveIsCalled()
        {
            //Arrange
            var mockNotificationProvider = new Mock<INotificationProvider>();
            mockNotificationProvider.Setup(m => m.SendNotification(It.IsAny<Notification>())).Returns(true).Verifiable("SendNotification did not happen as expected.");

            var inventoryProvider = new InventoryProvider(mockNotificationProvider.Object);

            var testLabel = "FakeItemRemove";
            var testItem = new Item(){Label = testLabel, Type = "FakeType", Expiration = DateTime.Now.AddHours(10)};
            inventoryProvider.AddItem(testItem);
            Assert.AreEqual(1,inventoryProvider.Items.Count<Item>(i => i.Label == "FakeItemRemove"));

            //Act
            inventoryProvider.RemoveItem(testLabel);

            //Assert
            Assert.AreEqual(0, inventoryProvider.Items.Count<Item>(i => i.Label == "FakeItemRemove"));
            mockNotificationProvider.Verify(m => m.SendNotification(It.IsAny<Notification>()));
        }
    }
}
