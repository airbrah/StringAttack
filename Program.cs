using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Created by Eric Maso (airbrah)
//StringAttack is a simple small game where the player needs to enter an exact sentence or phrase output by the program before the time runs out. Player will be scored based on how they did
//INCOMPLETE:
//NEED TIMER
//NEED RESULT CHECK(SCORE) [see the player's mistake; calculate score based on performance]
namespace StringAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Initialize*/
            Console.ForegroundColor = ConsoleColor.Green;

            /*Variables*/
            //THE WORD BANK; ADD MORE WORDS HERE
            string[] wordBank = { "Hello", "Goodbye", "Thanks", "Good weather", "Bad weather",
                                "Greetings", "Google", "Stand", "JoJo", "Dio"}; 
            string[] userResponses = new string[wordBank.Length]; //new array with length of wordBank; hold user input
            string userInput = ""; //user inputs stored in this string
            int[] track = new int[wordBank.Length]; //makes int array the same length as phrases
            for (int i = 0; i < wordBank.Length; i++) //makes a count of itself. This array will be used to keep track of which item to get from both wordBank and userResponses arrays
            {
                track[i] = i;
            }
            Shuffle(track); //Shuffle method to randomize the track numbers
            int hScore = 0; //actual score; Hold Score

            /*TEMP SPACE*/

            /*Intro*/
            Console.WriteLine("Welcome to StringAttack!");
            Console.WriteLine("Created by airbrah");
            Console.WriteLine("Press any key to start game...");
            Console.ReadKey();

            /*Game Start*/
            bGame: //LABEL bGame
            Console.Clear();
            Console.Write("Ready... ");
            System.Threading.Thread.Sleep(1000);
            Console.Write("Set... ");
            System.Threading.Thread.Sleep(1000);
            Console.Write("Go... ");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            /*The Main Game in Action*/
            for(int i = 0; i < wordBank.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green; //display word is green
                Console.WriteLine(wordBank[track[i]]); //display word
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;//display user input as white
                userInput = Console.ReadLine();
                userResponses[track[i]] = userInput; //store userInput into array
                if(userResponses[track[i]] == wordBank[track[i]]) //Score
                {
                    hScore = hScore + 5;
                }
                Console.Clear();
            }

            /*Finish*/
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Finished!");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            /*Calculate score and compare arrays*/
            //Score

            /*Display results*/
            //Score
            Console.WriteLine("Score");
            for (int dScore = 0; dScore <= hScore; dScore++)//display score flow; Display Score
            {
                Console.Write("\r" + dScore); //score update
                System.Threading.Thread.Sleep(50); // makes it slower to shower increase in number instead of it just jumping up to x number
            }
            Console.WriteLine();

            //Show results of what was typed
            for (int i = 0; i < wordBank.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(wordBank[track[i]]); //wordBank word
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(userResponses[track[i]]); //user's response to word
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.Green;

            /*Go again?|END OF GAME*/
            Console.WriteLine();
            playAgain: //LABEL playAgain
            Console.Write("Want to replay the game? (Y/n): ");
            userInput = Console.ReadLine();
            if (userInput == "Y")
            {
                hScore = 0; //clear score
                Shuffle(track); //re-shuffle array
                goto bGame; //go back to the beginning of the game
            }
            else if (userInput == "n")
            {
                Console.Clear();
                Console.WriteLine("Thanks for playing!");
                System.Threading.Thread.Sleep(1500);
                Environment.Exit(0); //Quit game
            }
            else
            {
                goto playAgain; //ask the question again if any other response
            }
        }

        public static void Shuffle(int[] t)
        {
            int c = t.Length;
            Random rnd = new Random();

            for (int i = 0; i < c; i++)
            {
                suffleNum(t, i, i + rnd.Next(c - i)); //sends track array, interval of loop and a random number in between legth track/intervall of loop
            }
        }

        public static void suffleNum(int[] t, int a, int b)
        {
            int hold = t[a]; //keeps track of element in array
            t[a] = t[b]; //says that element in random number is now where loop interval is
            t[b] = hold; //puts hold number to replace old
        }
    }
}
