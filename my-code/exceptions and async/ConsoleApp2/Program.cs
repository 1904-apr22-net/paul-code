using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface InterOne
    {
        void InterfaceFunction();
    }
    public class ImplementInterface : InterOne
    {
        public void InterfaceFunction()
        {
            Console.WriteLine("I'm a bitch");
        }
    }
    public class Program
    {
        static async Task Main(string[] args)
        {
            string a = "test.txt";
            FileStream fs = new FileStream( a, FileMode.Append, FileAccess.Write);
                // if(File.exists(a){}
            using (var w = new StreamWriter(fs))
            {
                w.WriteLine("Another Line");
            }

            try
            {
                throwOrNah("Paul");
            }
            catch(CustomEx ex)
            {
               Console.WriteLine(ex.ToString());
                
            }
            finally{
                Console.WriteLine("Im here forever bitch");
                Console.WriteLine();
            }

            try
            {
                int x = 5;
                int y = 1;
                int z = x / y;
            }

            catch (System.DivideByZeroException ex)
            {
                Console.WriteLine(ex.ToString());
                
            }

            finally
            {
                Console.WriteLine("idgaf if u divide by zero");
            }

            List<string> list = new List<string>() { "Paul", "Mark", null };
            list.RemoveNull();


            Console.WriteLine("Before");
            new Thread(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine("During");
            }).Start();
            Console.WriteLine("After");

            Thread.Sleep(1000); 
           // Thread.CurrentThread.Name = "Main";
            //Action A1 = throwOrNah;
            //Action A2 = doSomething;

           Task T1 = doSomething();
            await Task.Run(() => { Thread.Sleep(5000); Console.WriteLine("hello world"); });
            Task T2 = doSomething();
            Console.WriteLine("before");
    
            //Task.WaitAll(T1, T2);
            Console.WriteLine("after");
            // T1.Start();

            // T1.Start();
            // T2.Start();

           

            await T1;

             await T2;
            // var task = Task.Run(async () => { await doSomething(); });

            InterOne InterName = new ImplementInterface();
            InterName.InterfaceFunction();
        }
        private static Task Method()
        {
           return Task.Run(() => { Thread.Sleep(2000);});
        }
        public async static Task doSomething()
        {
            await Method();
            Console.WriteLine("Output Method");
            Console.WriteLine("1");
            await Task.Delay(2000);
            Console.WriteLine("2");
            await Task.Delay(2000);
            Console.WriteLine("3");
        }
        public static void throwOrNah(String a)
        {
            if(a == "Paul")
            {
                CustomEx TooCool = new CustomEx("This code is just too great");
                throw TooCool;
            }

            else
            {
                Console.WriteLine("This code is alright");
            }
        }
        public static void throwOrNah()
        {
            string a = "Paul";
            if (a == "Paul")
            {
                CustomEx TooCool = new CustomEx("This code is just too great");
                throw TooCool;
            }

            else
            {
                Console.WriteLine("This code is alright");
            }
        }

    }
   
}
