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
        private Player pr;
        public UserInterface ui;
        private Day dy;
        private List<Weather> forcast;
        private int daysLeft;
        private Inventory iy;
        public Player Pr
        {
            get
            {
                return pr;
            }
            set
            {
                pr = value;
            }
        }
        public Day Dy
        {
            get
            {
                return dy;
            }
            set
            {
                dy = value;
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
        
        public int GameType
        {
            get
            {
                return GameType;
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
        public List<string> gameLength = new List<string>() { "7","14","30"};
       

        public Game(Random r, List<Weather> start)
        {
            rm = new Random();
            pr = new Player();
            ui = new UserInterface();

        }
        public void RunGame(Random r, List<Weather> start)
        {
            int counter = daysLeft;
            Forcast = start;
            SetGameType();
            Console.Clear();
            while (daysLeft > 0)
            {
                dy = new Day(r, Forcast);
                Forcast = dy.Forcast;
                Iy = dy.Iy;
                //dy.RunDay(r);
                Console.WriteLine(Iy.Money);
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
