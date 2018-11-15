using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mail
{
	public class Menu
	{
		static char input;

		public static void Inditas()
		{
			KepernyoTorles();

			Kiiras();

			Input();

			Opciok();
		}

		static void Kiiras()
		{
			Console.WriteLine("Írja be a használni kívánt művelet számát");
			Console.WriteLine("0 Kilépés\n1 Beérkező levelek\n2 Levélírás\n");
		}

		static void Input()
		{
			bool joInput = false;

			do
			{
				input = Console.ReadKey(true).KeyChar;

				if (input == '0' || input == '1' || input == '2')
				{
					joInput = true;
				}
			} while (!joInput);
		}

		static void Opciok()
		{
			switch (input)
			{
				case '0':
					Kilepes();
					break;
				case '1':
					BeerkezoLevelek();
					break;
				case '2':
					Leveliras();
					break;
				default:
					break;
			}
		}

		static void Kilepes()
		{
			Environment.Exit(0);
		}

		static void BeerkezoLevelek()
		{

		}

		static void Leveliras()
		{

		}

		static void KepernyoTorles()
		{
			Console.Clear();
		}
	}
}
