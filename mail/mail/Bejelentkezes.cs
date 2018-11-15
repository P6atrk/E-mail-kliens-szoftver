using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mail
{
	public class Bejelentkezes
	{
		static string nev;
		static string jelszo;

		public static void Inditas()
		{
			KepernyoTorles();

			FelhasznaloInp();

			KepernyoTorles();

			JelszoInp();

			if (EgyezikE())
			{
				Menu.Inditas();
			}
		}

		static void FelhasznaloInp()
		{
			Console.WriteLine("Felhasználónév:\n");
			nev = Console.ReadLine();
		}

		static void JelszoInp()
		{
			Console.WriteLine("Jelszó:\n");
			jelszo = Console.ReadLine();
		}

		static bool EgyezikE()
		{
			return true; // EZT CSINÁLD MÁR MEG NORMÁLISAN TE SZR
		}

		static void KepernyoTorles()
		{
			Console.Clear();
		}

	}
}
