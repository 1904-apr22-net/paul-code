using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionTesting.Library
{
    // in C#, we have a lot of interfaces for collections
    // the most important is IEnumerable<T>. That one allows your class
    // to be put in a foreach loop.
    public class GenericCollection<T> : IEnumerable<T>
    {
        protected List<T> List { get; } = new List<T>();

        public GenericCollection()
        {
            // if we code no constructor on a class,
            // it has a default constructor automatically.
            // it is public, with no parameters, and has no contents.

            // as soon as we define any constructor, the default one goes away.
        }

        public GenericCollection(IEnumerable<T> coll)
        {
            // add everything from the collection to our list.
            List.AddRange(coll);
        }

        // generated from light bulb
        // we are delegating the calls to the list field.
        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)List).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)List).GetEnumerator();
    }
}
