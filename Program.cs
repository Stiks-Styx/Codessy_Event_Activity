using System.Text.RegularExpressions;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        Write("Enter a sentence: ");
        string input = ReadLine();

        string[] words = Regex.Split(input, @"[^a-zA-Z]+")/*.Where(w => w.Length > 0).ToArray()*/;

        /*
         *  The .Where(w => w.Length > 0).ToArray() is just another 
         *  way to filter out empty strings in an array. Mukang pang expert kaya nilagay ko
         *  
         *  The simple way to do it is like in line 23,
         *  We check if the index of the array is null or empty
         *  and if it's empty we do nothing.
        */
        foreach (var word in words)
        {
            if (word == null)
            {
                // do nothing if the word is empty/null like this "".
            }
            else
            {
                /*
                 *  A HashSet<T> in C# is a collection that stores unique elements 
                 *  and does not allow duplicates.
                 *  
                 *  Example "Hello" it will only store {h, e, l, o} because l is a duplicate
                 *  element.
                 *  
                 *  Unlike array we can store the same elements in one array
                 *  {"Alex", "Alex", "Nico", "Marky"} we can't do this in HashSet and Dictionary.
                 *  
                 *  A Dictionary<TKey, TValue> is a collection of key-value pairs,
                 *  Like HashSet it does not allow duplicates of the same element but only
                 *  for the first data type you assigned (TKey).
                 *  
                 *  Example below here i used Dictionary<char, int> frequency,
                 *  used it to count how many of the same letter is in a word.
                 *  Example if the word is "hello" it would look like this.
                 *  { "h", 1 },
                 *  { "e", 1 },
                 *  { "l", 2 },
                 *  { "o", 1 }
                 *  the value which is in this case is the integer it can be duplicated
                 *  because only the key is not allowed tobe duplicated.
                */
                HashSet<char> vowelsSet = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
                Dictionary<char, int> frequency = new Dictionary<char, int>();
                HashSet<char> uniqueVowels = new HashSet<char>();
                HashSet<char> uniqueConsonants = new HashSet<char>();
                int vowelCount = 0, consonantCount = 0;

                foreach (char c in word.ToLower())
                /*
                 * This condition loops on the current word and store the current char in c
                 * example hello at the start the value of c = h then the next loop will be
                 * c = e.
                */
                {
                    if (char.IsLetter(c))
                    {
                        if (!frequency.ContainsKey(c))
                        /*
                         * This condition checks if the current character does not exists
                         * in the dictionary.
                         * If the character is NOT in the dictionary, add it with a count of 0
                         * frequency[c] = 0;
                         * Example h will have a value of 0
                         * 
                         * else if the character already exists, increment its count,
                         * frequency[c]++;
                         * Example is l is Not in dictionary then Add l: 0, then increment l: 1
                         *            l is Already in dictionary then Increment → l: 2
                        */
                        {
                            frequency[c] = 0;
                        }
                        frequency[c]++;
                        

                        if (vowelsSet.Contains(c))
                        {
                            /*
                             * This if else statement is just to count how many vowels and consonant
                             * in the word 
                             * (vowelCount and consonantCount)
                             * and it also add the vowels and consonant on each HashSet
                             * (uniqueVowels and uniquesConsonants)
                             * Example "hello"
                             * 'h' is consonant since the if condition checks if the current character(h) is
                             * in vowelsSet which is (a, e, i, o, u)
                             * then its already false we then go to else increment the consonantCount (consonantCount++;) and
                             * add the current char(h) in the uniqueConsonants (uniqueVowels.Add(c);)
                            */
                            vowelCount++;
                            uniqueVowels.Add(c);
                        }
                        else
                        {
                            consonantCount++;
                            uniqueConsonants.Add(c);
                        }
                    }
                }

                WriteLine($"\nWord: {word}");
                WriteLine($"Vowel Count: {vowelCount}");
                WriteLine($"Consonant Count: {consonantCount}");
                WriteLine($"Unique Vowels: {string.Join(", ", uniqueVowels)}");
                WriteLine($"Unique Consonants: {string.Join(", ", uniqueConsonants)}");

                Write("Letter Frequency: ");
                foreach (var kv in frequency)
                {
                    /*
                     * This foreach statement will loop on frequency then print the current value
                     * which is assigned in kv
                     * Example
                     * frequency =
                     * { "h", 1 },
                     * { "e", 1 },
                     * { "l", 2 },
                     * { "o", 1 }
                     * on the first loop the value of kv will be { "h", 1}
                     * then when we print it with this 
                     * Write("Letter Frequency: ");
                     * Write($"{kv.Key}:{kv.Value}, ");
                     * 
                     * OUTPUT: Letter Frequency: h:1
                     * then the next loop the value of kv is { "e", 1}
                     * OUTPUT: Letter Frequency: h:1, e:1 etc
                    */
                    Write($"{kv.Key}:{kv.Value}, ");
                }
                WriteLine();
            }
        }
    }
}

