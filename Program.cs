//Given a string, find the length of the longest substring without repeating characters.

//Example 1:
//Input: "abcabcbb"
//Output: 3 
//Explanation: The answer is "abc", with the length of 3. 

//Example 2:
//Input: "bbbbb"
//Output: 1
//Explanation: The answer is "b", with the length of 1.

//Example 3:
//Input: "pwwkew"
//Output: 3
//Explanation: The answer is "wke", with the length of 3. 
//             Note that the answer must be a substring, "pwke" is a subsequence and not a substring.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace longestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        //**********
        //TEST DRIVER
        //
        static void Main(string[] args)
        {
            //Prompt
            Console.WriteLine("This program finds the length of the longest substring.\nEnter a string!: ");
           
            //Get User Input
            string input = Console.ReadLine();

            //Call Length Of Longest Substring function
            LengthOfLongestSubstring(input);
        }

        public static int LengthOfLongestSubstring(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Input is empty, exiting...");
                return 0;
            }

            if (s == " " || s.Length == 1)
            {
                return 1;
            }

            //Declare globals
            Dictionary<char, bool> charactersInStringDictionary = new Dictionary<char, bool>();
            Dictionary<string, int> substringsDictionary = new Dictionary<string, int>();

            string longestSubstring = "";
            int lengthOfLongestSubstring = 0;
            bool result = false;

            //Loop through the length of string
            for (int i = 0; i < s.Length; i++)
            {
                //get specified char key from dictionary
                bool charExists = charactersInStringDictionary.TryGetValue(s[i], out result);

                //If character is repeated in substring

                if (charExists)
                {
                    //if 2 consecutive characters are the same
                    if (s[i] > 0 && (s[i] == s[i-1]) )
                    {
                        longestSubstring = "" + s[i];
                        lengthOfLongestSubstring = 1;
                    }
                    else
                    {
                        longestSubstring = "" + s[i - 1] + s[i]; //reset longest substring
                        lengthOfLongestSubstring = 2; //reset length of substring count
                    }
                }
                

                //If dictionary  DOES NOT contain the letter in the substring, add it to dictionary
                else if (!charactersInStringDictionary.ContainsKey(s[i]))
                {
                    charactersInStringDictionary.Add(s[i], true);

                    //Build the longest substring and incrememt substring length count             
                    longestSubstring = longestSubstring + s[i];
                    lengthOfLongestSubstring++;

                    //Add substring to dictionary for reference, KEY: substring length, VALUE: the substring itself
                    substringsDictionary.Add(longestSubstring, longestSubstring.Length);
                }
            }

            // get longest substring from dictionary, 'Length denoted by VALUE'
            // get longest substring using KEY
            if(substringsDictionary == null || substringsDictionary.Count == 0)
            {
                Console.WriteLine($"Length of longest substring: {s.Length}");
                Console.WriteLine($"Longest substring value: {s}");
                return s.Length;
            }
            
            lengthOfLongestSubstring = substringsDictionary.Values.Max();

            string longestSubstringKey = substringsDictionary.FirstOrDefault(x => x.Value == lengthOfLongestSubstring).Key;

            Console.WriteLine($"Length of longest substring: {longestSubstringKey.Length}");
            Console.WriteLine($"Longest substring value: {longestSubstringKey}");

            return lengthOfLongestSubstring;
        }
    }
}
