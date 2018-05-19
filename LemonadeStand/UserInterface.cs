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
                Console.WriteLine(forcast[i].Temp+"°F and "+forcast[i].Conditions);
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
    }
}
