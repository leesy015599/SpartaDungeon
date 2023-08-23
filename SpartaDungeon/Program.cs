namespace SpartaDungeon;

class Program
{
    static int currentPageType = (int)Page.TypeName.Main;
    public static Page currentPage = new();
    static Stack<Page> history = new();

    public static List<Item> gameItemList = new();
    public static Character character = new();

    static void Main()
    {
        Initialize();
        ConsoleIO consoleIO = new();

        while (true)
        {
            Console.Clear();
            currentPage = GetCurrentPage(currentPageType);
            history.Push(currentPage);
            consoleIO.WritePage(history);

            int selectedOption;
            // Repeat until getting proper input
            while (true)
            {
                selectedOption = consoleIO.ReadInput(currentPage);
                if (selectedOption != Constant.wrongInput)
                    break;
                Console.WriteLine("잘못된 입력입니다.");
            }

            // if (selectedOption != wrongInput)
            int optionType = currentPage.OptionList[selectedOption].Type;
            if (((int)Option.TypeName.Main <= optionType)
                && (optionType <= (int)Option.TypeName.Equipment))
            {
                // if item equipment is changed
                if ((optionType == (int)Option.TypeName.Equipment)
                    && (currentPageType == (int)Page.TypeName.Equipment))
                {
                    Option.HandleEquipment(selectedOption);
                    history.Pop();
                }
                currentPageType = Option.GoPage(optionType);
            }
            else if (optionType == (int)Option.TypeName.PreviousPage)
            {
                history.Pop();
                currentPageType = history.Peek().Type;
                history.Pop();
            }
            else // optionType == GameOver
                break;
        }
        Console.Clear();
        Console.WriteLine("\n===== 플레이해주셔서 감사합니다 =====\n");
        return ;
    }

    private static void Initialize()
    {
        gameItemList.Add(new Item(1, "무쇠갑옷", 0, 5, 0, 0, "무쇠로 만들어져 튼튼한 갑옷입니다."));
        gameItemList.Add(new Item(2, "낡은 검", 2, 0, 0, 0, "쉽게 볼 수 있는 낡은 검 입니다."));
        gameItemList.Add(new Item(3, "도란의 검", 8, 0, 0, 450, "전쟁광: 이 게임에는 흡혈이 없습니다. 개발자 일해라"));

        character = new(1, "가렌", "전사", 10, 5, 100, 1500, new());
        character.AddOwnItem(1, false);
        character.AddOwnItem(2, false);
        character.AddOwnItem(3, false);
    }

    static Page GetCurrentPage(int type)
    {
        Page currentPage = new();
        currentPage.SetPage((Page.TypeName)type);
        return currentPage;
    }
}

