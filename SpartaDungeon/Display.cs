using System;
namespace SpartaDungeon
{
	public class Display
	{
		public Display()
		{
		}

		public int PrintPage(Page page)
		{
			page.WriteType();
			page.WriteInfo();
			Console.WriteLine();

			int input;

			while (true)
			{
				input = ReadInput(page);
				if (input != Define.wrongInput)
					return input;
				
			}
		}

		private int ReadInput(Page page)
		{
			Console.Write("원하시는 행동을 입력해주세요.\n>>");
			string input = Console.ReadLine();
			if (input.Length == 1)
			{
				int parsedInput;
				if (int.TryParse(input, out parsedInput))
				{
					if ((0 <= parsedInput)
						&& (parsedInput < page.ListSize()))
					{
						return parsedInput;
					}
				}
			}
			return Define.wrongInput;
		}
	}


}

