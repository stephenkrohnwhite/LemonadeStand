using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        private List<Products> productPreference = new List<Products>() { };
        private List<Customer> dayCustomers = new List<Customer>() { };
        private bool buyLemonade;
        private List<int> tempValues = new List<int>() { 80, 70, 60 };
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
        public List<Products> ProductPreference
        {
            get
            {
                return productPreference;
            }
            set
            {
                productPreference = value;
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
            BuyLemonade = false;
            this.BuyLemonade = MakeChoice(todaysWeather, tempValues);
        }
        public void NumberOfCustomers(Weather day, double instantiator, Random r)
        {
            if(day.Conditions == "Sunny")
            {
                AddCustomers(instantiator, day, r);
            }
            else if(day.Conditions == "Cloudy")
            {
                AddCustomers(instantiator * .66, day, r);
            }
            else if(day.Conditions == "Rainy")
            {
                AddCustomers(instantiator * .33, day, r);
            }
        }
        public void AddCustomers(double generator, Weather day, Random r)
        {
            for(int i=0; i<generator;i++)
            {
                DayCustomers.Add(new Customer(day, r));
            }
        }
        public bool MakeChoice(Weather day, List<int> tempValues, Random r)
        {
            int chance = day.Temp / 2;
            if(day.Temp > tempValue[0])
            {
                BuyLemonade = true;
            }
        }
        public bool ProbabilityScaler(int prob)
        {

        }
    }
}
