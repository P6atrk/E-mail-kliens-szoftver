using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mail
{
	public class Regisztracio
	{
		static int hibaUzenet = -1;
		static string nev;
		static string jelszo;
		static string jelszo2x;
		static string jelszEmlek;
		static int jelszoHash;

		public static void Inditas()
		{
			KepernyoTorles();

			FelhasznaloNev();

			Jelszo();

			JelszoHash();

			JelszoEmlekezteto();

			AdatBevitel();

			FelhFajlLetrehozasa();

			KezdoKepernyo.Inditas();
		}

		#region Felhasználónév

		static void FelhasznaloNev()
		{
			do
			{
				HibaUzenetKiiras();

				Console.WriteLine("Felhasználónév:\n");
				nev = Console.ReadLine();

				KepernyoTorles();
			} while (!JoNevE(nev));
		}

		static bool JoNevE(string nev)
		{
			if (nev.Length == 0)
			{
				hibaUzenet = 0;
				return false;
			}

			if (nev.Length > 15)
			{
				hibaUzenet = 1;
				return false;
			}

			if (VanRosszKaraktere(nev))
			{
				hibaUzenet = 6;
				return false;
			}

			string[] felhasznalok = File.ReadAllLines("../../adatok.txt");

			for (int i = 0; i < felhasznalok.Length; i++)
			{
				string kovFelhNev = felhasznalok[i].Split(' ')[0];
				if (kovFelhNev == nev)
				{
					hibaUzenet = 2;
					return false;
				}
			}

			return true;
		}

		#endregion

		#region Jelszó

		static void Jelszo()
		{
			do
			{
				HibaUzenetKiiras();
				jelszo = null;
				jelszo2x = null;

				Console.WriteLine("Jelszó:\n");
				jelszo = Console.ReadLine();
				if (JoJelszoE(jelszo))
				{
					KepernyoTorles();

					Console.WriteLine("Jelszó megerősítése:\n");
					jelszo2x = Console.ReadLine();

					if (JelszoEgyezes())
					{
						return;
					}
				}

				KepernyoTorles();
			} while (true);
		}

		static bool JoJelszoE(string jelszo)
		{
			if (jelszo.Length < 8)
			{
				hibaUzenet = 3;
				return false;
			}

			if (jelszo.Length > 10)
			{
				hibaUzenet = 4;
				return false;
			}

			if (VanRosszKaraktere(jelszo))
			{
				hibaUzenet = 6;
				return false;
			}

			return true;
		}

		static bool JelszoEgyezes()
		{
			if (jelszo != jelszo2x)
			{
				hibaUzenet = 5;
				return false;
			}
			return true;
		}

		#endregion

		static void JelszoHash()
		{
			string jelszoTeljes = jelszo;
			while (jelszoTeljes.Length != 10)
			{
				jelszoTeljes += 'd';
			}

			byte[] hashSzamok = Encoding.ASCII.GetBytes(jelszoTeljes);
			for (int i = 0; i < hashSzamok.Length; i++)
			{
				jelszoHash += hashSzamok[i];
			}
		}

		#region Jelszó emlékeztető

		static void JelszoEmlekezteto()
		{
			do
			{
				KepernyoTorles();

				jelszEmlek = null;
				Console.WriteLine("Jelszó emlékeztető: (opciónális, nyomj Entert az átugráshoz)\n");
				jelszEmlek = Console.ReadLine();
			} while (!JoEmlekE(jelszEmlek));
		}

		static bool JoEmlekE(string emlek)
		{
			if (emlek == "")
			{
				emlek = "";
				return true;
			}

			if (emlek.Length > 15)
			{
				hibaUzenet = 7;
				return false;
			}

			if (VanRosszKaraktere(emlek))
			{
				hibaUzenet = 6;
				return false;
			}

			return true;
		}

		#endregion

		static void FelhFajlLetrehozasa()
		{
			File.Create(String.Format("../../felhasznalok/{0}.txt", nev));
		}

		static void AdatBevitel()
		{
			//nev + " " + jelszoHash + " " + jelszEmlek
			File.AppendAllText("../../adatok.txt", nev + " " + jelszoHash + " " + jelszEmlek + "\n");
		}

		#region Egyéb

		static bool VanRosszKaraktere(string str)
		{
			string joKarakterek = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

			string nagyBetusStr = str.ToUpper();

			for (int i = 0; i < str.Length; i++)
			{
				if (!joKarakterek.Contains(nagyBetusStr[i]))
				{
					return true;
				}
			}
			return false;
		}

		static void HibaUzenetKiiras()
		{
			/*
			 * 0 - felh nincs
			 * 1 - felh hosszu
			 * 2 - felh duplika
			 * 3 - jels rovid
			 * 4 - jels hosszu
			 * 5 - jel2 nem egyezik [note: akkor is ha: rossz karakter VAGY hosszu]
			 * 6 - mind rossz karakter
			 * 7 - emlk hosszu
			 */

			if (hibaUzenet != -1)
			{
				Console.Write("Hiba: ");
			}

			switch (hibaUzenet)
			{
				case 0:
					Console.WriteLine("nem adott meg felhasználónevet.");
					break;
				case 1:
					Console.WriteLine("túl hosszú a felhasználóneve, maximum 15 karakter hosszú lehet.");
					break;
				case 2:
					Console.WriteLine("már létezik ilyen felhasználónév, kérem válasszon másikat.");
					break;
				case 3:
					Console.WriteLine("a jelszó túl rövid. (minimum 8 karakter)");
					break;
				case 4:
					Console.WriteLine("a jelszó túl hossú. (maximum 10 karakter)");
					break;
				case 5:
					Console.WriteLine("a jelszavak nem egyeznek.");
					break;
				case 6:
					Console.WriteLine("nem megengedett karakter(eke)t használt. (Angol abécé kis- és nagybetűi és számok a megengedettek.)");
					break;
				case 7:
					Console.WriteLine("a jelszóemlékeztetőd túl hosszú. (maximum 15 karakter)");
					break;
				default:
					break;
			}

			hibaUzenet = -1;
		}

		static void KepernyoTorles()
		{
			Console.Clear();
		}

		#endregion
	}
}
