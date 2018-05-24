using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        Inventory sy = new Inventory();
        UserInterface ui = new UserInterface();
        private int score;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
        private string playerName;
        public string PlayerName
        {
            get
            {
                return PlayerName;
            }
        }
        public Player()
        {
            playerName = ui.GetUserString("Please enter your name");
        }
       
    }
}
