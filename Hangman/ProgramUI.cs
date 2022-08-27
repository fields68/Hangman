public class ProgramUI
{

    string[] blankGameArr = null;
    string[] gameArr = null;
    int numInWord = 0;
    bool gameRunning = true;
    int bodyHungCount = 0;

    public void Run()
    {
        Game();
    }

    public void Game()
    {
        Console.Clear();

        string[] words = { "cherry", "apple", "blueberry", "pumpkin", "peanutbutter", "rhubarb" };

        Random rand = new Random();
        int wordNum = rand.Next(0, 6); // .Next(min int{included in range}, max int{NOT included in range} )

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
            System.Console.Write($"{blankGameArr[i]} ");
        }

        while (gameRunning)
        {

            System.Console.WriteLine("\nGuess a letter: ");
            string userGuess = Console.ReadLine().ToLower();

            CheckForLetter(userGuess, gameArr);
        }

    }

    public void DisplayBody(int hangmanBody)
    {
        switch (hangmanBody)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Head added");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Torso added");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Left arm added");
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine("\n(hint: types of pie)\n");
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Right arm added");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 5:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Left leg added");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 6:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Right leg added");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 7:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Game Over...");
                Console.ForegroundColor = ConsoleColor.White;
                gameRunning = false;
                break;
            default:
                break;
        }
    }

    public void BlankDisplay()
    {
        for (int i = 0; i < gameArr.Length; i++)
        {
            System.Console.Write($"{blankGameArr[i]} ");
        }
    }
    public void BlankDisplayUpdate(int indexLetter, string letterAnswer)
    {
        blankGameArr[indexLetter] = letterAnswer;
    }

    public void CheckForLetter(string guess, string[] arr)
    {
        int incorrectGuess = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == guess && blankGameArr[i] == "_")
            {
                Console.Clear();

                BlankDisplayUpdate(i, guess);
                CorrectAnswer();
                numInWord++;
            }
            else { incorrectGuess++; }
        }
        if (incorrectGuess == arr.Length)
        {
            Console.Clear();

            IncorrectAnswer();
        }
        else
        {
        }

        if (numInWord == arr.Length)
        {
            Console.Clear();

            BlankDisplay();
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("\nCongrats you got the word!");
            Console.ForegroundColor = ConsoleColor.White;
            gameRunning = false;
        }
        else
        {
            BlankDisplay();
        }
    }
    public void CorrectAnswer()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("Correct Guess!");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void IncorrectAnswer()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Sorry! wrong answer");
        Console.ForegroundColor = ConsoleColor.White;
        bodyHungCount++;
        DisplayBody(bodyHungCount);
    }

}