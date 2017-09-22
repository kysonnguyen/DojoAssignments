using System;

namespace fundamentals_I
{
    class Program
    {
        static void Main(string[] args)
        {
            //prints 1-255
            for(int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("*****************************");

            //prints values from 1-100; divisible by 3 or 5, but not both
            for(int i=1; i<101; i++)
            {
                if(!(i % 15 == 0))
                {
                    if(i % 3 == 0 || i % 5 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            Console.WriteLine("*****************************");
            
            //Fizz and Buzz
            for(int i=1; i<101; i++)
            {
                if(i % 15 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if(i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if(i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
            }
            Console.WriteLine("*****************************");
            
            //Optional 1
            int count3 = 3;
            int count5 = 5;
            for (int i = 1; i < 101; i++)
            {
                count3--;
                count5--;
                if (count3 == 0 && count5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                    count3 = 3;
                    count5 = 5;
                }
                else if (count3 == 0)
                {
                    Console.WriteLine("Fizz");
                    count3 = 3;
                }
                else if (count5 == 0) {
                    Console.WriteLine("Buzz");
                    count5 = 5;
                }
            }
            Console.WriteLine("*****************************");
            
            //Optional 2
            Random rand = new Random();
            for(int i = 0; i<10; i++)
            {
                int num = rand.Next(1,101);
                if(num % 15 == 0)
                {
                    Console.WriteLine(num+": FizzBuzz");
                }
                else if(num % 3 == 0)
                {
                    Console.WriteLine(num+": Fizz");
                }
                else if(num % 5 == 0)
                {
                    Console.WriteLine(num+": Buzz");
                }
            }

        }
    }
}
