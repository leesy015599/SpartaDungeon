namespace SpartaDungeon;

class Program
{
    static int currentPageType;
    static Page currentPage = new();
    static ConsoleIO consoleIO = new();

    static void Main()
    {
        currentPageType = (int)Page.TypeName.Main;
        while (true)
        {
            currentPage = GetCurrentPage(currentPageType);
            consoleIO.WritePage(currentPage);

            return;
        }
    }

    static Page GetCurrentPage(int type)
    {
        Page currentPage = new();
        currentPage.SetPage((Page.TypeName)type);
        return currentPage;
    }
}

