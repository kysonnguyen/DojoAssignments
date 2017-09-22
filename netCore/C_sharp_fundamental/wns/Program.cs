using System;

namespace wns
{
    class Program
    {
        static void Main(string[] args)
        {
           Wizard Magus = new Wizard("Merlin");
           Ninja Assassin = new Ninja("Hanzo");
           Samurai Samurai = new Samurai("Ichi");
           Magus.fireball(Samurai);
           Assassin.steal(Magus);
           Samurai.meditate();
           Samurai.death_blow(Magus);
           Console.WriteLine(Magus.health);
           Console.WriteLine(Assassin.health);
           Console.WriteLine(Samurai.health);
        }
    }
}
