using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class UserInterface
    {
        private List<string> yesNo = new List<string>() {"yes", "no"};
        public List<string> YesNo
        {
            get
            {
                return yesNo;
            }
            set
            {
                yesNo = value;
            }
        }
        public UserInterface()
        {

        }
        public string GetUserString(string message)
        {
            Console.WriteLine(message);
            string userString = Console.ReadLine();
            return userString;

        }
        public string GetIngredient(string message, List<string> ingredients)
        {
            int choice = int.Parse(message);
            Console.WriteLine("Please amount of "+ingredients[choice-1]+" to add per pitcher");
            string userQuantity = Console.ReadLine();
            return userQuantity;
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
        //SOLID Principle:
        //SelectFromList method uses parameters to any message to set up the list and takes in a list<string> to dislay with
        //numbers. This is an example of Open/Closed. You cant and dont need to modidy the method, but its open and general to take and list
        //as an argument. It also reduces dependency by not relying on any specific classes within the method.
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
        public string SelectFromListWithEscape(string message, List<string> list)
        {
            Console.WriteLine(message);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + list[i]);
            }
            Console.WriteLine((list.Count+1)+". Go Back");
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
        public string DisplayItem(List<Products> stock, int selection)
        {
            Console.WriteLine("Enter number of cases of " + stock[selection - 1].Name + " to add.");
            string choice = Console.ReadLine();
            return choice;
        }
        public void DisplayUserInventory(Inventory player)
        {
            Console.WriteLine("Current inventory:\r\n$"+player.Money+"\r\n");
            for(int i=0;i<player.BackStock.Count;i++)
            {
                Console.WriteLine(i+1+". "+player.BackStock[i].Quantity+" "+player.BackStock[i].Name);
            }
        }
        public void DisplayUserStock(List<Products> stock)
        {
            for (int i = 0; i < stock.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + stock[i].Quantity + " " + stock[i].Name);
            }
        }
        public void DisplayRecipe(List<Products> recipe)
        {
            Console.WriteLine("Current Recipe:");
            for(int i=0; i<recipe.Count;i++)
            {
                Console.WriteLine((i+1)+". "+ recipe[i].Name+ ". "
                    + recipe[i].Quantity+" "+ recipe[i].Unit);
            }
        }
        public string PurchaseMenu()
        {
            Console.WriteLine("1. Stay in store\r\n2. Return to main menu");
            string selection = Console.ReadLine();
            return selection;
        }
        public void ShowDayResults(Inventory player, int cupsSold, double moneyEarned)
        {
            Console.WriteLine("Here's your return from today:\r\nYou sold "+cupsSold+" cups today and made $"+moneyEarned+"!\r\n" +
                "Current inventory:\r\n$"+player.Money);
            for(int i=0; i <player.BackStock.Count; i++)
            {
                Console.WriteLine(player.BackStock[i].Quantity + " "+player.BackStock[i].Name);
            }
            Console.ReadLine();
        }
        public void DisplayFinalScore(Player user)
        {
            Console.WriteLine("Your Final Score: "+user.Score+"!");
        }
    }
}
