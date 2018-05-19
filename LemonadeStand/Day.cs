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
        Weather wr;
        Store se;
        Customer cr;
        UserInterface ui;

        public Day(Random r, List<Weather> initilizer)
        {
            wr = new Weather(r);
            se = new Store();
            cr = new Customer();
            ui = new UserInterface();
        }
        //method RunDay should generate "today's weather", create a seven day forcast, create a
        //number of customers based on weather conditions
        //should generate 'market driven' price of goods for the user to purchase
        public void RunDay(Random r, List<Weather> forcast)
        {
            //wr.MinTemp = 65;
            //wr.MaxTemp = 100;
            List<Weather> weeklyForcast = wr.WeatherForcast(forcast, 7, r);
            Weather currentWeather = wr.CreateDayWeather(weeklyForcast[0], r, 6);
            ui.DisplayForcast(weeklyForcast);
            Console.ReadKey();
            ui.DisplayCurrentWeather(currentWeather);
        }
       

        


    }
}
