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

		private void GoMain()
		{

		}

		private void GoStatus()
		{

		}

		private void GoInventory()
		{

		}
	}
}

