using System;
namespace SpartaDungeon
{
    public class Character
    {
        private int level;
        private string name;
        private string className;
        private int strikingPower;
        private int defensivePower;
        private int hitPoint;
        private int gold;
		private List<Item> item;

        enum EnumClassName
        {
            전사
        }

        public Character()
        {
            level = 1;
            name = "이름";
            className = "전사";
            strikingPower = 10;
            defensivePower = 5;
            hitPoint = 100;
            gold = 1500;
			item = new List<Item>();
        }	
    }
}

