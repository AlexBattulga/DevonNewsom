using System;
using System.Collections.Generic;

namespace OOPStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Flower tulip = new Flower("Tulip", "Blue", true);
            Flower cherryBlossom = new Flower("Cherry Blossom", "Pinkish White", true);

            tulip.DisplayFlower();
            cherryBlossom.DisplayFlower();
            System.Console.WriteLine(cherryBlossom.Description);

            TropicalFlower turboVenusFlytrap = new TropicalFlower("TURBO", "sorta red, sorta silver");

            turboVenusFlytrap.DisplayFlower();
            turboVenusFlytrap.Move(100);
            turboVenusFlytrap.Move(4);
            turboVenusFlytrap.Move(40);
            turboVenusFlytrap.Move(13);
            System.Console.WriteLine(turboVenusFlytrap.DistanceTraveled);

            List<Flower> flowers = new List<Flower>()
            {
                tulip, cherryBlossom, turboVenusFlytrap
            };

            foreach(Flower f in flowers)
            {
                f.DisplayFlower();
            }



        }
    }
}
