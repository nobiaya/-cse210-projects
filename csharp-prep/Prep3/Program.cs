using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;
            int guess = -1;

            Console.WriteLine("I have chosen a magic number between 1 and 100.");

            while (guess != magicNumber)
            {
                Console.Write("Enter your guess: ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Too low! Try a higher number.");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Too high! Try a lower number.");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You've guessed the magic number in {guessCount} attempts.");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = (response == "yes");
        }

        Console.WriteLine("Thank you for playing! Goodbye.");
    }
}
