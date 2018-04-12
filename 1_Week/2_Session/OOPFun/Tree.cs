namespace OOPFun.MyClasses
{
    public class Tree
    {
        public static string[] Locations = 
        {
            "North America",
            "South America",
            "Asia",
            "Eurpoe",
            "Africa"
        };
        public string Location
        {
            get { return Tree.Locations[_location]; }
        }
        public Tree(int age, string color, double height, int locIdx)
        {
            Age = age;
            Color = color;
            Height = height;
            _location = locIdx;
        }
        private int _location;
        public int Age;
        public string Color;
        public double Height;

        public bool IsBigTree
        {
            get {
                return Height > 50;
            }
        }

        public void DisplayDetails()
        {
            System.Console.WriteLine($"Age: {Age}");
            System.Console.WriteLine($"Color: {Color}");
            System.Console.WriteLine($"Height: {Height}");
        }

        public virtual void Photosynthesize()
        {
            Height += 1;
            System.Console.WriteLine("... photosynthesizing ...");
            Color = "Green";
            System.Console.WriteLine("Photosynthesis Complete.");
        }
    }

    public class Evergreen : Tree
    {
        public bool SmellsNice {get;set;}

        public override void Photosynthesize()
        {
            base.Photosynthesize();
            System.Console.WriteLine("... photosynthesizing as an evergreen, no color change ...");
            System.Console.WriteLine("Photosynthesis Complete.");
        }

        public Evergreen(int age, double height) : base(age, "Green", height, 1)
        {
            SmellsNice = true;
        }
    }
}