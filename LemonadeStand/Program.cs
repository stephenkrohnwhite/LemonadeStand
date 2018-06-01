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
         
            Random r = new Random();
            Weather wr = new Weather(r);
            List<Weather> initializer = wr.InitializeWeather(7, r);
            Game gm = new Game(r, initializer);
            gm.RunGame(r, initializer);

           



            Console.ReadKey();
        }
    }
}
