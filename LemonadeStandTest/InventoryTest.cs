using System;
using System.IO;
using LemonadeStand;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonadeStandTest
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void Inventory_BackStock_Count()
        {
            // arrange
            Inventory MyInventory = new Inventory();
            int expectedResult = 4;
            // act
            int actualResult = MyInventory.BackStock.Count;
            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        public void Inventory_Recipe_Count()
        {
            // arrange
            Inventory MyInventory = new Inventory();
            int expectedResult = 3;
            // act
            int actualResult = MyInventory.PitcherRecipe.Count;
            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        public void Add_Quantity_Of_Item_To_Inventory()
        {
            // arrange
            Inventory MyInventory = new Inventory();
            string itemName = "Lemons";
            double amount = 50;
            double expectedResult = 50;
            // act
            MyInventory.AddToInventory(itemName, amount);
            double actualResult = MyInventory.BackStock[0].Quantity;
            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Return_Bool_For_Enough_Money()
        {
            // arrange
            Inventory MyInventory = new Inventory();
            double price = 40;
            MyInventory.Money = 30;
            bool expectedResult = false;
            // act
            bool actualResult = MyInventory.MoneyValidator(price);
            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Remove_Correct_Double_From_Money()
        {
            // arrange
            Inventory MyInventory = new Inventory();
            string itemName = "Ice";
            double price = 20;
            int quantity = 4;
            MyInventory.Money = 100;
            double expectedResult = 20;
            // act
            MyInventory.PayForItem(itemName, price, quantity);
            double actualResult = MyInventory.Money;
            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Validate_Double_Between_Values()
        {
            // arrange
            Inventory MyInventory = new Inventory();
            double cost = 2.60;
            bool expectedResult = false;

            // act
            bool actualResult = MyInventory.PriceValidator(cost);
            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Price_Sets_Between_Values()
        {
            // arrange
            Inventory MyInventory = new Inventory();
            double expectedResult = 2.25;
            string input = "2.25";
            StringReader stringRead = new StringReader(input);
            Console.SetIn(stringRead);

            // act
            MyInventory.PricePerCupBuilder();
            double actualResult = MyInventory.PricePerCup;
            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Return_bool_For_Total_Against_BackstockQuantity()
        {
            // arrange
            Inventory MyInventory = new Inventory();
            MyInventory.BackStock[0].Quantity = 10;
            double amount = 15;
            int indexValue = 0;
            bool expectedResult = false;

            // act
            bool actualResult = MyInventory.ValidateAmount(amount, indexValue);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }



    }
}
