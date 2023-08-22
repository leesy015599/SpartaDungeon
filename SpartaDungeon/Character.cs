namespace SpartaDungeon
{
    public class Character
    {
        // private field
        private int _level;
        private string _name;
        private string _className;
        private int _strikingPower;
        private int _defensivePower;
        private int _hitPoint;
        private int _gold;
		private List<Item> _itemList;
        private List<bool> _isEquipped;

        // public property
        public int Level
        {
            get { return _level; }
            set
            {
                // Max level is 99.
                if ((0 < value) && (value < 100))
                    _level = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
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

        public int HitPoint
        {
            get { return _hitPoint; }
            set
            {
                if ((-1 < value) && (value < int.MaxValue))
                    _hitPoint = value;
            }
        }

        public int Gold
        {
            get { return _gold; }
            set
            {
                if ((-1 < value) && (value < int.MaxValue))
                    _gold = value;
            }
        }

        public List<Item> ItemList
        {
            get { return _itemList; }
        }

        public List<bool> IsEquipped
        {
            get { return _isEquipped; }
        }

        // constructor
        public Character()
        {
            _name = "";
            _className = "";
            _itemList = new();
            _isEquipped = new();
        }

        public Character(int level, string name, string className,
                         int strikingPower, int defensivePower,
                         int hitPoint, int gold, List<Item> itemList,
                         List<bool> isEquipped)
        {
            _level = level;
            _name = name;
            _className = className;
            _strikingPower = strikingPower;
            _defensivePower = defensivePower;
            _hitPoint = hitPoint;
            _gold = gold;
            _itemList = itemList;
            _isEquipped = isEquipped;
        }

        // method
        public void AddItem(Item item, bool isEquipped)
        {
            _itemList.Add(item);
            _isEquipped.Add(isEquipped);
        }
    }
}

