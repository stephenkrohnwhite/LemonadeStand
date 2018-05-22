using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        //Should contain an instantiation of weather, store and inventory
        private Weather wr;
        private Weather actual;
        private Store se;
        private Customer cr;
        private Inventory iy;
        private UserInterface ui;
        private List<Weather> forcast;
        private List<Inventory> stock;
        private static List<string> menu = new List<string>()
        {
            "Display Weather Forcast",
            "Go to Store",
            "Check Current Inventory"
        };
        public Weather Actual
        {
            get
            {
                return actual;
            }
            set
            {
                actual = value;
            }
        }
        public Weather Wr
        {
            get
            {
                return wr;
            }
            set
            {
                wr = value;
            }
        }
        public Inventory Iy
        {
            get
            {
                return iy;
            }
            set
            {
                iy = value;
            }
        }
        public List<Weather> Forcast
        {
            get
            {
                return forcast;
            }
            set
            {
                forcast = value;
            }
        }
        public List<Inventory> Stock
        {
            get
            {
                return stock;
            }
            set
            {
                stock = value;
            }
        }
        //To do for Day:
        //Need to build mainmenu to show:
        //1. Forcast
        //2. Current inventory
        //3. store - purchase
        //4. start
        //start will make the user set a recipe, allow user to return to store if they need more ingredients
        //once they have their recipe set, they can begin the day, 
        //display current weather 
        //then display results of customers who choose to buy lemonade
        public Day(Random r, List<Weather> initializer, Inventory userInventory)
        {
            wr = new Weather(r);
            actual = new Weather(r);
            se = new Store();
            cr = new Customer();
            ui = new UserInterface();
            iy = userInventory;
            forcast = wr.WeatherForcast(initializer, 7, r);
            Actual = wr.CreateDayWeather(forcast[0], r, 6);
        }
        public void RunDay(List<Weather> weatherForcast, Inventory userInventory, Weather actual)
        {
            {
                DayMenu(forcast, userInventory);
            }
            //ui.DisplayCurrentWeather(actual);
        }
        public void DayMenu(List<Weather> weatherList, Inventory userInventory)
        {
            Console.Clear();
            string selection = ui.SelectFromList("Please Select from the following list:", menu);

            switch(selection)
            {
                case "1":
                    ui.DisplayForcast(Forcast);
                    Console.ReadLine();
                    break;
                case "2":
                    GetUserPurchase(weatherList, userInventory);
                    break;
                case "3":
                    ui.DisplayUserInventory(Iy);
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Please enter valid selection");
                    DayMenu(weatherList, userInventory);
                    break;
            }
            Console.Clear();
            DayMenu(weatherList, userInventory);
        }
        
        public void GetUserPurchase(List<Weather> weatherList, Inventory userInventory)
        {
            int userSelection = GetUserItem();
            BuyItem(userSelection);
            ui.DisplayUserInventory(Iy);
            Console.ReadLine();
            string option = ui.PurchaseMenu();
            if (se.StringMenuValidator(option, 2) == true)
            {
                switch (option)
                {
                    case "1":
                        GetUserPurchase(weatherList, userInventory);
                        break;
                    case "2":
                        DayMenu(weatherList,userInventory);
                        break;
                    default:
                        break;
                }
            }

        }
        public void BuyItem(int userSelection)
        {
            string purchase = ui.DisplayItem(se.Stock, userSelection);
            if (se.StringIntValidator(purchase) == true)
            {
                string purchaseName = se.Stock[userSelection - 1].Name;
                int purchaseQuantity = se.StringToInt(purchase);
                double amount = se.PurchaseQuantity(purchaseQuantity, purchaseName);
                double purchasePrice = se.CalculatePurchasePrice(purchaseQuantity, se.Stock[userSelection - 1]);
                FinalizePurchase(purchasePrice, amount, userSelection, purchaseQuantity, purchaseName);
            }
            else
            {
                Console.WriteLine("Please enter valid selection");
                BuyItem(userSelection);
            }
        }
        public void FinalizePurchase(double price, double amount, int selection, int purchaseQuantity, string purchaseName)
        {
            if(Iy.MoneyValidator(price) == true)
            {
                iy.AddToInventory(purchaseName, amount);
                iy.PayForItem(purchaseName, se.Stock[selection - 1].Price, purchaseQuantity);
            }
            else
            {
                Console.WriteLine("Not enough money to complete transaction");
                BuyItem(selection);
            }
        }
        public int GetUserItem()
        {
            Console.Clear();
            string selection = ui.SelectStock(se.Stock);
            if(se.PurchaseValidator(selection)==true)
            {
                int choice = Int32.Parse(selection);
                return choice;
            }
            else
            {
                Console.WriteLine("Please enter a valid selection");
                return GetUserItem();
            }
        }
        
        


    }
}
