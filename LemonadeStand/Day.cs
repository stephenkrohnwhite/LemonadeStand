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
        private Store se;
        private Customer cr;
        private Inventory iy;
        private UserInterface ui;
        private List<Weather> forcast;
        private List<Inventory> stock;
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
        public Day(Random r, List<Weather> initializer)
        {
            wr = new Weather(r);
            se = new Store();
            cr = new Customer();
            iy = new Inventory();
            ui = new UserInterface();
            forcast = wr.WeatherForcast(initializer, 7, r);
            Weather currentWeather = wr.CreateDayWeather(forcast[0], r, 6);
            ui.DisplayForcast(forcast);
            GetUserPurchase();
            Console.ReadKey();
            ui.DisplayCurrentWeather(currentWeather);
        }
        //method RunDay should generate "today's weather", create a seven day forcast, create a
        //number of customers based on weather conditions
        //should generate 'market driven' price of goods for the user to purchase
        public void RunDay(Random r)
        {
            forcast = wr.WeatherForcast(forcast, 7, r);
            Weather currentWeather = wr.CreateDayWeather(forcast[0], r, 6);
            ui.DisplayForcast(forcast);
            GetUserPurchase();
            Console.ReadKey();
            ui.DisplayCurrentWeather(currentWeather);
            
        }
        public void GetUserPurchase()
        {
            string userSelection = ui.SelectStock(se.Stock);
            string purchase = ui.DisplayItem(se.Stock, userSelection);
            if(se.PurchaseValidator(purchase) == true)
            {
                string purchaseName = se.Stock[Int32.Parse(userSelection) - 1].Name;
                int purchaseQuantity = se.StringToInt(purchase);
                double amount = se.PurchaseQuantity(purchaseQuantity, purchaseName);
                iy.AddToInventory(purchaseName, amount);
                iy.PayForItem(purchaseName, se.Stock[Int32.Parse(userSelection) - 1].Price, purchaseQuantity);
            }
            else
            {
                GetUserPurchase();
            }
        }
       

        


    }
}
