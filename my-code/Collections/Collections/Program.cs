using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int num = 123;
            Random r = new Random();

            //c# has var for compile time inference 
            //compiler guess based on what is = to right 
            //var num = 123;
            //var r2 = newRandom();


            //Array();
            //Lists();
            OtherCollections();
        }

        private static void OtherCollections()
        {
            var set = new HashSet<string> { "abc", "ab", "ab" };
            //no defined order, no duplicates
            string s = "hello";

            


            var number = set.Count;
            foreach (var item in set)
            {
                //no guarentee of order
                Console.WriteLine($"{item}");
            }

            // "map" or "dictionary"
            var numberOfTimesSeenWord = new Dictionary<string, int>(); //string key
            numberOfTimesSeenWord["food"] = 1;
            numberOfTimesSeenWord["pc"] = 3;

           //store value for each key
           //in dict each key will have one value at that spot
           //hashset and dict are implemented with hashtables
           //very cheap/fast
        }

        private static void Lists()
        {
            // first, non generic list --> arraylist
            ArrayList numList = new ArrayList();
            //changeable length, starting out at size 0
            //technically list of object
            numList.Add(2);
            numList.Add(5);
            numList.Add(8);

            numList.Remove(8);

            //var num = numList[0];
            //var twice = num + num;  var thinks it is object

            //casting can fix issues
            var num = (int)numList[0];
            var twice = num + num;

            //implicit and explicit
            double d = 4;

            //C# knows that i can't lose info going from int to double
            //automatic (implicit

            // int n = d --> could lose data
            //explicit cast
            int n = (int)d;

            //you can cast implicitly from child to parent class
            Object o = new Random(); // implicit casting (upcasting)
            //downcasting is explicit
            //r = o; will fail if not random


            //generic list
            //write code for many types, which type can be filled in when needed (template)

            var genericIntList = new List<int>();
            genericIntList.Add(3);
            var value = genericIntList[0];

            List<List<string>> twoDStringList = new List<List<string>>
            {
                new List<String> {"1", "3",},
                new List<String> {"2", "4",}

            };

            //initialization like array that calls .add under the hood
        }

        private static void Array()
        {
            int[] myNums = new int[5]; //array of int --size 5
            for (int i = 0; i < myNums.Length; i++)
            {
                myNums[i] = i * i;
                Console.WriteLine($"{myNums[i]}");
            }

            var count = int.Parse(Console.ReadLine());
            var array = new int[count];
            var names = new[] { "Nick", "fred", "bill" };
            //dynamic length -- can't be changed after

            foreach(var value in array)
            {
                Console.WriteLine($"{value}");
            }

            //jagged Arrays 
            int[][] twoD = new int[3][];
            twoD[0] = new int[4];
            twoD[1] = new[] { 1, 6, 3, 6 };
            twoD[2] = new int[4];

            var x = twoD[0][1];

            int[,] twoMulti = new int[4, 5];
            twoMulti[2, 3] = 5;

            //usually avoid arrays unless performance need


        }
    }
}
