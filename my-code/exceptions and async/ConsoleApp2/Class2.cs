using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public static class Class2
    {
        public static void RemoveNull(this List<string> a)
        {
            //IEnumerable<string> newList = a.Where(x=>x != null && char.ToLower(x[0]) == 'p');
            //IEnumerable<string> newList = a.Where(x=>x != null);
            //a.Clear();
            //a = newList.ToList();
            a.RemoveAll(item => item == null);
        }
    }
}
