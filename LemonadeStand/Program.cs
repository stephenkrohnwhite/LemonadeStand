using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {

            //1. Create classes to be used in game
            //Weather
            //Customer
            //Game
            //Inventory
            //Player
            //Store
            //Day
            //UserInterface
            //SQLconnection??
            //2.Need to outline game:
            // * Display instructions
            // * Ask USER to select game length (select one week, two weeks, one month)
            // * Display menu inventory: 
            // * Have 'start sellin' option
            // * Day #, Money, Current weather, inventory/purchase options(cups, lemons, sugar, ice)
            // * Diplay recipe page(price/cup, lemons/pitcher, sugar/pitcher, ice/cup)
            // * Customer class to have preferences for getting lemonade based on weather conditions, recipe
            // * Create 
            // * 
            // * 
            // * NEED TO DEFINE WHAT OWNS WHAT
            // * GAME ==> DAY, PLAYER, UI
            // * PLAYER ==> INVENTORY, UI
            // * DAY ==> WEATHER, STORE, CUSTOMER, UI
            // * 
            // * 
            // * SOLID Principles: 
            // * 1. UserInterface 51,
            // * 2. Customer 71 
            // * TO DO:
            // * Add database for high scores


            Random r = new Random();
            Weather wr = new Weather(r);
            List<Weather> initializer = wr.InitializeWeather(7, r);
            Game gm = new Game(r, initializer);

            gm.RunGame(r, initializer);

            


            Console.ReadKey();
        }
    }
}
