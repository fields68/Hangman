public class ProgramUI
{
    string test = "This is a test";
    public void Run()
    {
        test1();
        // DisplayBody();
        // Game();
    }

    public void test1()
    {
        System.Console.WriteLine(test);

    }

    public void Game()
    {
        string[] words = { "compete", "sector", "explain", "passage", "inflate", "patient", "pillow" };

        Random rand = new Random();
        int wordNum = rand.Next(0, 8);

        string gameWord = words[wordNum];

        string[]? gameArr = null;
        // changes string array to match the number of letters in char array
        Array.Resize(ref gameArr, gameWord.Length);
        for (int i = 0; i < gameWord.Length; i++)
        {
            gameArr[i] = new string(gameWord[i], 1);
        }

        string[]? blankGameArr = null;
        Array.Resize(ref blankGameArr, gameArr.Length);
        // Changes the letters in words to "_" for player to guess and fill in
        for (int i = 0; i < gameArr.Length; i++)
        {
            blankGameArr[i] = "_";
            System.Console.WriteLine($"blankGameArr: {blankGameArr[i]}");
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

    public void BlankDisplay()
    {

    }

    public void CheckForLetter(string guess, string[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == guess)
            {
                arr[i] = guess;
                // BlankDisplay(arr[i]);
                goto DoneWithForLoop;
            }
            else
            {
                System.Console.WriteLine("Sorry wrong answer!");
            }
        }
    DoneWithForLoop:
        System.Console.WriteLine("Correct Guess!");
    }
}