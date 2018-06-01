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
        private List<string> rules;
        public List<string> Rules
        {
            get
            {
                return rules;
            }
            set
            {
                rules = value;
            }
        }
        
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
        public List<string> gameLength = new List<string>() { "1","14","30"};
       

        public Game(Random r, List<Weather> start)
        {
            rm = new Random();
            pr = new Player();
            iy = new Inventory();
            ui = new UserInterface();
            Rules = new List<string>
            {
                "Player will select length of game",
                "Player must buy ingredients from store and use the inredients to craft a recipe for a pitcher",
                "Player will then set a price per cup of lemonade and begin selling",
                "The weather and the price of the lemonade will impact how many people will buy lemonade",
                "The goal is to earn the most money possible by the end of the game"
            };

        }
        public void RunGame(Random r, List<Weather> start)
        {
            ui.SelectFromList("Rules of Lemonade Stand", Rules);
            Forcast = start;
            SetGameType();
            int counter = daysLeft;
            Console.Clear();
            while (counter > 0)
            {
                dy = new Day(r, Forcast, Iy);
                dy.RunDay(dy.Forcast, Iy, dy.Actual, r);
                Forcast = dy.Forcast;
                Iy = dy.Iy;
               // Console.WriteLine(Iy.Money);
                counter--;
            }
            ScoreKeeper(Iy, pr);
            ui.DisplayFinalScore(Pr);
            using (PlayerInfoDbContext db = new PlayerInfoDbContext())
            {

                db.PlayerName.Add(new Player() { PlayerName = Pr.PlayerName });
                db.Score.Add(new Player() { Score = Pr.Score });
                db.SaveChanges();

            }
            
            Console.ReadKey();
        }
        public void ScoreKeeper(Inventory playerInventory, Player user)
        {
            int roundMoney = Convert.ToInt32(playerInventory.Money);
            user.Score = roundMoney * 100;
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
