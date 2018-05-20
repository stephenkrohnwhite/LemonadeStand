using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class UserInterface
    {

        public UserInterface()
        {

        }
        public string GetUserString(string message)
        {
            Console.WriteLine(message);
            string userString = Console.ReadLine();
            return userString;

        }
        public void DisplayForcast(List<Weather> forcast)
        {
            Console.WriteLine("7 day Forcast: \r\n");
            for (int i = 0; i < forcast.Count; i++)
                Console.WriteLine(forcast[i].Temp + "°F and " + forcast[i].Conditions);
        }
        public void DisplayCurrentWeather(Weather currentWeather)
        {
            Console.WriteLine("Today's conditions: " + currentWeather.Temp + "°F and " + currentWeather.Conditions + ".");
        }
        public string SelectFromList(string message, List<string> list)
        {
            Console.WriteLine(message);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + list[i]);
            }
            string selection = Console.ReadLine();
            return selection;
        }
        public string SelectStock(List<Products> stock)
        {
            DisplayStock(stock);
            string userSelection = Console.ReadLine();
            return userSelection;
        }
        public void DisplayStock(List<Products> stock)
        {
            Console.WriteLine("Select Item to purchase:");
            for (int i = 0; i < stock.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + stock[i].Name + ": $" + stock[i].Price + "/" 
                    + stock[i].Quantity + " " + stock[i].Unit);
            }
        }
        public string DisplayItem(List<Products> stock, string selection)
        {
            Console.WriteLine("Enter number of cases of " + stock[(Int32.Parse(selection)) - 1].Name + " to purchase.");
            string choice = Console.ReadLine();
            return choice;
        }
    }
}
