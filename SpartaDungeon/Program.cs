using System.Security.Cryptography.X509Certificates;

namespace SpartaDungeon;

class Program
{
    static int currentPageType = (int)Page.TypeName.Main;
    static Page currentPage = new();
    static ConsoleIO consoleIO = new();
    static Stack<Page> history = new();

    public static List<Item> itemList = new();
    public static Character character = new();

    static void Main()
    {
        int input;
        Initialize();
        while (true)
        {
            Console.Clear();
            currentPage = GetCurrentPage(currentPageType);
            history.Push(currentPage);
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
        Console.WriteLine("\n\n\n===== 플레이해주셔서 감사합니다 =====");
        return ;
    }

    static void Initialize()
    {
        List<bool> isEquipped = new();
        character = new(1, "이름", "전사", 10, 5, 100, 1500, itemList, isEquipped);
        character.AddItem(new("무쇠갑옷", 0, 5, 0, 0, "무쇠로 만들어져 튼튼한 갑옷입니다."), false);
        character.AddItem(new("낡은 검", 2, 0, 0, 0, "쉽게 볼 수 있는 낡은 검 입니다."), false);
    }

    static Page GetCurrentPage(int type)
    {
        Page currentPage = new();
        currentPage.SetPage((Page.TypeName)type);
        return currentPage;
    }
}

