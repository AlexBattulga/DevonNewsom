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

            List<City> cities = Place.GetCities();
            List<State> states = Place.GetStates();

        // HELPERS
            // .Min / .Max
            // .Sum / .Average
            // .ToList / .ToArray
            int minNum = numbers.Min();
            List<int> numList = numbers.ToList();

            // Find BOB
            // 1) we know how many chars bob is..
            int minNameLength = names.Min(name => name.Length);
            string shortstName = names.FirstOrDefault(name => name.Length == names.Min(n => n.Length));


        // MUTATE -> Collection
            // .Select
            int[] quadrupledNums = numbers.Select(num => num * 4).ToArray();
            // 1 => "1"
            string[] strNums = numbers.Select(num => num.ToString()).ToArray();

            // .Join
            // ["Seattle, Washington", "Houston, Texas", ...]
            var fullCityNames = cities.Join(states, 
            
            // key selectors
            (city => city.StateCode), (state => state.StateCode),

            // return selector
            (joinedCity, joinedState) => 
            {
                return $"{joinedCity.Name}, {joinedState.Name}";
            });

        // FILTER -> Collection
            // .Where
            int[] evenNums = numbers.Where(num => num%2 == 0).ToArray();
            string[] longNames = names.Where(name => name.Length > 10).ToArray();

            // .OrderBy / .OrderByDescending
            List<string> alphebetized = names.OrderBy(name => name[0]).ToList();
            
            // .Take (like SQL LIMIT)
            names.Take(5);

        // FILTER -> One Item

            // .First()
            int firstEvenNumber = numbers.First(num => num%2 == 0);
            string firstName = names.First();
            City firstCity = cities.First();

            // .FirstOrDefault()
            // .FirstOrDefault(predicate)
            // if predicate is used, default value is returned if no match is found
            int firstEvenNumberOrZero = numbers.First(num => num%2 == 0);
            string firstSharonOrNull = names.FirstOrDefault(name => name == "Sharon");

            // Linq Olympics

            // Find the City with the largest population
            City largestPop = cities.FirstOrDefault(city => city.Population == cities.Max(c => c.Population));
            
            // Find the total population of all cities!
            int totalPop = cities.Sum(c => c.Population);


          
        }
    }
}
