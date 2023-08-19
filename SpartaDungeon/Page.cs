namespace SpartaDungeon
{
	public class Page
	{
		protected int type;
		protected string typeName;
		protected string info;
		private List<string> option;

		protected enum Type
		{
			MAIN,
			STATUS,
			INVENTORY
		}

		public Page()
		{
			option = new();
		}

		protected void AddOption(string newOption)
		{
			option.Add(newOption);
		}

		public int ListSize()
		{
			return (option.Count);
		}

		public void WriteInfo()
		{
			Console.WriteLine(info);
		}

		public void WriteType()
		{
			Console.WriteLine(typeName);
		}
	}

	public class Main : Page
	{
		public Main()
		{
			type = (int)Page.Type.MAIN;
			typeName = "메인 화면";
			info = "스파르타 마을에 오신 여러분 환영합니다.\n"
					+ "이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.";
			
			AddOption("상태 보기");
			AddOption("인벤토리");
			AddOption("게임 종료");
		}
	}

	public class Status : Page
	{
		public Status()
		{
			type = (int)Page.Type.STATUS;
			typeName = "상태 보기";
			info = "상태 보기\n캐릭터의 정보가 표시됩니다.";

			AddOption("나가기");
		}

	}

	public class Inventory : Page
	{
		protected int type;

		protected enum Type
		{
			MAIN,
			EQUIP
		}

		public Inventory()
		{
			base.type = (int)Page.Type.INVENTORY;
			base.typeName = "인벤토리";
			info = "보유 중인 아이템을 관리할 수 있습니다.";

			AddOption("장착 관리");
			AddOption("나가기");

			this.type = (int)Inventory.Type.MAIN;
		}
	}

	public class Equipment : Inventory
	{
		public Equipment()
		{
			typeName = "장착 관리";
			base.type = (int)Inventory.Type.EQUIP;
		}

	}
}

