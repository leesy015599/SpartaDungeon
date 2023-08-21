namespace SpartaDungeon
{
	public class Item
	{
		// private field
		private string _name;
		private int _strikingPower;
		private int _defensivePower;
		private int _price;
		private string _info;

		// public property
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public int StrikingPower
        {
            get { return _strikingPower; }
            set
            {
                if ((-1 < value) && (value < int.MaxValue))
                    _strikingPower = value;
            }
        }

        public int DefensivePower
        {
            get { return _defensivePower; }
            set
            {
                if ((-1 < value) && (value < int.MaxValue))
                    _defensivePower = value;
            }
        }

		public int Price
		{
			get { return _price; }
			set
			{
				if ((-1 < value) && (value < int.MaxValue))
					_price = value;
			}
		}

		public string Info
		{
			get { return _info; }
			set { _info = value; }
		}

		// constructor
		private Item() {}

		public Item(string name, int strikingPower, int defensivePower,
					int hitPoint, int price, string info)
		{
			_name = name;
			_strikingPower = strikingPower;
			_defensivePower = defensivePower;
			_price = price;
			_info = info;
		}
	}
}

