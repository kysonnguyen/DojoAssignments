using System;
using System.Collections.Generic;
namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //3 basic arrays
            int[] numArr =  new int[10] {0,1,2,3,4,5,6,7,8,9};
            string[] nameArr = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] boolArr = new bool[10];
            for(int i = 0; i<10; i+=2)
            {
                boolArr[i] = true;
            }

            //Multiplication Table
            int[,] mulTab = new int[10,10];
            for(int i=0; i<10; i++)
            {
                for(int k=0; k<10; k++)
                {
                    mulTab[i,k] = (i+1) * (k+1);
                }
            }

            //Flavors List
            List<string> flavors = new List<string>();
            flavors.Add("strawberry");
            flavors.Add("vanilla");
            flavors.Add("chocolate");
            flavors.Add("coffee");
            flavors.Add("green tea");
            
            Console.WriteLine(flavors.Count);
            Console.WriteLine("Third flavor in list: " + flavors[2]);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);

            //User Info Dict
            Dictionary<string,string> users = new Dictionary<string,string>();
            Random rand = new Random();
            foreach (string name in nameArr)
            {
                users[name] = flavors[rand.Next(flavors.Count)];
            }
            foreach (var user in users)
            {
                Console.WriteLine(user.Key + " - " + user.Value);
            }


        }
    }
}
