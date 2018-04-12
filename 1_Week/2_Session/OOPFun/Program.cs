using System;
using System.Collections.Generic;
using OOPFun.MyClasses;

namespace OOPFun
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree(300, "Red", 65.34, 0);
            
            foreach(string loc in Tree.Locations)
            {
                
            }

            tree.DisplayDetails();
            tree.Photosynthesize();
            System.Console.WriteLine(tree.Location);

            if(tree.IsBigTree)
                System.Console.WriteLine("Cool its a big tree!");

            Evergreen bigCedar = new Evergreen(400, 100);

            List<Tree> trees = new List<Tree>()
            {
                tree,
                bigCedar
            };

            foreach(Tree t in trees)
            {
                t.Photosynthesize();
            }
           


        }
    }

}