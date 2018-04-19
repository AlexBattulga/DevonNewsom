using System;
using System.Collections.Generic;

namespace CRUD
{
    public static class DbReader
    {
        public static void Read()
        {
            List<Dictionary<string, object>> users = DbConnector.Query("SELECT * FROM users");
            foreach(var user in users)
            {
                Console.WriteLine($"First Name: {user["first_name"]}");
                Console.WriteLine($"Last Name: {user["last_name"]}");
                Console.WriteLine($"Favorite Number: {user["favorite_number"]}");
                Console.WriteLine($"Date Created: {user["created_at"]}");
                System.Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            }
        }
        public static User PromptForUser()
        {
            System.Console.WriteLine("Enter a First Name: ");
            string first = Console.ReadLine();

            System.Console.WriteLine("Enter a Last Name: ");
            string last = Console.ReadLine();

            System.Console.WriteLine("Enter a Favorite Number: ");
            string num = Console.ReadLine();
            return new User()
            {
                FirstName = first,
                LastName = last,
                FavNum = num
            };

        }
        public static void Update(string userId)
        {
            User userToUpdate = PromptForUser();
            string query = 
            $@"
                UPDATE users SET first_name = '{userToUpdate.FirstName}', 
                last_name = '{userToUpdate.LastName}', 
                favorite_number = '{userToUpdate.FavNum}' 
                WHERE id = {userId}
            ";
            DbConnector.Execute(query);
        }
    }
}