using System;
using System.Collections.Generic;
using System.Linq;
namespace LinqFun
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {834,2,-23,2,103,-5,42,-1,27};

            int minNum = numbers.Min();
            int maxNum = numbers.Max();

            int[] evens = numbers.Where(num => num%2 == 0).ToArray();

            // Select => mutates data
            int[] doubleTheNums = numbers.Select(num => num * 2).ToArray();

            // 1 => "1"
            string three = 3.ToString();
            string[] strNums = numbers.Select(num => num.ToString()).ToArray();

            List<string> names = new List<string>
            {
                "Sharon",
                "Charlie",
                "Barbara",
                "Molly",
                "Ashton",
                "Marcellus",
                "Molly",
                "Bob"
            };

            // Note: Get Bob
            int minNameLength = names.Min(name => name.Length);
            string shortestName = names.FirstOrDefault(name => name.Length == minNameLength);
            string longestName = names.FirstOrDefault(name => name.Length == names.Max(n => n.Length));

            

            names.First();
            names.FirstOrDefault(name => name == "Marcus");

            
            List<City> cities = Place.GetCities();
            List<State> states = Place.GetStates();

            List<City> BigCities = cities.Where(city => city.Population > 1000000).ToList();
            int[] populations = cities.Select(city => city.Population).ToArray();
            int totalPopulation = populations.Sum();

            // ["Seattle, Washington", etc]
            string[] fullCityNames = cities.Join(
                states, 
                // Key Selectors
                (city => city.StateCode), 
                (state => state.StateCode), 
                (joinedCity, joinedState) => 
                {
                    return $"{joinedCity.Name}, {joinedState.Name}";
                }
            ).ToArray(); 


        }
    }
}
