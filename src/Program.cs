namespace SL;

internal class Program
{
    private const int FrameDelay = 30;
    private const int TrainWidth = 85;

    static void Main(string[] args)
    {
        try
        {
            RunTrainAnimation();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            ResetConsole();
        }
    }

    static void RunTrainAnimation()
    {
        ConfigureConsole();

        int trainPosition = Console.WindowWidth;
        int endPosition = -TrainWidth;

        // Cache train lines for better performance
        string[] train = GetTrainArt();
        int startY = CalculateVerticalPosition(train.Length);

        while (trainPosition > endPosition)
        {
            // Check for user interrupt
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Q)
                    break;
                if (key.Key == ConsoleKey.Spacebar)
                    Console.ReadKey(true); // Pause until next key
            }

            Console.Clear();
            DrawTrain(train, trainPosition, startY);
            Thread.Sleep(FrameDelay);
            trainPosition--;
        }
    }

    static void ConfigureConsole()
    {
        Console.CursorVisible = false;
        Console.Clear();

        // Set console size if possible (Windows only)
        try
        {
            if (OperatingSystem.IsWindows() && Console.WindowWidth < 120)
            {
                Console.SetWindowSize(Math.Min(120, Console.LargestWindowWidth),
                                     Math.Min(30, Console.LargestWindowHeight));
            }
        }
        catch
        {
            // Ignore if unable to set window size
        }
    }

    static void ResetConsole()
    {
        Console.CursorVisible = true;
        Console.Clear();
        Console.SetCursorPosition(0, 0);
    }

    static string[] GetTrainArt()
    {
        return
        [
            "                    (  ) (@@) ( )  (@)  ()    @@    O     @     O     @      O",
            "               (@@@)",
            "           (    )",
            "        (@@@@)",
            "     (   )",
            "",
            "   ====        ________                ___________",
            " _D _|  |_______/        \\__I_I_____===__|_________|",
            "  |(_)---  |   H\\________/ |   |        =|___ ___|      _________________",
            "  /     |  |   H  |  |     |   |         ||_| |_||     _|                \\_____A",
            " |      |  |   H  |__--------------------| [___] |   =|                        |",
            " | ________|___H__/__|_____/[][]~\\_______|       |   -|                        |",
            " |/ |   |-----------I_____I [][] []  D   |=======|____|________________________|_",
            "__/ =| o |=-~~\\  /~~\\  /~~\\  /~~\\ ____Y___________|__|__________________________|_",
            " |/-=|___|=    ||    ||    ||    |_____/~\\___/          |_D__D__D_|  |_D__D__D_|",
            "  \\_/      \\O=====O=====O=====O_/      \\_/               \\_/   \\_/    \\_/   \\_/",
        ];
    }

    static int CalculateVerticalPosition(int trainHeight)
    {
        int startY = (Console.WindowHeight - trainHeight) / 2;
        return Math.Max(0, startY);
    }

    static void DrawTrain(string[] train, int x, int startY)
    {
        for (int i = 0; i < train.Length; i++)
        {
            int currentY = startY + i;

            // Skip if outside console bounds
            if (currentY >= Console.WindowHeight)
                break;

            Console.SetCursorPosition(0, currentY);

            if (x < 0)
            {
                // Train moving off left side
                int skip = Math.Abs(x);
                if (skip < train[i].Length)
                {
                    string visiblePart = train[i][skip..];
                    int maxWidth = Math.Min(visiblePart.Length, Console.WindowWidth);
                    Console.Write(visiblePart[..maxWidth]);
                }
            }
            else if (x < Console.WindowWidth)
            {
                // Train fully or partially visible
                Console.SetCursorPosition(x, currentY);
                int availableWidth = Console.WindowWidth - x;
                int drawLength = Math.Min(train[i].Length, availableWidth);
                Console.Write(train[i][..drawLength]);
            }
        }
    }
}
