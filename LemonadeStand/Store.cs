using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        private List<Products> stock = new List<Products>() { }; 
        public List<Products> Stock
        {
            get
            {
                return stock;
            }
        }
        
        public Store()
        {
            stock.Add(new Products { Name = "Lemons", Price = 5.00, Quantity = 50.00, Unit = "lemons/cs" });
            stock.Add(new Products { Name = "Cups", Price = 7.50, Quantity = 100.00, Unit="cups/cs" });
            stock.Add(new Products { Name = "Sugar", Price = 10.00, Quantity = 10.00, Unit="lbs/cs"});
            stock.Add(new Products { Name = "Ice", Price = 10.00, Quantity = 50.00, Unit="lbs/cs" });
        }
        //Need to fix validator to handle non-numbers
        public bool PurchaseValidator(string input)
        {
            bool result = int.TryParse(input, out int inputValue);
            if (result == false)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Stock.Count; i++)
                {
                     if (inputValue - 1 == i)
                     {
                        return true;
                     }
                }
            }
            return false;
        }
        public int StringToInt(string input)
        {
            int result = Int32.Parse(input);
            return result;
        }
        public bool StringMenuValidator(string input, int menuLength)
        {
            bool result = int.TryParse(input, out int choice);
            if(result == false)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < menuLength; i++)
                {
                    if(choice == i+1)
                    {
                        return true;
                    }
                   
                }
            }
            return false;
        }
        public double PurchaseQuantity(int input, string itemName)
        {
            for(int i=0; i <Stock.Count; i++)
            {
                if (itemName == Stock[i].Name)
                {
                    double amount = input * Stock[i].Quantity;
                    return amount;
                }
            }
            throw new Exception();
        }
   
    

    }
}
