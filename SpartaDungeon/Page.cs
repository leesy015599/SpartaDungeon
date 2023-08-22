namespace SpartaDungeon
{
	public class Page
	{
		// private field
		private int _type;
		private string _pageName;
		private string _info;
		private List<Option> _optionList;

		// public property
		public int Type
		{
			get { return _type; }
			set
			{
				if ((-1 < value) && (value < int.MaxValue))
					_type = value;
			}
		}

		public string PageName
		{
			get { return _pageName; }
			set { _pageName = value; }
		}

		public string Info
		{
			get { return _info; }
			set { _info = value; }
		}

		public List<Option> OptionList
		{
			get { return _optionList; }
		}

		// enum
		public enum TypeName
		{
			Main,
			Status,
			Inventory,
			Equipment
		}

		// constructor
		public Page()
		{
			_pageName = "";
			_info = "";
			_optionList = new();
		}

		// method
		public void AddOption(Option newOption)
		{
			_optionList.Add(newOption);
		}

		public void RemoveOption()
		{
			// This method will be used only in Equipment page.
			_optionList.Remove(_optionList.Last());
		}

		public int CountOption()
		{
			return (_optionList.Count);
		}

		public void SetPage(TypeName type)
		{
			switch (type)
			{
				case TypeName.Main:
					SetMain();
					break;
				case TypeName.Status:
					SetStatus();
					break;
				case TypeName.Inventory:
					SetInventory();
					break;
				case TypeName.Equipment:
					SetEquipment();
					break;
			}
		}

		private void SetMain()
		{
			_type = (int)Page.TypeName.Main;
			_pageName = "메인 화면";
			_info = "스파르타 마을에 오신 여러분 환영합니다.\n"
					+ "이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.";
			AddOption(new Option((int)Option.TypeName.GameOver, "게임 종료"));
			AddOption(new Option((int)Option.TypeName.Status, "상태 보기"));
			AddOption(new Option((int)Option.TypeName.Inventory, "인벤토리"));
		}

		private void SetStatus()
		{
			_type = (int)Page.TypeName.Status;
			_pageName = "상태 보기";
			_info = "캐릭터의 정보가 표시됩니다.";
			AddOption(new Option((int)Option.TypeName.PreviousPage, "나가기"));
		}

		private void SetInventory()
		{
			_type = (int)Page.TypeName.Inventory;
			_pageName = "인벤토리";
			_info = "보유 중인 아이템을 관리할 수 있습니다.";
			AddOption(new Option((int)Option.TypeName.PreviousPage, "나가기"));
			AddOption(new Option((int)Option.TypeName.Equipment, "장착 관리"));
		}

		private void SetEquipment()
		{
			_type = (int)Page.TypeName.Equipment;
			_pageName = "장착 관리";
			_info = "보유 중인 아이템을 관리할 수 있습니다.";
			AddOption(new Option((int)Option.TypeName.PreviousPage, "나가기"));
		}
	}
}

