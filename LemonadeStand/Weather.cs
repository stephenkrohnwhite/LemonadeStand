using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        
        private string conditions;
        private int temp;
        private int minTemp = 55;
        private int maxTemp = 90;
       
        public string Conditions
        {
            get
            {
                return conditions;
            }
            set
            {
                conditions = value;
            }
        }
        public int Temp
        {
            get
            {
                return temp;
            }
        }
        public int MinTemp
        {
            get
            {
                return minTemp;
            }
            set
            {
                if (value <= 60)
                {
                    minTemp = 60;
                }
                else if (value >= 100)
                {
                    minTemp = 100;
                }
                else
                {
                    minTemp = value;
                }
            }
        }
        public int MaxTemp
        {
            get
            {
                return maxTemp;
            }
            set
            {
                if (value <= 60)
                {
                    maxTemp = 60;
                }
                else if (value >= 100)
                {
                    maxTemp = 100;
                }
                else
                {
                    maxTemp = value;
                }
            }
        }
   
        public Weather(Random rdm)
        {
            BuildWeather(rdm);
        }
        protected void BuildWeather(Random rdm)
        {
            SetConditions(rdm);
            SetTemp(minTemp, maxTemp, rdm);
        }
        protected List<string> weatherTypes = new List<string>()
        {
            "Sunny",
            "Cloudy",
            "Rainy"
        };
        public void SetConditions(Random rdm)
        {
            int randomValue = rdm.Next(0, weatherTypes.Count);
            Conditions = weatherTypes[randomValue];
        }
        public void SetTemp(int minValue, int maxValue, Random rdm)
        {
            temp = rdm.Next(minValue, maxValue);
        }
        public List<Weather> InitializeWeather(int length, Random rdm)
        {
            List<Weather> emptySet = new List<Weather>();
            for (int i = 0; i<length; i++)
            {
                emptySet.Add(new Weather(rdm));
            }
            return emptySet;
        }
        public List<Weather> WeatherForcast(List<Weather> weatherList, int forcastLength, Random rdm)
        {
            List<Weather> newForcast = new List<Weather>();
            for (int i = 1; i < forcastLength; i++)
            {
                if ((ProbabilityScaler(i, rdm)) == 0)
                {
                    newForcast.Add(weatherList[i]);
                }
                else
                {
                    newForcast.Add(new Weather(rdm));
                }
            }
            newForcast.Add(new Weather(rdm));
            return newForcast;

        }
        public Weather CreateDayWeather(Weather todayForcast, Random rdm, int probabilityInt)
        {
            Weather randomDay = new Weather(rdm);
            int chance = rdm.Next(0, probabilityInt);
            if(chance != 0)
            {
                return todayForcast;
            }
            else
            {
                return randomDay;
            }
        }
        private int ProbabilityScaler(int scalerInteger, Random rdm)
        {
            int probablityValue = rdm.Next(0, scalerInteger);
            return probablityValue;
        }

    }

}
