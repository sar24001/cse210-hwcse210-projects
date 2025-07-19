using System;

class Program
{
    static void Main(string[] args)
    {
       string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // Generate a random magic number from 1 to 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); // upper bound is exclusive

            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("Guess My Number Game!");
            Console.WriteLine("I'm thinking of a number between 1 and 100...");

            // Loop until the user guesses the number
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask if the user wants to play again
            Console.Write("Would you like to play again? (yes/no): ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing! 🎉");
    }
}