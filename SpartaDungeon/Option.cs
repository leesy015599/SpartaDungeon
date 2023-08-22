using System;
namespace SpartaDungeon
{
	public class Option
	{
		private int _type;
		private string _name;

		public int Type
		{
			get { return _type; }
			set
			{
				if ((-1 < value) && (value < int.MaxValue))
					_type = value;
			}
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public enum TypeName
		{
			Main,
			Status,
			Inventory,
			Equipment,
			GameOver,
			PreviousPage
		}

		public Option()
		{
			_name = "";
		}

		public Option(int type, string name)
		{
			_name = "";
			Type = type;
			Name = name;
		}

		public static int GoPage(int type)
		{
			switch ((Page.TypeName)type)
			{
				case Page.TypeName.Main:
					return (int)Page.TypeName.Main;
				case Page.TypeName.Status:
					return (int)Page.TypeName.Status;
				case Page.TypeName.Inventory:
					return (int)Page.TypeName.Inventory;
				case Page.TypeName.Equipment:
					return (int)Page.TypeName.Equipment;
			}
			return (int)Page.TypeName.Main;
		}

		public static void HandleEquipment(int input)
		{
			List<Character.OwnItemInfo> itemList = Program.character.OwnItemList;
			int index = 0;
			Character.OwnItemInfo thisItem = new();
			foreach (Character.OwnItemInfo item in itemList)
			{
				if (item.ItemNum == input)
				{
					thisItem.ItemNum = item.ItemNum;
					if (item.IsEquipped == true)
						thisItem.IsEquipped = false;
					else
						thisItem.IsEquipped = true;
					break;
				}
				index++;
			}
			itemList[index] = thisItem;
		}
	}
}

