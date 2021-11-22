using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohvimasin
{
	class Program
	{
		static void Main(string[] args)
		{
			var coffeeMachine = new CoffeeMachine();

			Console.WriteLine("*** KUUMA JOOGI MASIN ***");
			Console.WriteLine("*** Tere tulemast! ***");
			Console.WriteLine("");

			string key = "";

			do
            {         

				coffeeMachine.DisplayDrinkSelections();
				Console.WriteLine();
				while (!coffeeMachine.CheckTotal())
				{
					Console.WriteLine("Palun sisesta münt (10, 20, 50, 1, 2)");
					coffeeMachine.DepositCoin(Convert.ToInt32(Console.ReadLine()));
				}
				Console.WriteLine();
				coffeeMachine.ReturnChange();
				Console.WriteLine();
				coffeeMachine.AddCup();
				Console.WriteLine();
				coffeeMachine.AddSugar();
				Console.WriteLine();
				coffeeMachine.MakeDrink();
				Console.WriteLine();
				Console.WriteLine("Jook valmis! Palun võta tops!");
				Console.WriteLine();
				Console.WriteLine("Kas soovid lahkuda? Soovi korral vajuta j. Jätkamiseks vajuta enter.");
				key = Console.ReadLine();
				if (key.Equals("J") | key.Equals("j"))
				{
					break;
				}
				
			} while (true);
		}

	}
}


namespace Kohvimasin
{
	class CoffeeMachine
	{
		public int costOfDrink = 0;
		public void DisplayDrinkSelections()
		{
			Console.WriteLine("************************");
			Console.WriteLine("* M - Must kohv - 1.30");
			Console.WriteLine("* V - Piimaga kohv - 1.50");
			Console.WriteLine("* L - Latte - 1.80");
			Console.WriteLine("* C - Cappuccino - 1.80");
			Console.WriteLine("* O - Mochaccino - 2.20");
			Console.WriteLine("* K - Kakao - 1.60");
			Console.WriteLine("* T - Tee - 0.50");
			Console.WriteLine("* P - Puljong - 0.80");
			Console.WriteLine("************************");
			Console.WriteLine();
			Console.WriteLine("* Palun tee oma valik");
			MakeDrinkSelection(Convert.ToChar(Console.ReadLine().ToUpper()));


		}
		public int drinkCode;
		private void MakeDrinkSelection(char selection)
		{
			bool selectionOK = false;

			while (!selectionOK)
			{
				switch (selection)
				{
					case 'M':
						Console.WriteLine("Valitud must kohv");
						costOfDrink = 130;
						drinkCode = 1;
						selectionOK = true;
						break;
					case 'V':
						Console.WriteLine("Valitud piimaga kohv");
						costOfDrink = 150;
						drinkCode = 2;
						selectionOK = true;
						break;
					case 'L':
						Console.WriteLine("Valitud latte");
						costOfDrink = 180;
						drinkCode = 3;
						selectionOK = true;
						break;
					case 'C':
						Console.WriteLine("Valitud cappuccino");
						costOfDrink = 180;
						drinkCode = 4;
						selectionOK = true;
						break;
					case 'O':
						Console.WriteLine("Valitud mochaccino");
						costOfDrink = 220;
						drinkCode = 8;
						selectionOK = true;
						break;
					case 'K':
						Console.WriteLine("Valitud kakao");
						costOfDrink = 160;
						drinkCode = 5;
						selectionOK = true;
						break;
					case 'T':
						Console.WriteLine("Valitud tee");
						costOfDrink = 50;
						drinkCode = 6;
						selectionOK = true;
						break;
					case 'P':
						Console.WriteLine("Valitud puljong");
						costOfDrink = 80;
						drinkCode = 7;
						selectionOK = true;
						break;
					default:
						Console.WriteLine("Palun tee uuesti oma valik");
						selection = Convert.ToChar(Console.ReadLine().ToUpper());
						selectionOK = false;
						break;
				}

			}
		}


		public void AddSugar()
		{
			if (drinkCode != 7)
			{
				Console.WriteLine("Mitu suhkrut soovid?");
				MakeSugarSelection(Convert.ToChar(Console.ReadLine()));
				Console.WriteLine();
			}
			else
            {
				Console.WriteLine();
				Console.WriteLine("Segamispulk lisatud");
			}

		}
		private void MakeSugarSelection(int selection)
		{
			bool selectionOK = false;
			while (!selectionOK)
			{
				switch (selection)
				{
					case '0':
						selectionOK = true;
						break;
					case '1':
						Console.WriteLine("Lisatud 1 suhkur");
						Console.WriteLine();
						Console.WriteLine("Segamispulk lisatud");
						selectionOK = true;
						break;
					case '2':
						Console.WriteLine("Lisatud 2 suhkrut");
						Console.WriteLine();
						Console.WriteLine("Segamispulk lisatud");
						selectionOK = true;
						break;
					case '3':
						Console.WriteLine("Lisatud 3 suhkrut");
						Console.WriteLine();
						Console.WriteLine("Segamispulk lisatud");
						selectionOK = true;
						break;
					default:
						Console.WriteLine("Palun tee uuesti oma valik. Liiga palju suhkrut on tervisele kahjulik!");
						selection = Convert.ToChar(Console.ReadLine());
						selectionOK = false;
						break;
				}
			}
		}
		public void AddCup()
		{
			Console.WriteLine("Kas kasutad oma topsi? j/e");
			MakeCupSelection(Convert.ToChar(Console.ReadLine().ToUpper()));
		}

		private void MakeCupSelection(char selection)
		{
			bool selectionOK = false;
			while (!selectionOK)
			{
				switch (selection)
				{
					case 'J':
						Console.WriteLine("Topsi ei lisatud. Kontrolli, et tops oleks korralikult all!");
						selectionOK = true;
						break;
					case 'E':
						Console.WriteLine("Tops lisatud");
						selectionOK = true;
						break;
					default:
						Console.WriteLine("Palun tee uuesti oma valik");
						selection = Convert.ToChar(Console.ReadLine().ToUpper());
						selectionOK = false;
						break;
				}
			}
		}
		public void MakeDrink()
        {
			Console.WriteLine("Joogi valmistamine");	
			
			
			if (drinkCode == 5 || drinkCode == 8)
			{
				Console.BackgroundColor = ConsoleColor.DarkYellow;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Kakaopulber         ");
				Console.ResetColor();

			}
			if (drinkCode == 6)
			{
				Console.BackgroundColor = ConsoleColor.DarkGray;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Teetõmmis           ");
				Console.ResetColor();

			}
			if (drinkCode == 7)
			{
				Console.BackgroundColor = ConsoleColor.Yellow;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Puljongi konsentraat");
				Console.ResetColor();

			}
			if (drinkCode == 5 || drinkCode == 2 || drinkCode == 3 || drinkCode == 4 || drinkCode == 8)
			{
				Console.BackgroundColor = ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Piim                ");
				Console.ResetColor();
			}
			if (drinkCode == 5 || drinkCode == 3 || drinkCode == 4 || drinkCode == 8)
			{
				Console.BackgroundColor = ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Piim                ");
				Console.ResetColor();
			}
			if (drinkCode == 5 || drinkCode == 3)
			{
				Console.BackgroundColor = ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Piim                ");
				Console.ResetColor();
			}
			if (drinkCode == 5)
			{
				Console.BackgroundColor = ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Piim                ");
				Console.ResetColor();
			}
			if (drinkCode == 1 || drinkCode == 2 || drinkCode == 3 || drinkCode == 4)
			{
				Console.BackgroundColor = ConsoleColor.DarkRed;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Kohv                ");
				Console.ResetColor();
			}
			if (drinkCode == 1 || drinkCode == 2 || drinkCode == 4 || drinkCode == 8)
			{
				Console.BackgroundColor = ConsoleColor.DarkRed;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Kohv                ");
				Console.ResetColor();
			}
			if (drinkCode == 1 || drinkCode == 2 || drinkCode == 3 || drinkCode == 4 || drinkCode == 8)
			{
				Console.BackgroundColor = ConsoleColor.Blue;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Kuum vesi           ");
				Console.ResetColor();
			}
			if (drinkCode == 1 || drinkCode == 2)
			{
				Console.BackgroundColor = ConsoleColor.Blue;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Kuum vesi           ");
				Console.ResetColor();
			}
			if (drinkCode == 1)
			{
				Console.BackgroundColor = ConsoleColor.Blue;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Kuum vesi           ");
				Console.ResetColor();
			}
			if (drinkCode == 6 || drinkCode == 7)
			{
				Console.BackgroundColor = ConsoleColor.Blue;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Kuum vesi           ");
				Console.BackgroundColor = ConsoleColor.Blue;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Kuum vesi           ");
				Console.BackgroundColor = ConsoleColor.Blue;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Kuum vesi           ");
				Console.BackgroundColor = ConsoleColor.Blue;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Kuum vesi           ");
				Console.ResetColor();
			}
		}
		
			

		public int RunningTotal { get; set; }
		public CoffeeMachine()
		{
			RunningTotal = 0;
			
		}
		public void ReturnChange()
		{
			int[] coins = { 200, 100, 50, 20, 10 };
			int amount, count, i;
			amount = RunningTotal - costOfDrink;
			if (RunningTotal > costOfDrink)


			{
				Console.WriteLine("Tagasi {0:F2}", (RunningTotal - costOfDrink) * 0.01);

			}
			for (i = 0; i <coins.Length; i++)
            {
				count = amount / coins[i];
				if (count !=0)
					Console.WriteLine("Tagasi {0:F2} :{1}", coins[i]*0.01, count);
				amount %= coins[i];
			}
			RunningTotal = 0;
		}


		public void DepositCoin(int money)
		{
			switch (money)
			{
				case (10):
					RunningTotal += 10;
					if (costOfDrink > RunningTotal)
					{
						Console.WriteLine("Vaja veel sisestada {0:F2}", (costOfDrink - RunningTotal) * 0.01);
					}
					break;
				case (20):
					RunningTotal += 20;
					if (costOfDrink > RunningTotal)
					{
						Console.WriteLine("Vaja veel sisestada {0:F2}", (costOfDrink - RunningTotal) * 0.01);
					}
					break;
				case (50):
					RunningTotal += 50;
					if (costOfDrink > RunningTotal)
					{
						Console.WriteLine("Vaja veel sisestada {0:F2}", (costOfDrink - RunningTotal) * 0.01);
					}
					break;
				case (1):
					RunningTotal += 100;
					if (costOfDrink > RunningTotal)
					{
						Console.WriteLine("Vaja veel sisestada {0:F2}", (costOfDrink - RunningTotal) * 0.01);
					}
					break;
				case (2):
					RunningTotal += 200;
					if (costOfDrink > RunningTotal)
					{
						Console.WriteLine("Vaja veel sisestada {0:F2}", (costOfDrink - RunningTotal) * 0.01);
					}
					break;
				default:
					Console.WriteLine("Vale sisestus");
					break;

			}
		}
		public bool CheckTotal()
		{
			if (RunningTotal >= costOfDrink)
				return true;
			else
				return false;
		}
		
	}
	

}

