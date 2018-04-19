using System;
using System.Collections.Generic;

namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Type a user id to update:");
            string userId = Console.ReadLine();
            DbReader.Update(userId);
            DbReader.Read();
            System.Console.WriteLine("Thank you!");

        }
    }
}
