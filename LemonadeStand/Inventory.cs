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
        private double pricePerCup;
        private List<Products> backStock = new List<Products>() { };
        private List<Products> pitcherRecipe = new List<Products>() { };
        private int pitcher;
        private int cupsInPitcher;
        private List<string> ingredients;
        //making pitcher  
        //--get input into List<int> representing quantity of each item
        //--get int for number of pitchers to make 
        //--quantity for each item along with pitcher number must pass through validator
        //--then remove products from inventory and add to int pitcher
        //--pitchers will contain cups in to represent number of cups per pitcher
        //--int total cups will be # of pitchers made x pitchers.cups
        //--customers will -= from totalCups to during sell lemonade portion
        public double PricePerCup
        {
            get
            {
                return pricePerCup;
            }
            set
            {
                pricePerCup = value;
            }
        }
        public int Pitcher
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
        public int CupsInPitcher
        {
            get
            {
                return cupsInPitcher;
            }
            set
            {
                cupsInPitcher = value;
            }
        }
        public List<Products> PitcherRecipe
        {
            get
            {
                return pitcherRecipe;
            }
            set
            {
                pitcherRecipe = value;
            }
        }
        public List<string> Ingredients
        {
            get
            {
                return ingredients;
            }
            set
            {
                ingredients = value;
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
            backStock.Add(new Products { Name = "Sugar", Quantity = 0.00, Unit = "lbs" });
            backStock.Add(new Products { Name = "Ice", Quantity = 0.00, Unit = "lbs" });
            backStock.Add(new Products { Name = "Cups", Quantity = 0.00, Unit = "cups" });
            PitcherRecipe.Add(new Products { Name = "Lemons", Quantity = 0.00, Unit = "lemons" });
            PitcherRecipe.Add(new Products { Name = "Sugar", Quantity = 0.00, Unit = "lbs" });
            PitcherRecipe.Add(new Products { Name = "Ice", Quantity = 0.00, Unit = "lbs" });
            Pitcher = 0;
            Ingredients = GetIngredients();
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
        public void MakePitcher(string message)
        {
            Console.Clear();
            string selection = ui.SelectFromListWithEscape(message, Ingredients);
            switch (selection)
            {
                case "1":
                case "2":
                case "3":
                    double productToAdd = GetQuantity(selection);
                    AddProduct(selection, productToAdd);
                    MakePitcher(message);
                    break;
                case "4":
                    ui.DisplayRecipe(PitcherRecipe);
                    BuildPitcher(selection, message);
                    SetPricePerCup();
                    break;
                case "5":
                    ui.DisplayUserStock(backStock);
                    MakePitcher(message);
                    break;
                case "6":
                    DeleteRecipe();
                    MakePitcher(message);
                    break;
                case "7":
                    break;
                default:
                    Console.WriteLine("Please enter valid selection");
                    MakePitcher(message);
                    break;
            }
        }

        private void SetPricePerCup()
        {
            string entry = ui.GetUserString("Please enter price per cup (select value between 50¢ and $2.50)");
            double price = SelectDoubleValidator(entry);
            if(price < .5 || price >2.5)
            {
                Console.WriteLine("Please enter valid price");
                SetPricePerCup();
            }
            else
            {
                PricePerCup = price;
            }
        }

        private void DeleteRecipe()
        {
            List<Products> newRecipe = new List<Products>() { };
            newRecipe.Add(new Products { Name = "Lemons", Quantity = 0.00, Unit = "lemons" });
            newRecipe.Add(new Products { Name = "Sugar", Quantity = 0.00, Unit = "lbs" });
            newRecipe.Add(new Products { Name = "Ice", Quantity = 0.00, Unit = "lbs" });
            PitcherRecipe = newRecipe;

        }

        private void BuildPitcher(string select, string message)
        {
            string yesNo = ui.SelectFromList("Are you ready to build your pitcher?", ui.YesNo);
            switch(yesNo)
            {
                case "1":
                    PitcherBuilder();
                    break;
                case "2":
                default:
                    MakePitcher(message);
                    break;
            }

        }
        private double GetQuantity(string selection)
        {
            Console.Clear();
            int indexSelection = int.Parse(selection) - 1;
            string userQuantity = ui.GetIngredient(selection, Ingredients);
            double amount = SelectDoubleValidator(userQuantity);
            if (amount == 0)
            {
                Console.WriteLine("Not a valid amount.");
                Console.ReadLine();
                return 0;
            }
            else
            {
                if (ValidateAmount(amount, indexSelection) == true)
                {
                    return amount;
                }
                else
                {
                    Console.WriteLine("Amount is more that currently in your inventory");
                    Console.ReadLine();
                    return GetQuantity(selection);
                }
            }
            
        }
        private bool ValidateAmount(double total, int index)
        {
            for(int i = 0; i<BackStock.Count; i++)
            {
                if(i == index)
                {
                    if (total > BackStock[i].Quantity)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void RemoveFromInventory()
        {
            for(int i = 0; i <PitcherRecipe.Count;i++)
            {
                BackStock[i].Quantity -= PitcherRecipe[i].Quantity;
            }
        }
        public void PitcherBuilder()
        {
            while(BackStockAllowance() == true)
            {
                RemoveFromInventory();
                Pitcher++;
            }
            CupsPerPitcher();
            Console.WriteLine("You have made "+Pitcher+" pitcher(s)");
        }
        public bool BackStockAllowance()
        {
            for(int i = 0; i<PitcherRecipe.Count; i++)
            {
                if(BackStock[i].Quantity < PitcherRecipe[i].Quantity)
                {
                    return false;
                }
            }
            return true;
        }
        private void AddProduct(string selection, double amount)
        {
            int indexValue = StringToInt(selection) - 1;
            for (int i = 0; i < PitcherRecipe.Count; i++)
            {
                if (i == indexValue)
                {
                    PitcherRecipe[i].Quantity += amount;
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
                if(BackStock[i].Name != "Cups")
                {
                    ingredients.Add(BackStock[i].Name);
                }
            }
            ingredients.Add("Make Lemonade from your recipe");
            ingredients.Add("Display current stock");
            ingredients.Add("Delete recipe");
            return ingredients;
        }
        public int SelectValidator(string input)
        {
            int.TryParse(input, out int inputValue);
            return inputValue;
        }
        public double SelectDoubleValidator(string input)
        {
            double.TryParse(input, out double inputValue);
            return inputValue;
        }
        public void CupsPerPitcher()
        {
            for(int i=0;i<PitcherRecipe.Count;i++)
            {
                if(PitcherRecipe[i].Name == "Ice")
                {
                    if(PitcherRecipe[i].Quantity >= 0 || PitcherRecipe[i].Quantity < 1.5)
                    {
                        CupsInPitcher = 12;
                    }
                    else if(PitcherRecipe[i].Quantity >= 1.5 || PitcherRecipe[i].Quantity < 3)
                    {
                        CupsInPitcher = 10;
                    }
                    else if (PitcherRecipe[i].Quantity >= 3)
                    {
                        CupsInPitcher = 6;
                    }
                }
            } 
        }
        //need to construct method for taking in number of customers who are willing to purchase lemonade
        //method should use a while loop for while cups>0 && pitchers>0 we add price/cup to money and
        //subtract cups and pitchers

        public void InventoryAdjuster(int buyingCustomers)
        {
            while(BackStock[3].Quantity > 0 && Pitcher > 0 && buyingCustomers > 0)
            {
                Money += PricePerCup;
                BackStock[3].Quantity--;
                Pitcher--;
                buyingCustomers--;
            }
        }
        
    }
}
