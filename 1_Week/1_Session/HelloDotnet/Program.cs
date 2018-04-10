using System;
using System.Collections.Generic;

namespace HelloDotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            int myInt = 5;
            long myLong = 5;
            short myShort = 5;
            byte myBype = 5;

            string myName = "Devon";
            bool isCOol = false;


            int[] numbers = new int[10]; 
            string[] words = new string[10];

            int[] moreNumbers = 
            {
                10, 132, 2342, 234, -234, -2132, 19
            };

            moreNumbers[100] = 0;

            List<int> listOfInts = new List<int>();
            List<int> anotherListOfInts = new List<int>() 
            {
                10, 132, 2342, 234, -234, -2132, 19
            };
            listOfInts.Add(10);
            listOfInts.Add(100);
            listOfInts.Add(110);

            for(int i = 0; i <= anotherListOfInts.Count; i++)
            {
                System.Console.WriteLine(anotherListOfInts[i]);
            }
            for(int i = 0; i <= moreNumbers.Length; i++)
            {
                System.Console.WriteLine(moreNumbers[i]);
            }

            foreach(int number in anotherListOfInts)
            {
                System.Console.WriteLine(number);
            }



            Console.WriteLine("Hello World!");
        }
    }
}
