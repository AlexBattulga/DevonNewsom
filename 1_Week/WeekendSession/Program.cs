using System;
using System.Collections.Generic;

namespace WeekendSession
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero dev = new Hero("Devon");

            Enemy robot_1 = new Enemy("D34TH_30T");
            Enemy robot_2 = new Enemy("Big Bag Robot");
            Enemy soldier_1 = new Enemy("Guard");
            Enemy soldier_2 = new Enemy("Guard");

            List<Building> intersection = new List<Building>()
            {
                new Building(), new Building(), new Building(), new Building()
            };

            IDamageable[] thingsToAttack = new IDamageable[]
            {
                robot_1, robot_2, soldier_1, soldier_2,
                new Building(), new Building()
            };

            dev.Attack(robot_1, 10);
            dev.Attack(robot_2, 10);
            dev.Attack(robot_2, 10);
            dev.Attack(robot_2, 10);

            dev.AOEAttack(intersection, 30);
            dev.AOEAttack(thingsToAttack, 20);
            
        }
    }
}
