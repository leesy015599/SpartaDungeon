namespace SpartaDungeon;

class Program
{
    static int currentPageType;
    static Page currentPage = new();
    static ConsoleIO consoleIO = new();

    static Stack<Page> history = new();

    static void Main()
    {
        currentPageType = (int)Page.TypeName.Main;
        int input;
        bool isGameOver = false;
        while (!isGameOver)
        {
            Console.Clear();
            currentPage = GetCurrentPage(currentPageType);
            history.Push(currentPage); // 여기가 문제구나
            consoleIO.WritePage(history);
            while (true)
            {
                input = consoleIO.ReadInput(currentPage);
                if (input != Constant.wrongInput)
                    break;
                Console.WriteLine("잘못된 입력입니다.");
            }
            // input != wrongInput
            int optionType = currentPage.OptionList[input].Type;
            if (((int)Page.TypeName.Main <= optionType)
                && (optionType <= (int)Page.TypeName.Equipment))
            {
                currentPageType = Option.GoPage(optionType);
            }
            else if (optionType == (int)Option.TypeName.PreviousPage)
            {
                history.Pop();
                currentPageType = history.Peek().Type;
                history.Pop();
            }
            else
                break;
        }
        Console.Clear();
        Console.WriteLine("===== 플레이해주셔서 감사합니다 =====");
        return ;
    }

    static Page GetCurrentPage(int type)
    {
        Page currentPage = new();
        currentPage.SetPage((Page.TypeName)type);
        return currentPage;
    }
}

