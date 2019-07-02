using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] three = { "ace", "arc", "bad", "box", "coy", "cub", "dew", "elf", "fab", "flu", "gem", "gym", "hog", "icy", "jaw", "kid", "law", "mac", "nip", "oak", "paw", "pig", "ray", "saw", "sly", "the", "vet", "wex", "zip", "via" };
            string[] four = { "able", "acid", "bank", "blow", "bomb", "bowl", "cook", "crew", "dawn", "drew", "evil", "exit", "fate", "flow", "give", "heat", "hige", "iron", "kick", "lift", "main", "news", "know", "oral", "peak", "rank", "sake", "view", "wave", "vary" };
            string[] five = { "alert", "angel", "baker", "below", "claps", "dates", "cried", "earth", "reset", "hater", "three", "items", "emits", "heros", "leaps", "heart", "three", "slate", "weird", "wines", "point", "risen", "piers", "nails", "plane", "tires", "toner", "verse", "fruit", "melon" };
            string[] six = { "actors", "abroad", "battle", "became", "belief", "branch", "career", "column", "debate", "deputy", "device", "escape", "fought", "guilty", "growth", "honest", "injury", "invest", "leaves", "luxury", "modest", "narrow", "oxford", "proven", "reward", "vision", "wright", "victim", "unique", "valley" };
            string[] seven = { "account", "arrange", "bandage", "catalog", "content", "decline", "engrave", "history", "insides", "journal", "letters", "listing", "profile", "program", "remains", "retreat", "stagger", "stumble", "theater", "ribbons", "trained", "buzzing", "fizzing", "drizzle", "lizzard", "jumping", "jogging", "checkup", "cheques", "zooming" };

            Console.WriteLine("7 letter length : " + seven.Length);
            Console.WriteLine("5 letter length : " + five.Length);
            Console.WriteLine("This is an anagram game. You have 5 guesses try to guess the word.\nThere are 5 different levels...");
            Console.Write(" 1. 3 letter words\n 2. 4 letter words\n 3. 5 letter words\n 4. 6 letter words\n 5. 7 letter words\n");
            Console.WriteLine("Choose your level of difficulty (1,2,3,4,or 5)");
            int difficulty = Convert.ToInt32(Console.ReadLine());
            string[] level = new string[7];
            if (difficulty == 1)
            {
                level = three;
                GenerateWord(level);
            }
            else if (difficulty == 2)
            {
                level = four;
                GenerateWord(level);
            }
            else if (difficulty == 3)
            {
                level = five;
                GenerateWord(level);
            }
            else if (difficulty == 4)
            {
                level = six;
                GenerateWord(level);
            }
            else if (difficulty == 5)
            {
                level = seven;
                GenerateWord(level);
            }
            else
            {
                Console.WriteLine("Unknown input...\n Application closing...");
                Console.ReadLine();
                closeApp();
            }
        }

        static void GenerateWord(string[] level)
        {/*// this makes sure every item in the array are all 7 letters long
            for (int i = 0; i < wordArray.Length; i++)
            {
                if (wordArray[i].Length != 7)
                {
                    Console.WriteLine("ERROR -> " + i);
                }
            }*/
            int guess = 0;
            Random random = new Random();
            int generatedPosition = random.Next(0, level.Length);
            //Console.WriteLine("Random position = " + generatedPosition);
            string generatedWord = level[generatedPosition];
            // Console.WriteLine("Random word = " + generatedWord);
            //Console.ReadLine();

            int len = generatedWord.Length;
            string shuffled = new string(generatedWord.OrderBy(r => random.Next()).ToArray());      // this randomly shuffles the word selected
            int count = 1;
            Console.WriteLine("Anagram " + count + " is " + shuffled);
            GetGuess(level, shuffled, generatedWord, guess);

        }

        static void GetGuess(string[] level, string shuffled, string generatedWord, int guess)
        {
            guess = guess + 1;
            Console.Write("What do you think the word is :");
            string userGuess = Console.ReadLine();

            if (userGuess.Length > level[1].Length || userGuess.Length < level[1].Length)
            {
                Console.Write("Incorrect input. Try again : ");
                userGuess = Console.ReadLine();
                if (userGuess.Length > level[1].Length || userGuess.Length < level[1].Length)
                {
                    Console.WriteLine("Incorrect input again!!\n Closing application...");
                    Console.ReadLine();
                    closeApp();
                }
                else
                {
                    CheckAnswer(level, shuffled, generatedWord, userGuess, guess);
                }

            }
            else
            {
                CheckAnswer(level, shuffled, generatedWord, userGuess, guess);
            }

        }
        static void CheckAnswer(string[] level, string shuffled, string generatedWord, string userGuess, int guess)
        {

            int guessLeft = 5 - guess;
            if (userGuess == generatedWord)
            {
                Console.WriteLine("Congrats!! You have guessed correctly!!!");
                Console.ReadLine();
                GenerateWord(level);
            }
            else if (guessLeft == 0)
            {
                Console.WriteLine("Unlucky you have ran out of guesses!! The word was : " + generatedWord);
                Console.ReadLine();
                closeApp();
            }
            else if (guessLeft > 0)
            {
                Console.WriteLine("Better luck next guess!! You have " + guessLeft + " guesses left");
                Console.ReadLine();
                GetGuess(level, shuffled, generatedWord, guess);
            }
        }
        static void closeApp()
        {
        }
    }
}
