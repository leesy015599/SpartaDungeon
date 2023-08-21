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

			// 여기 페이지별로 다르게 표시,,

			// 마지막 옵션은 항상 페이지에서 탈출하는 선택지. 항상 0이 되도록.
			// 게임 종료, 나가기, 뒤로 가기, 취소 등.
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
			Page currentPage = new();
			if (history.TryPeek(out currentPage)) // 이거 왜이럼?
			{
				history.Pop();
				WriteHistory(history);
			}
			else
				return ;
			Console.Write($" > {currentPage.PageName}");
		}

		public int ReadInput(Page page)
		{
			Console.Write("원하시는 행동을 입력해주세요.\n>>");
			
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

