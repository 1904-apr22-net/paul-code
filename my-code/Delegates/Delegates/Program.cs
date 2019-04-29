using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            //var movie = new Movie();
            //movie.Name = "Infinity War";

            var movie = new Movie { Name = "Infinity War" };

            var moviePlayer = new MoviePlayer() { CurrentMovie = movie };

            // subscribe to the event:
            // first we need a function / method that should run
            // when the event occurs.

            // for the variable, the method itself is the value.
            // the type is, the delegate type defined in MoviePlayer.
            MoviePlayer.PlayFinishedHandler handler = EjectDisc;

            MoviePlayer.PlayFinishedHandlerWithName handler2 = EjectDisc;

            // subscribe to the event with +=
            // (why +=? because we are adding one function to a list of
            // other subscribing functions)
            //moviePlayer.PlayFinished += handler2;

            Action<string> handler3 = EjectDisc;
            Action handler5 = EjectDisc;
            moviePlayer.PlayFinished += handler3;

            Action<string> handler4 = name =>
            {
                Console.WriteLine("  lambda ");
            };

            moviePlayer.PlayFinished += handler4;
            moviePlayer.PlayFinishedNoString += handler5;
            moviePlayer.PlayReturn += () =>{ return "Paul"; };
            //moviePlayer.PlayFinished -= handler; // unsubscribe

            moviePlayer.Play();
        }

        static void ExploringLambda()
        {
            Action<int, int> printFirstOne = (a, b) => { Console.WriteLine(a); };
            printFirstOne(2, 4); // prints 2

            // apart from Action, we also have Func type.
            // Func is for all return types besides void.

            // function that adds 1 to the input.
            Action<int> AddOneAction = x => Console.WriteLine(x);
            Func<int, int> addOne = x => x + 1;
            Func<int, int> addOne2 = x => { return x + 1; }; // second way to write same thing
            var two = addOne(1); // 2

            // void return, three parameters
            //Action<string, int, bool>

            // bool return, string and int parameters.
            //Func<string, int, bool>

            // we use lambda expressions fairly often in C#,
            // especially with LINQ.
            var result = WrapWithPrints(addOne, 5); // print the inputs and the outputs
            Wrapper1(AddOneAction, (int)5);
        }

        static void Wrapper1<TInput, TResult>(Func<TInput, TResult>func, TInput input)
        {
            func(input);
        }
        static TResult WrapWithPrints<TInput, TResult>(Func<TInput, TResult> func, TInput input)
        {
            Console.WriteLine($"input: {input}");
            var result = func(input);
            Console.WriteLine($"result: {result}");
            return result;
        }

        static void EjectDisc()
        {
            Console.WriteLine("Ejecting the disc.");
        }

        static void EjectDisc(string name)
        {
            Console.WriteLine($"Ejecting disc {name}.");
        }
    }
}
