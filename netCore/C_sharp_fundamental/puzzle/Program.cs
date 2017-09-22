using System;
using System.Collections.Generic;

namespace puzzle
{
    class Program
    {
        //Random Array
        public static void RandomArray(){
            int[] arr = new int[10];
            Random rand = new Random();
            for(int i=0; i <10; i++){
                arr[i] = rand.Next(5,25);  
            }
            int min = arr[0];
            int max = arr[0];
            int sum = 0;
            for(int i=0; i<10; i++){
                if(min > arr[i]){
                    min = arr[i];
                }
                if(max < arr[i]){
                    max = arr[i];
                }
                sum += arr[i];
            }
            Console.WriteLine($"Min: {min}; Max: {max}; Sum: {sum}");
        }

        //Coin Flip
        public static string TossCoin(){
            Random rand = new Random();
            Console.WriteLine("Tossing a Coin!");
            string result;
            int toss = rand.Next(2);
            if(toss == 1){
                result = "Head";
            }
            else{
                result = "Tail";
            }
            Console.WriteLine(result);
            return result;
        }

        public static double TossMultipleCoin(int num){
            int count = 0;
            Random rand = new Random();
            for(int i = 0; i < num; i++){
                string result = TossCoin();
                if(result == "Head"){
                    count += 1;
                }
            }
            double ratio = (double)count/(double)num;
            Console.WriteLine(ratio);
            return ratio;
        }

        //names
        public static string[] Names(){
            string[] names = new string[]{"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            List<string> new_names = new List<string>();
            string line = new String('*', 30);
            Random rand = new Random();

            //shuffle
            for(int i = 0; i < 20; i++){
                int idx1 = rand.Next(names.Length);
                int idx2 = rand.Next(names.Length);
                string temp = names[idx1];
                names[idx1] = names[idx2];
                names[idx2] = temp; 
            }
            for(int k=0; k<5; k++){
                Console.WriteLine(names[k]);
            }

            //new array with names of > 5 characters
            Console.WriteLine(line);
            foreach(string name in names){
                if(name.Length > 5){
                    new_names.Add(name); 
                }
            }
            string[] new_array = new_names.ToArray();
            foreach(string value in new_array){
                Console.WriteLine(value);
            }
            return new_array;
        }
        static void Main(string[] args)
        {
            string line = new String('*', 30);
            RandomArray();
            Console.WriteLine(line);
            int num = 100;
            TossMultipleCoin(num);
            Console.WriteLine(line);
            Names();
        }
    }
}
