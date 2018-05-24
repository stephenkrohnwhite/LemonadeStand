using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        private List<Customer> dayCustomers = new List<Customer>() { };
        private bool buyLemonade;
        private int limit;
        private List<int> tempValues = new List<int>() { 80, 70, 60 };
        private int  customerLimit = 125;
        public int Limit
        {
            get
            {
                return limit;
            }
            set
            {
                limit = value;
            }
        }
        public int CustomerLimit
        {
            get
            {
                return customerLimit;
            }
            set
            {
                customerLimit = value;
            }
        }
        public bool BuyLemonade
        {
            get
            {
                return buyLemonade;
            }
            set
            {
                buyLemonade = value;
            }
        }
        
        public List<Customer> DayCustomers
        {
            get
            {
                return dayCustomers;
            }
            set
            {
                dayCustomers = value;
            }
        }
        //list of customer preferences will instantiate in the constructor. Will be matched against lemonade recipe
        
        //will have a MakeChoice method for each customer created. makeChoice will use temperate to create probablity.
        //will randomly select whether or not someone will buy. will return bool
        public Customer(Weather todaysWeather, Random r)
        {
            Limit = 25;
            BuyLemonade = false;
            
        }
        public List<Customer> NumberOfPeople(Weather day, Random r)
        {
            List<Customer> customerList = new List<Customer>() { };
            if(day.Conditions == "Sunny")
            {
               customerList = AddCustomers(CustomerLimit, day, r);
            }
            else if(day.Conditions == "Cloudy")
            {
                customerList = AddCustomers(CustomerLimit * .66, day, r);
            }
            else if(day.Conditions == "Rainy")
            {
                customerList =  AddCustomers(CustomerLimit * .33, day, r);
            }
            return customerList;
        }
        public List<Customer> AddCustomers(double generator, Weather day, Random r)
        {
            List<Customer> todaysCustomers = new List<Customer>() { };
            for(int i=0; i<generator;i++)
            {
                todaysCustomers.Add(new Customer(day, r));
            }
            return todaysCustomers;
        }
        public List<Customer> RemoveCustomers (List<Customer> potentialBuyers)
        {
          
                for (int i = 0; i < potentialBuyers.Count; i++)
                {
                    if (BuyLemonade == false)
                    {
                        potentialBuyers.Remove(potentialBuyers[i]);
                    }
                }
            return potentialBuyers;
            
        }
        public List<Customer> CustomerChoice(Weather day, Random r, List<Customer> buyers, Inventory player)
        {
            for(int i=0; i< buyers.Count; i++)
            {
                buyers[i].BuyLemonade = MakeWeatherChoice(day, r);
            }
            for(int i=0; i<buyers.Count; i++)
            {
                buyers[i].BuyLemonade = MakePriceChoice(day, r, player);
            }
            return buyers;
        }


        private bool MakePriceChoice(Weather day, Random r, Inventory player)
        {
            int priceModulator = Convert.ToInt32(day.Temp/(player.PricePerCup * 10));
            if(r.Next(0, priceModulator)>4)
            {
                return true;
            }
            return false;
        }

        public bool MakeWeatherChoice(Weather day, Random r)
        {
            int chance = day.Temp / 2;
            bool choice = ProbabilityScaler(chance, r);
            return choice;
        }
        public bool ProbabilityScaler(int probabiityVariable, Random r)
        {
            if (r.Next(0,probabiityVariable) > limit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
