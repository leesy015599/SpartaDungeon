using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpartaDungeon
{
	public class ConsoleIO
	{
		// method
		public void WritePage(Stack<Page> history)
		{
			Page page = history.Peek();
			WriteHistory(history);
			Console.WriteLine("");
			Console.WriteLine(page.Info);
			Console.WriteLine("");

			switch (page.Type)
			{
				case (int)Page.TypeName.Status:
					WriteStatus();
					break;
				case (int)Page.TypeName.Inventory:
					break;
				case (int)Page.TypeName.Equipment:
					break;
			}
			Console.WriteLine("");
			WriteOption(page);
			Console.WriteLine("");
		}

		private void WriteStatus()
		{
			// 아이템 장착 시 변화 적용 코드 미완성 !!!!!!!!!!
			Character character = Program.character;
			Console.WriteLine($"Lv. {character.Level / 10}{character.Level % 10}");
			Console.WriteLine($"{character.Name} ( {character.ClassName} )");
			Console.WriteLine($"공격력 : {character.StrikingPower}");
			Console.WriteLine($"방어력 : {character.DefensivePower}");
			Console.WriteLine($"체 력 : {character.HitPoint}");
			Console.WriteLine($"Gold : {character.Gold} G");
		}

		private void WriteInventory()
		{

		}

		private void WriteEquipment()
		{

		}

		private void WriteOption(Page page)
		{
			if (page.CountOption() > 1)
			{
				int optionIndex = 0;
				foreach (Option option in page.OptionList)
				{
					if (optionIndex != 0)
					{
						Console.WriteLine($"{optionIndex}. {option.Name}");
					}
					optionIndex++;
				}
			}
			Console.WriteLine($"0. {page.OptionList[0].Name}");
		}

		private void WriteHistory(Stack<Page> history)
		{
			if (history.TryPeek(out _) == false)
				return ;
			Page currentPage;
			currentPage = history.Peek();
			history.Pop();
			WriteHistory(history);
			Console.Write($" > {currentPage.PageName}");
			history.Push(currentPage);
		}

		public int ReadInput(Page page)
		{
			Console.Write("원하시는 행동을 입력해주세요.\n>> ");
			
			string? input = Console.ReadLine();
			if (input == null)
				return Constant.wrongInput;
			if (input.Length == 1)
			{
				int parsedInput;
				if (int.TryParse(input, out parsedInput))
				{
					if ((0 <= parsedInput)
						&& (parsedInput < page.CountOption()))
					{
						return parsedInput;
					}
				}
			}
			return Constant.wrongInput;
		}
	}
}

