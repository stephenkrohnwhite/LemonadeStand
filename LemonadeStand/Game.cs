using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game

    {
        public Random rm;
        public Player pr;
        public UserInterface ui;
        public Day dy;
        private int daysLeft;
        public int GameType
        {
            get
            {
                return GameType;
            }
        }
        public List<string> gameLength = new List<string>() { "7","14","30"};
       

        public Game(Random r, List<Weather> start)
        {
            dy = new Day(r, start);
            rm = new Random();
            pr = new Player();
            ui = new UserInterface();

        }
        public void RunGame(Random r, List<Weather> start)
        {
            int counter = daysLeft;
            dy.Forcast = start;
            SetGameType();
            Console.Clear();
            while (daysLeft > 0)
            { 
                dy.RunDay(r);
                counter--;
            }    
            Console.ReadKey();
        }
        public void SetGameType()
        {
            string selection = ui.SelectFromList("Please Enter GameType", gameLength);
            if (ValidateUserString(selection, gameLength) == true)
            {
                int option = Int32.Parse(selection);
                daysLeft = Int32.Parse(gameLength[option-1]);
            }
            else
            {
                SetGameType();
            }

        }
        public bool ValidateUserString(string input, List<string> list)
        {
            for(int i=0; i<list.Count; i++)
            {
                if (input == (i + 1).ToString())
                {
                    return true;
                }
               
            }
            return false;
        }
        


    }
}
