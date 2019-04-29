using System;

namespace String.Utility
{
    public class StringFunctions
    {
        public bool Palindrome(string word)
        {
            bool test = true;

            int count = 0;
            for (int i = 0; i < word.Length/2; i++)
            {
                while(char.IsLetterOrDigit(word[i]) == false)
                {
                    i++;
                }
                if (char.IsLetterOrDigit(word[i]))
                {
                    if (char.IsLetterOrDigit(word[word.Length - 1 - count]))
                    {
                        char a = word[i];
                        char b = word[word.Length - 1 - count];
                        int count1 = count;

                         int test1 = 0;

                        if (char.ToLower(word[i]) != char.ToLower(word[word.Length - 1 - count]))
                        {
                            test = false;
                            
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
            Console.WriteLine(f.Palindrome("Pa, p"));
        }
    }
}
