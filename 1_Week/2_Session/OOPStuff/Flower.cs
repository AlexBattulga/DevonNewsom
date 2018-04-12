namespace OOPStuff
{
    public class Flower
    {
        public Flower(string name, string color, bool isPeren)
        {
            Name = name;
            Color = color;
            IsPerenial = isPeren;
        }
        public string Name;
        public string Color;
        public bool IsPerenial;
        public string Description
        {
            get {
                if(IsPerenial)
                {
                    return $"{Name} is a fantastic perenial flower";
                }
                else{
                    return $"Unfortunately, {Name} is no perenial";
                }
            }
        }
        public virtual void DisplayFlower()
        {
            System.Console.WriteLine($"Name: {Name}");
            System.Console.WriteLine($"Color: {Color}");
            System.Console.WriteLine($"Is Perenial: {IsPerenial}");
        }
    }

    public class TropicalFlower : Flower
    {
        public override void DisplayFlower()
        {
            base.DisplayFlower();
            System.Console.WriteLine($"Has Traveled: {DistanceTraveled}");
        }
        public int DistanceTraveled;
        public TropicalFlower(string name, string color) : base(name, color, false)
        {
            DistanceTraveled = 0;
        }
        public void Move(int distnace)
        {
            DistanceTraveled += distnace;
        }
    }
}