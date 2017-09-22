using System;
namespace human {
    
   public class Human
    {
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int Health = 100;
        public Human(string name_in)
        {
            name = name_in;
        }
        public Human(string name_in, int str, int intl, int dex, int hp)
        {
            name = name_in;
            strength = str;
            intelligence = intl;
            dexterity = dex;
            Health = hp;
        }
        public void attack(Human target)
        {
            int damage = 5 * strength;
            target.Health -= damage;
        }

        public void attack_humanOnly(object target)
        {
            if(target is Human){
                Human human_target = target as Human;
                attack(human_target);
            }
            else{
                Console.WriteLine("target is not human");
            }
        }
    }

    public class Dummy
    {
        public string name;
        public int strength = 0;
        public int intelligence = 0;
        public int dexterity = 0;
        public int Health = 1000;

        public Dummy(string input)
        {
            name = input;
        }
    }
}