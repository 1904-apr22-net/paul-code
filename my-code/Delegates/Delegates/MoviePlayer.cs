using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Delegates
{
    public class MoviePlayer
    {
        public Movie CurrentMovie { get; set; }

        // movie player will allow other classes
        // to subscribe to its PlayFinished event
        // using some event handler.

        // first we define the type of the event handler:
        public delegate void PlayFinishedHandler();
        // it is a "delegate" type, which is, a method with certain params
        // and return type.
        // this one has zero parameters, and no return (void).

        public delegate void PlayFinishedHandlerWithName(string name);

        // then, we define the event.
        //public event PlayFinishedHandlerWithName PlayFinished;
        public event Action<string> PlayFinished;
        public event Action PlayFinishedNoString;
        public event Func<string> PlayReturn;
        // the event is declared as having a particular kind of event handler
        // method that can be subscribed to it with: the PlayFinishedHandler.

        // "Action<string>" represents, a void-return function with 1 string param.

        public void Play()
        {
            //Console.WriteLine("Playing inserted movie " + CurrentMovie.Name);

            // string interpolation syntax
            // start the string with $, and you can use {} to switch "back"
            // to C# code.
            Console.WriteLine($"Playing inserted movie {CurrentMovie.Name}");

            Thread.Sleep(3000); // wait for 3 seconds

            // then, we fire the event.
            //PlayFinished();
            // this looks the same as a method call, but it is an event.
            // it results in, all the subscribed functions being called.

            // if there are no subscribers, firing the event is a null exception.
            // so, we never fire an event just like that, instead, we check for null.
            //if (PlayFinished != null)
            //{
            //    PlayFinished();
            //}
            // must provide arguments according to the parameters on that delegate type.
            PlayFinished?.Invoke(CurrentMovie.Name);
            PlayFinishedNoString?.Invoke();
            Console.WriteLine(PlayReturn?.Invoke());
            // it turns out that events have an "Invoke" method on them
            // which does the same as what we wrote before

            // there is a null-conditional operator "?." which is pretty cool...
            // if the thing before the ?. is null, then overall it returns null / does nothing.
            // otherwise, it will do member access like "." usually does.

            //if (obj != null)
            //{
            //    if (obj.prop != null)
            //    {
            //        if (obj.prop.asdf != null)
            //        {
            //            // use obj.prop.asdf
            //        }
            //    }
            //}

            //obj?.prop?.asdf?.whatever

            // there's another one called null-coalescing operator
            // ??
        }
    }
}
