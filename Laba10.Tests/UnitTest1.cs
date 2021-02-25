using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Laba10.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEmptyCtorItem()
        {
            var item = new Item();

            Assert.AreEqual(item.Name, "NoNameItem");
            Assert.AreEqual(item.Price, 0);
        }

        [TestMethod]
        public void TestFullCtorItem()
        {
            var item = new Item(266, "ItemName", 3);

            Assert.AreEqual(item.Name, "ItemName");
            Assert.AreEqual(item.Price, 266);
            Assert.AreEqual(item.id.number, 3);
        }

        [TestMethod]
        public void TestNegativePrice()
        {
            var item = new Item(200);

            item.Price = -1;

            Assert.AreEqual(item.Price, 0);
        }

        [TestMethod]
        public void TestChangegPrice()
        {
            var item = new Item(200);

            item.Price = 400;

            Assert.AreEqual(item.Price, 400);
        }

        [TestMethod]
        public void TestEmptyName()
        {
            var item = new Item("");

            Assert.AreEqual(item.Name, "NoNameItem");
        }

        [TestMethod]
        public void TestChangeName()
        {
            var item = new Item();

            item.Name = "NewName";

            Assert.AreEqual(item.Name, "NewName");
        }

        [TestMethod]
        public void TestInit()
        {
            var item = new Item();

            item = (Item)item.Init();

            Assert.AreNotEqual(item.Name, "NoNameItem");
            Assert.AreNotEqual(item.Name, string.Empty);
            Assert.AreNotEqual(item.Price, 0);
        }

        [TestMethod]
        public void TestItemCount()
        {
            int startCount = Item.count;
            Item[] arr = new Item[5];

            for (int i = 0; i < 5; i++)
            {
                arr[i] = new Item();
                arr[i] = (Item)arr[i].Init();
            }

            // count увеличивается 2 раза, так как new Item() и item.Init() оба создают объекты типа Item
            Assert.AreEqual(Item.count, startCount + 10);
        }

        [TestMethod]
        public void TestItemInheritanceCount()
        {
            int startCount = Item.count;

            var item = new Item();
            var toy = new Toy();
            var prod = new Product();
            var milkProd = new MilkProduct();

            Assert.AreEqual(Item.count, startCount + 4);
        }

        [TestMethod]
        public void TestCompareToMore()
        {
            var item1 = new Item(300);
            var item2 = new Item(299);

            Assert.AreEqual(item1.CompareTo(item2), 1);
        }

        [TestMethod]
        public void TestCompareToLess()
        {
            var item1 = new Item(300);
            var item2 = new Item(299);

            Assert.AreEqual(item2.CompareTo(item1), -1);
        }

        [TestMethod]
        public void TestCompareToEqual()
        {
            var item1 = new Item(300);
            var item2 = new Item(300);

            Assert.AreEqual(item1.CompareTo(item2), 0);
        }

        [TestMethod]
        public void TestExplicitString()
        {
            var item = new Item(300, "ItemName");

            Assert.AreEqual((string)item, "Price: 300 rub\nName: ItemName");
        }

        [TestMethod]
        public void TestGetAllNames()
        {
            Item[] arr = new Item[5];

            for (int i = 0; i < 5; i++)
            {
                arr[i] = new Item();
                arr[i] = (Item)arr[i].Init();
            }

            string[] names = { arr[0].Name, arr[1].Name, arr[2].Name, arr[3].Name, arr[4].Name };
            string[] allNames = Item.GetAllNames(arr);

            Assert.AreEqual(names.Length, allNames.Length);

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(names[i], allNames[i]);
            }
        }

        [TestMethod]
        public void TestGetAllUniqueNames()
        {
            Item[] arr = new Item[5];

            for (int i = 0; i < 3; i++)
            {
                arr[i] = new Item();
            }

            arr[3] = new Item("NewItem4");
            arr[4] = new Item("NewItem5");

            string[] names = { arr[0].Name, arr[3].Name, arr[4].Name };
            string[] uniqueNames = Item.GetAllUniqueNames(arr);

            Assert.AreEqual(names.Length, uniqueNames.Length);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(names[i], uniqueNames[i]);
            }
        }

        [TestMethod]
        public void TestCountItems()
        {
            Item[] arr = new Item[5];

            for (int i = 0; i < 3; i++)
            {
                arr[i] = new Item();
            }

            arr[3] = new Item("NewItem4");
            arr[4] = new Item("NewItem5");


            Assert.AreEqual(Item.CountItems(arr, "NoNameItem"), 3);
            Assert.AreEqual(Item.CountItems(arr, "XXX"), 0);
        }

        [TestMethod]
        public void TestGetTotalCost()
        {
            Item[] arr = new Item[5];

            arr[0] = new Item(250);
            arr[1] = new Item(300);
            arr[2] = new Item(350);
            arr[3] = new Item("NewItem4");
            arr[4] = new Item("NewItem5");


            Assert.AreEqual(Item.GetTotalCost(arr, "NoNameItem"), 900);
            Assert.AreEqual(Item.GetTotalCost(arr, "XXX"), -1);
            Assert.AreEqual(Item.GetTotalCost(arr, "NewItem4"), 0);
        }
    }
}
