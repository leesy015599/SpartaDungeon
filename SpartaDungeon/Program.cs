namespace SpartaDungeon;

class Program
{
    static int currentPageType;
    static Page currentPage = new();
    static ConsoleIO consoleIO = new();

    static void Main()
    {
        currentPageType = (int)Page.TypeName.Main;
        int input;
        while (true)
        {
            Console.Clear();
            currentPage = GetCurrentPage(currentPageType);
            consoleIO.WritePage(currentPage);
            while (true)
            {
                input = consoleIO.ReadInput(currentPage);
                if (input != Constant.wrongInput)
                    break;
                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }

    static Page GetCurrentPage(int type)
    {
        Page currentPage = new();
        currentPage.SetPage((Page.TypeName)type);
        return currentPage;
    }
}

