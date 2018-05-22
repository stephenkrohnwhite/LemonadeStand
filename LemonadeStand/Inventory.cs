using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        UserInterface ui = new UserInterface();
        private double money = 200.00;
        private List<Products> backStock = new List<Products>() { };
        private List<Products> pitcher;
        private List<string> ingredients;
        //making pitcher  
        //--get input into List<int> representing quantity of each item
        //--get int for number of pitchers to make 
        //--quantity for each item along with pitcher number must pass through validator
        //--then remove products from inventory and add to int pitcher
        //--pitchers will contain cups in to represent number of cups per pitcher
        //--int total cups will be # of pitchers made x pitchers.cups
        //--customers will -= from totalCups to during sell lemonade portion
        public List<Products> Pitcher
        {
            get
            {
                return pitcher;
            }
            set
            {
                pitcher = value;
            }
        }
        public double Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }
        public List<Products> BackStock
        {
            get
            {
                return backStock;
            }
        }
        public Inventory()
        {
            backStock.Add(new Products { Name = "Lemons", Quantity = 0.00, Unit = "lemons" });
            backStock.Add(new Products { Name = "Cups", Quantity = 0.00, Unit = "cups" });
            backStock.Add(new Products { Name = "Sugar", Quantity = 0.00, Unit = "lbs" });
            backStock.Add(new Products { Name = "Ice", Quantity = 0.00, Unit = "lbs" });
            ingredients = GetIngredients();
        }
        public void AddToInventory(string storeItem, double quantity)
        {
            for(int i=0; i<backStock.Count; i++)
            {
                if(storeItem == backStock[i].Name)
                {
                    backStock[i].Quantity += quantity;
                }
            }
        }
        public bool MoneyValidator(double purchasePrice)
        {
            if(purchasePrice > Money)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void PayForItem(string storeItem, double price, int quantity)
        { 
            for(int i =0; i<backStock.Count; i++)
            {
                if(storeItem == backStock[i].Name)
                {
                    Money -= (price * quantity);
                }
            }
        }
        public void MakePitcher(string message, List<string> ingredients)
        {
            Console.Clear();
            string selection = ui.SelectFromList(message, ingredients);
            switch (selection)
            {
                case "1":
                case "2":
                case "3":
                    AddProduct(selection);
                    break;
                default:
                    Console.WriteLine("Please enter valid selection");
                    MakePitcher(message, ingredients);
                    break;
            }
        }

        private void AddProduct(string selection)
        {
            int indexValue = StringToInt(selection) - 1;
            for (int i = 0; i < BackStock.Count; i++)
            {
                if (i == indexValue)
                {
                    Pitcher.Add(BackStock[1]);
                }
            }

        }
        private int StringToInt(string input)
        {
            int result = int.Parse(input);
            return result;
        }
        public List<string> GetIngredients()
        {
            List<string> ingredients = new List<string> { };
            for (int i = 0; i < BackStock.Count; i++)
            {
                ingredients.Add(BackStock[i].Name);
            }
            return ingredients;
        }
        public int SelectValidator(string input)
        {
            int.TryParse(input, out int inputValue);
            return inputValue;
        }
    }
}
