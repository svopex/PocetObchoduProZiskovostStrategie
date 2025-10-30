using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocetObchoduProZiskovostStrategie
{
	class Program
	{
		static void Main(string[] args)
		{
			int pocetTestu = 1500000;
			int velikostObchodu = 25000;
			Random r = new Random((int)DateTime.Now.Ticks);

			int[] obchodu = { 5, 10, 20, 30, 40, 50 };
			int[] wins = { 50, 60, 65, 70, 75 };

			/*
						int x1 = 0, x2 = 0;
						for(int i = 0; i < 100000; i++)
						{
							if (r.Next(0, 100) >= 50)
							{
								x1++;
							}
							else
							{
								x2++;
							}
						}
						Console.WriteLine($"   {x1}, {x2}");
			*/

			for (int rrr = 1; rrr <= 1; rrr++)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"   RRR {rrr}:1");
				Console.ForegroundColor = ConsoleColor.White;
				for (int o = 0; o < obchodu.Count(); o++)
				{
					Console.WriteLine($"   Pravdepodobnost uctu ve ztrate po {obchodu[o]} obchodech, RRR {rrr}:1, pocet testu {pocetTestu}: ");
					for (int w = 0; w < wins.Count(); w++)
					{
						int win = 0;
						int los = 0;
						for (int c = 0; c < pocetTestu; c++)
						{
							int equity = 0;
							for (int oo = 0; oo < obchodu[o]; oo++)
							{
								bool p = r.Next(0, 100) >= wins[w];
								if (p)
								{
									equity -= velikostObchodu;
								}
								else
								{
									equity += velikostObchodu * rrr;
								}
							}
							if (equity == 0)
							{
								if (r.Next(0, 2) == 0)
								{
									win++;
								}
								else
								{
									los++;
								}
							}
							else if (equity > 0)
							{
								win++;
							}
							else
							{
								los++;
							}
						}
						/*
						if (wins[w] == 60)
						{
							Console.ForegroundColor = ConsoleColor.Yellow;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.White;
						}
						*/
						Console.WriteLine("   Wins (statistika ziskových obchodů): " + wins[w] + "%, ztrat: " + los + "x, profitu: " + win
							+ $"x, pravdepodobnost ztraty: " + ((double)los / ((double)win + (double)los) * (double)100).ToString("f4") + "%.");
					}
				}
				Console.WriteLine("");
			}
			Console.ReadKey();
		}
	}
}