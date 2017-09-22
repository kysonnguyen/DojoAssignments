using System;

namespace human
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Human first = new Human("A");
            Console.WriteLine(first.GetType() + "--" + first.name + "--" + first.strength + "--" + first.intelligence + "--" + first.dexterity + "--" + first.Health);
            Human second = new Human("B", 5, 6, 8, 90);
            Console.WriteLine(second.GetType() + "--" + second.name + "--" + second.strength + "--" + second.intelligence + "--" + second.dexterity + "--" + second.Health);
            second.attack_humanOnly(first);
            Console.WriteLine(first.Health);
            Dummy third = new Dummy("C");
            second.attack_humanOnly(third);
            Console.WriteLine(third.Health);
        }
    }   
}
