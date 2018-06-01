using System;
using LemonadeStand;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonadeStandTest
{
    [TestClass]
    public class StoreTest
    {
        [TestMethod]
        public void Validate_String_Is_Integer_Return_Bool()
        {
            // arrange
            Store MyStore = new Store();
            string input = "cheese";
            bool expectedResult = false;
            // act
            bool actualResult = MyStore.StringIntValidator(input);
            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Multiply_Product_Item_Price_By_Amount_Return_Double()
        {
            // arrange
            Store myStore = new Store();
            Products myProduct = new Products();
            double quantity = 2;
            myProduct.Price = 2;
            double expectedResult = 4;

            // act
            double actualResult = myStore.CalculatePurchasePrice(quantity, myProduct);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Validate_Input_In_Stock_List()
        {
            // arrange
            Store myStore = new Store();
            string input = "5";
            bool expectedResult = false;

            //act
            bool actualResult = myStore.PurchaseValidator(input);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Parse_Validated_String_To_Integer_Return_Int()
        {
            // arrange
            Store myStore = new Store();
            string input = "5";
            int expectedResult = 5;

            // act
            int actualResult = myStore.StringToInt(input);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Validate_String_Equals_PositiveInt_InRange()
        {
            // arrange
            Store MyStore = new Store();
            string input = "8";
            int length = 8;
            bool expectedResult = true;
            // act
            bool actualResult = MyStore.StringMenuValidator(input, length);
            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Get_Stock_Item_Return_Input_Times_Item_Quantity()
        {
            // arrange
            Store MyStore = new Store();
            string itemName = "Ice";
            int input = 2;
            double expectedResult = 100;

            // act
            double actualResult = MyStore.PurchaseQuantity(input, itemName);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
