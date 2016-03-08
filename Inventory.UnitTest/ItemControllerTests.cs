using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventory.Controllers;
using Inventory.Interfaces;
using Inventory.Models;
using Moq;

namespace Inventory.UnitTest
{
    [TestClass]
    public class ItemControllerTests
    {

        [TestMethod]
        public void ItemController_shouldAddToInventoryProvider_whenItemPosted()
        {
            //Arrange
            var mockInventoryProvider = new Mock<IInventoryProvider>();
            mockInventoryProvider.Setup(m => m.AddItem(It.IsAny<Item>())).Verifiable("AddItem was not called on the provider by the controller.");

            var controller = new ItemController(mockInventoryProvider.Object);
            var newItem = new Item() { Label = "FakeItem", Type = "FakeType", Expiration = DateTime.Now.AddHours(10) };

            //Act
            controller.Post(newItem);

            //Assert
            mockInventoryProvider.Verify(m => m.AddItem(It.IsAny<Item>()), Times.Once());

        }

        [TestMethod]
        public void ItemController_shouldRemoveItemFromInventoryProvider_whenItemDeleted()
        {
            //Arrange
            var mockInventoryProvider = new Mock<IInventoryProvider>();
            mockInventoryProvider.Setup(m => m.RemoveItem(It.IsAny<string>())).Verifiable("RemoveItem was not called on the provider by the controller.");

            var controller = new ItemController(mockInventoryProvider.Object);
            var testLabel = "FakeItem";

            //Act
            controller.Delete(testLabel);

            //Assert
            mockInventoryProvider.Verify(m => m.RemoveItem(It.IsAny<string>()), Times.Once());

        }
    }
}
