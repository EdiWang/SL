namespace SL;

internal class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.Clear();

        int trainPosition = Console.WindowWidth;

        try
        {
            while (trainPosition > -60)
            {
                Console.Clear();
                DrawTrain(trainPosition);
                Thread.Sleep(80);
                trainPosition--;
            }
        }
        finally
        {
            Console.CursorVisible = true;
            Console.Clear();
        }
    }

    static void DrawTrain(int x)
    {
        string[] train =
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

        int startY = (Console.WindowHeight - train.Length) / 2;
        if (startY < 0) startY = 0;

        for (int i = 0; i < train.Length; i++)
        {
            if (startY + i < Console.WindowHeight)
            {
                Console.SetCursorPosition(0, startY + i);

                if (x < 0)
                {
                    int skip = Math.Abs(x);
                    if (skip < train[i].Length)
                    {
                        Console.Write(train[i].Substring(skip));
                    }
                }
                else if (x < Console.WindowWidth)
                {
                    Console.SetCursorPosition(x, startY + i);
                    int maxLength = Math.Min(train[i].Length, Console.WindowWidth - x);
                    Console.Write(train[i].Substring(0, maxLength));
                }
            }
        }
    }
}
