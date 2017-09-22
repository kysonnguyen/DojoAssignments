using System;
public class Human
{
    public string name;

    //The { get; set; } format creates accessor methods for the field specified
    //This is done to allow flexibility
    public int health { get; set; }
    public int strength { get; set; }
    public int intelligence { get; set; }
    public int dexterity { get; set; }

    public Human(string person)
    {
        name = person;
        strength = 3;
        intelligence = 3;
        dexterity = 3;
        health = 100;
    }
    public Human(string person, int str, int intel, int dex, int hp)
    {
        name = person;
        strength = str;
        intelligence = intel;
        dexterity = dex;
        health = hp;
    }
    public void attack(object obj)
    {
        Human enemy = obj as Human;
        if(enemy == null)
        {
            Console.WriteLine("Failed Attack");
        }
        else
        {
            enemy.health -= strength * 5;
        }
    }
}

public class Wizard : Human
{
    public Wizard(string person) : base(null)
    {
        name = person;
        intelligence = 25;
        health = 50;
    }
    public void heal()
    {
        health += intelligence * 10;
        if(health>50)
        {
            health = 50;
        }
    }
    public void fireball(object obj)
    {
        Random rand = new Random();
        Human enemy = obj as Human;
        if(enemy == null)
        {
            Console.WriteLine("Failed Attack");
        }
        else
        {
            enemy.health -= rand.Next(20,30);
        }
    }
}

public class Ninja : Human
{
    public Ninja(string person) : base(null)
    {
        name = person;
        dexterity = 175;
    }
    public void steal(object obj)
    {
        attack(obj);
        health += 10;
        if(health > 100)
        {
            health = 100;
        }
    }
    public void get_away()
    {
        health -= 15;
    }
}

public class Samurai : Human
{
    public Samurai(string person) : base(null)
    {
        name = person;
        health = 200;
    }
    public void death_blow(object obj)
    {
        Human enemy = obj as Human;
        if(enemy == null)
        {
            Console.WriteLine("Failed Attack");
        }
        else if(enemy.health < 50)
        {
            enemy.health = 0;
        }
        else
        {
            attack(obj);
        }
        
    }
    public void meditate()
    {
        health = 200;
    }
}