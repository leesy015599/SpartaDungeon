namespace SpartaDungeon
{
	public class ConsoleIO
	{
		// method
		public void WritePage(Stack<Page> history)
		{
			WriteHistory(history);
			Console.WriteLine("");

			Page page = history.Peek();
			Console.WriteLine(page.Info);
			Console.WriteLine("");

			// Write page's content
			switch (page.Type)
			{
				case (int)Page.TypeName.Status:
					WriteStatus();
					break;
				case (int)Page.TypeName.Inventory:
					WriteInventory();
					break;
				case (int)Page.TypeName.Equipment:
					WriteEquipment();
					break;
			}
			Console.WriteLine("");

			WriteOption(page);
			Console.WriteLine("");
		}

		private void WriteHistory(Stack<Page> history)
		{
			if (history.TryPeek(out _) == false)
				return ;

			Page currentPage = history.Peek();
			history.Pop();
			WriteHistory(history);
			// 제일 깊은 재귀함수(이 때 page는 메인페이지)부터 출력.
			Console.Write($" > {currentPage.PageName}");
			history.Push(currentPage);
		}

		private void WriteStatus()
		{
			Character character = Program.character;
			List<Character.OwnItemInfo> ownItemList = character.OwnItemList;
			List<Item> gameItemList = Program.gameItemList;

			// Check item's equipment and calculate extra stat.
			int extraStrikingPower = 0;
			int extraDefensivePower = 0;

			foreach (Character.OwnItemInfo item in ownItemList)
			{
				if (item.IsEquipped == true)
				{
					int itemIndex = item.ItemNum - 1;
					if (gameItemList[itemIndex].StrikingPower != 0)
						extraStrikingPower += gameItemList[itemIndex].StrikingPower;
					else if (gameItemList[itemIndex].DefensivePower != 0)
						extraDefensivePower += gameItemList[itemIndex].DefensivePower;
				}
			}

			// Write status on console
			Console.WriteLine($"Lv. {character.Level / 10}{character.Level % 10}");
			Console.WriteLine($"{character.Name} ( {character.ClassName} )");

			Console.Write($"공격력 : {character.StrikingPower}");
			if (extraStrikingPower > 0)
				Console.Write(" (+{0})", extraStrikingPower);

			Console.Write($"\n방어력 : {character.DefensivePower}");
			if (extraDefensivePower > 0)
				Console.Write(" (+{0})", extraDefensivePower);
				
			Console.WriteLine($"\n체 력 : {character.HitPoint}");
			Console.WriteLine($"Gold : {character.Gold} G");
		}

		private void WriteInventory()
		{
			Console.WriteLine("[아이템 목록]");

			foreach (Character.OwnItemInfo ownItem
					 in Program.character.OwnItemList)
			{
				int itemIndex = ownItem.ItemNum - 1;
				Item item = Program.gameItemList[itemIndex];

				Console.Write("- ");
				if (ownItem.IsEquipped)
					Console.Write("{0,-10}", "[E]" + item.Name);
				else
					Console.Write("{0,-10}", item.Name);
				if (item.StrikingPower != 0)
					Console.Write("|{0,-10}", "공격력 +" + item.StrikingPower);
				else if (item.DefensivePower != 0)
					Console.Write("|{0,-10}", "방어력 +" + item.DefensivePower);
				Console.WriteLine("|{0,-30}", item.Info);
			}
		}

		private void WriteEquipment()
		{
			Character character = Program.character;
			List<Character.OwnItemInfo> ownItemList = character.OwnItemList;
			Page equipPage = Program.currentPage;

			int itemListCount = ownItemList.Count() + 1;
			// 옵션 개수와 아이템 개수 맞춰주기
			if (equipPage.CountOption().CompareTo(itemListCount) > 0)
			{
				// 옵션 개수가 더 많을 경우
				while (equipPage.CountOption().CompareTo(itemListCount) != 0)
					equipPage.RemoveOption();
			}
			else
			{
				// 옵션 개수가 더 적을 경우
				while (equipPage.CountOption().CompareTo(itemListCount) != 0)
					equipPage.AddOption(new Option((int)Option.TypeName.Equipment, ""));
			}

			// WriteInventory() 내용에 아이템별 선택지 숫자가 추가된 형태
			Console.WriteLine("[아이템 목록]");
			int itemCount = 1;
			foreach (Character.OwnItemInfo ownItem
					 in Program.character.OwnItemList)
			{
				int itemIndex = ownItem.ItemNum - 1;
				Item item = Program.gameItemList[itemIndex];

				Console.Write("- {0} ", itemCount++);
				if (ownItem.IsEquipped)
					Console.Write("{0,-10}", "[E]" + item.Name);
				else
					Console.Write("{0,-10}", item.Name);
				if (item.StrikingPower != 0)
					Console.Write("|{0,-10}", "공격력 +" + item.StrikingPower);
				else if (item.DefensivePower != 0)
					Console.Write("|{0,-10}", "방어력 +" + item.DefensivePower);
				Console.WriteLine("|{0,-30}", item.Info);
			}
		}

		private void WriteOption(Page page)
		{
			// if option count == 1, the option is exit(gameover, prev page).
			if (page.CountOption() > 1)
			{
				int optionIndex = 0;
				foreach (Option option in page.OptionList)
				{
					if ((optionIndex != 0) && (option.Name != ""))
						Console.WriteLine($"{optionIndex}. {option.Name}");
					optionIndex++;
				}
			}
			Console.WriteLine($"0. {page.OptionList[0].Name}");
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

