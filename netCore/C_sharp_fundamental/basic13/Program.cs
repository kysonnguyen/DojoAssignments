using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        //print 1-255
        public static void print1to255(){
            for( int i=1; i<256; i++){
                Console.WriteLine(i);
            }
        Console.WriteLine("*************************************");
        }
        
        //print odd 1-255
        public static void printOdds(){
            for( int i=1; i<256; i+=2){
                Console.WriteLine(i);
            }
        Console.WriteLine("*************************************");
        }
        
        //print sum
        public static void printSum(){
            int sum = 0;
            for( int i=0; i<256; i++){
                sum = sum + i;
                Console.WriteLine("New number: " + i + " Sum: " + sum);
            }
        Console.WriteLine("*************************************");
        }

        //interating through an Array
        public static void arrInt(int[] arr){
            for(int i=0; i<arr.Length; i++){
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine("*************************************");
        }

        //find max
        public static void arrMax(int[] arr){
            int max = arr[0];
            foreach( int num in arr){
                if(num > max){
                    max = num;
                }    
            }
            Console.WriteLine("Max value in array is: " + max);
            Console.WriteLine("*************************************");
        }

        //find avg
        public static void arrAvg(int[] arr){
            int sum = 0;
            foreach( int num in arr){
                sum += num;    
            }
            double avg = (double)sum/arr.Length;
            Console.WriteLine("The average is: " + avg);
            Console.WriteLine("*************************************");
        }
        
        //arr of odd 1-255
        public static int[] arrOdd(){
            List<int> newArr = new List<int>();
            for(int i=1; i<256; i++){
                if(i % 2 != 0){
                    newArr.Add(i);
                } 
            }
            return newArr.ToArray();
            Console.WriteLine("*************************************");
        }

        //greater than Y
        public static void greaterY(int[] arr, int y){
            int count = 0;
            foreach( int num in arr){
                if(num > y){
                    count++;
                }
            }
            Console.WriteLine($"There are {count} numbers greater than {y}");
        }
    
        //square the values
        public static int[] arrSqr(int[] arr){
            List<int> newArr = new List<int>();
            foreach(int num in arr){
                newArr.Add(num * num); 
            }
            return newArr.ToArray();
            Console.WriteLine("*************************************");
        }

        //eliminate neg num
        public static int[] replaceNeg(int[] arr){
            for(int i=0; i<arr.Length; i++){
                if (arr[i]<0){
                    arr[i] = 0;
                }
            }
            return arr;
        }

        //min, max, avg
        public static void MinMaxAvg(int[] arr){
            int sum = 0;
            int min = arr[0];
            int max = arr[0];
            foreach(int num in arr){
                sum += num;
                if(min>num){
                    min = num;
                }
                if(max<num){
                    max = num;
                }
            }
            Console.WriteLine($"Min is {min}; Max is {max}; Average is {(double)sum/(double)arr.Length}");
        }

        //shift arr val
        public static int[] shiftArr(int[] arr){
            for(int i=0; i<arr.Length-1; i++){
                arr[i] = arr[i+1];
            }
            arr[arr.Length-1] = 0;       
            return arr;
        }

        //number to string
        public static object[] NumToStr(object[] arr){
            for(int i=0; i<arr.Length; i++){
                if( (int)arr[i] < 0 ){
                    arr[i] = "Dojo";
                }
            }
            return arr;
        }

        public static void Main(string[] args)
        {
            print1to255();
            printOdds();
            printSum();
            int[] arr = new int[] {1,5,3,0,-6,7,-9};
            arrInt(arr);
            arrMax(arr);
            arrAvg(arr);
            arrOdd();
            greaterY(arr, 4);
            arrSqr(arr);
            replaceNeg(arr);
            shiftArr(arr);
            MinMaxAvg(arr);
            object[] arr2 = new object[]{-3,4,-5,6};
            NumToStr(arr2);
        }
    }
}
