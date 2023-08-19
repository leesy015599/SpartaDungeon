namespace SpartaDungeon;

static class Define
{
    public const int wrongInput = -1;
}

class Program
{
    static int currentPageType;
    static Page currentPage;
    static Display display = new();

    static void Main()
    {
        currentPageType = (int)Page.Type.Main;
        while (true)
        {
            currentPage = CurrentPage(currentPageType);
            display.PrintPage(currentPage);

            return;
        }
    }

    static Page CurrentPage(int pageType)
    {
        Page currentPage;
        switch (pageType)
        {
            case (int)Page.Type.Main:
                currentPage = new Main();
                break;
            default: // test
                currentPage = new Main();
                break;
        }
        return currentPage;
    }
}

