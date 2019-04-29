using System;

namespace String.Utility
{
    public class StringFunctions
    {
        public bool Palindrome(string word)
        {
            bool test = true;
            char[] reversed = word.ToCharArray();
            Array.Reverse(reversed);
            string RString = new string(reversed);
            int count = 0;
            for (int i = 0; i < word.Length/2; i++)
            {
                while(char.IsLetterOrDigit(word[i]) == false)
                {
                    i++;
                }
                if (char.IsLetterOrDigit(word[i]))
                {
                    if (char.IsLetterOrDigit(RString[word.Length - 1 - count]))
                    {
                        if (char.ToLower(word[i]) != char.ToLower(RString[word.Length - 1 - count]))
                        {
                            test = false;
                            char a = word[i];
                            char b = RString[word.Length - 1 - count]; 
                        }
                    }
                    
                    count++;

                }
                
            }
            return test;
        }
            static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StringFunctions f = new StringFunctions();
            //f.Palindrome("Paul");
            Console.WriteLine(f.Palindrome("Paul"));
        }
    }
}
