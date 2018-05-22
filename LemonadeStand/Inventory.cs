using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        UserInterface ui = new UserInterface();
        private double money = 200.00;
        private List<Products> backStock = new List<Products>() { };
        public double Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }
        public List<Products> BackStock
        {
            get
            {
                return backStock;
            }
        }
        public Inventory()
        {
            backStock.Add(new Products { Name = "Lemons", Quantity = 0.00, Unit = "lemons" });
            backStock.Add(new Products { Name = "Cups", Quantity = 0.00, Unit = "cups" });
            backStock.Add(new Products { Name = "Sugar", Quantity = 0.00, Unit = "lbs" });
            backStock.Add(new Products { Name = "Ice", Quantity = 0.00, Unit = "lbs" });
        }
        public void AddToInventory(string storeItem, double quantity)
        {
            for(int i=0; i<backStock.Count; i++)
            {
                if(storeItem == backStock[i].Name)
                {
                    backStock[i].Quantity += quantity;
                }
            }
        }
        public bool MoneyValidator(double purchasePrice)
        {
            if(purchasePrice > Money)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void PayForItem(string storeItem, double price, int quantity)
        { 
            for(int i =0; i<backStock.Count; i++)
            {
                if(storeItem == backStock[i].Name)
                {
                    Money -= (price * quantity);
                }
            }
        }
        //public bool MoneyValidator(string t)
        
    }
}
