public class ProgramUI
{

    string[] blankGameArr = null;
    string[] gameArr = null;
    int numInWord = 0;
    bool gameRunning = true;
    int bodyHungCount = 0;
    int wordNum = 0;

    public void Run()
    {
        Game();
    }

    public void Game()
    {
        Console.Clear();

        string[] words = { "cherry", "apple", "blueberry", "pumpkin", "peanutbutter", "rhubarb" };

        Random rand = new Random();
        wordNum = rand.Next(0, 6); // .Next(min int{included in range}, max int{NOT included in range} )

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

            System.Console.WriteLine("\n\nGuess a letter: ");
            string userGuess = Console.ReadLine().ToLower();

            CheckForLetter(userGuess, gameArr);
        }

    }

    public void DisplayBody(int hangmanBody)
    {
        int triesLeft = 6 - hangmanBody;

        string[] sHints1 = { "I am red.", "I am typically made with cinnamon.", "I'm a beatboxing ______.", "I am normally made during the last few months of the year.", "You can have me on a sandwitch.", "I am almost always cooked with lots of sugar because I am very sour." };

        switch (hangmanBody)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Head added, {triesLeft} tries remaining.\n");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Torso added, {triesLeft} tries remaining.\n");
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine("(hint: types of pie)\n");
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Left arm added, {triesLeft} tries remaining.\n");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Right arm added, {triesLeft} tries remaining.\n");
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine($"Hint two: {sHints1[wordNum]} \n");
                break;
            case 5:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Left leg added, {triesLeft} tries remaining.\n");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 6:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Right leg added, {triesLeft} tries remaining.\n");
                System.Console.WriteLine("Game Over...\n");
                for (int i = 0; i < gameArr.Length; i++)
                {
                    System.Console.Write($"{gameArr[i]} ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine(" was the correct word.");
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
            System.Console.WriteLine("\n\nCongrats you got the word!\n");
            Console.ForegroundColor = ConsoleColor.White;
            gameRunning = false;
        }
        else
        {
            BlankDisplay();
        }
    }
    // public void HangmanDisplay()
    // {
    //     System.Console.WriteLine(@$"
    //             ________
    //            |        |
    //            |        |
    //            {h}        |
    //          {ra}{b}{la}        |
    //            {b}        |
    //         {rl} {ll}        |
    //                 ____|____");
    // }
    public void CorrectAnswer()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("Correct Guess!\n");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void IncorrectAnswer()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Sorry! Wrong guess\n");
        Console.ForegroundColor = ConsoleColor.White;
        bodyHungCount++;
        DisplayBody(bodyHungCount);
    }

}