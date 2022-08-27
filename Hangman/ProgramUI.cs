public class ProgramUI
{

    string[]? blankGameArr = null;
    string[]? gameArr = null;

    public void Run()
    {
        DisplayBody();
        Game();
    }

    public void Game()
    {
        string[] words = { "compete", "sector", "explain", "passage", "inflate", "patient", "pillow" };

        Random rand = new Random();
        int wordNum = rand.Next(0, 8);

        string gameWord = words[wordNum];

        // changes string array to match the number of letters in char array
        Array.Resize(ref gameArr, gameWord.Length);
        for (int i = 0; i < gameWord.Length; i++)
        {
            gameArr[i] = new string(gameWord[i], 1);
        }

        Array.Resize(ref blankGameArr, gameArr.Length);
        // Changes the letters in words to "_" for player to guess and fill in
        for (int i = 0; i < gameArr.Length; i++)
        {
            blankGameArr[i] = "_";
            System.Console.Write(blankGameArr[i]);
        }

        System.Console.WriteLine("Guess a letter:");
        string userGuess = Console.ReadLine();

        CheckForLetter(userGuess, gameArr);

    }

    public void DisplayBody()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Red;

    }

    public void BlankDisplay(int indexLetter, string letterAnswer)
    {
        blankGameArr[indexLetter] = letterAnswer;

        for (int i = 0; i < gameArr.Length; i++)
        {
            System.Console.WriteLine(blankGameArr[i]);
        }
    }

    public void CheckForLetter(string guess, string[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == guess)
            {
                BlankDisplay(i, guess);
                goto DoneWithForLoop;
            }
            else
            {
            }
        }
    DoneWithForLoop:
        System.Console.WriteLine("Correct Guess!");
    }
}