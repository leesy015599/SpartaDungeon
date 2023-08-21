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
		private List<Item> _item;

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

        public List<Item> Item
        {
            get { return _item; }
        }

        // constructor
        public Character()
        {
            // Nullable로 바꾸긴 싫어서 이렇게 해뒀는데 꼭? 이래야? 함?
            // 맞나? 초기화 개념으로 해놓는게 맞는 것 같긴 함.
            // 그럼 int들은?
            _name = "";
            _className = "";
            _item = new();
        }

        // method
        public void AddItem(Item item)
        {
            _item.Add(item);
        }
    }
}

