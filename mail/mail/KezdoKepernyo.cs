using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mail
{
	public class KezdoKepernyo
	{
		static char input;

		public static void Inditas()
		{
			KepernyoTorles();

			Kiiras();

			Input();

			Opciok();
		}
		
		static void Opciok()
		{
			switch (input)
			{
				case '0':
					Kilepes();
					break;
				case '1':
					Regisztracio.Inditas();
					break;
				case '2':
					Console.WriteLine("Belépés dolgok.");
					break;
				default:
					break;
			}
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

			return;
		}

		static void Kiiras()
		{
			Console.WriteLine("Írja be a használni kívánt művelet számát");
			Console.WriteLine("0 Kilépés\n1 Regisztráció\n2 Bejelentkezés\n");
		}

		static void Kilepes()
		{
			Environment.Exit(0);
		}

		static void KepernyoTorles()
		{
			Console.Clear();
		}
	}
}
