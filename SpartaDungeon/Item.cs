using System;
namespace SpartaDungeon
{
	public class Item
	{
		private string name;
		private int strikingPower;
		private int defensivePower;
		private int hitPoint;
		private int price;
		private string info;

		private Item() {}

		public Item(string _name, int _strikingPower, int _defensivePower,
					int _hitPoint, int _price, string _info)
		{
			this.name = _name;
			this.strikingPower = _strikingPower;
			this.defensivePower = _defensivePower;
			this.hitPoint = _hitPoint;
			this.price = _price;
			this.info = _info;
		}
	}
}

