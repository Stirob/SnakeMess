using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SnakeMess
{

	class SnakeMess
	{

		public static void Main(string[] arguments)
		{
			// SETTER VALUE TIL TASTETRYKK
			bool gg = false, pause = false, inUse = false;
			short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left6
			short last = newDir;
			int boardW = Console.WindowWidth, boardH = Console.WindowHeight;
			var rng = new Random();
			var app = new Point();
			List<Point> snake = new List<Point>();
			snake.Add(new Point(10, 10));
			snake.Add(new Point(10, 10));
			snake.Add(new Point(10, 10));
			snake.Add(new Point(10, 10));

			// Board + tittel
			Board gameBoard = new Board(Console.WindowWidth, Console.WindowHeight, "Westerdals Oslo ACT - SNAKE");
			//Kan byte ut metoden fra point, setter hode til slangen NB! Lag snake klasse
			app.setHead();
			//Set random food metode, vet ikke om det funker ennå
			gameBoard.setFood(app, rng, snake, Console.WindowWidth, Console.WindowHeight);

			Stopwatch t = new Stopwatch(); //kontrolerer hvor lang tid hver tick i spillet tar
			t.Start();
			// MOVEMENT TIL SNAKE - GIR TASTETRYKK EN MENING
			while (!gg)
			{
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo cki = Console.ReadKey(true);
					if (cki.Key == ConsoleKey.Escape)
						gg = true;
					else if (cki.Key == ConsoleKey.Spacebar)
						pause = !pause;
					else if (cki.Key == ConsoleKey.UpArrow && last != 2)
						newDir = 0;
					else if (cki.Key == ConsoleKey.RightArrow && last != 3)
						newDir = 1;
					else if (cki.Key == ConsoleKey.DownArrow && last != 0)
						newDir = 2;
					else if (cki.Key == ConsoleKey.LeftArrow && last != 1)
						newDir = 3;
				}


				if (!pause)
				{
					if (t.ElapsedMilliseconds < 100)
						continue;
					t.Restart();
					Point tail = new Point(snake.First());
					Point head = new Point(snake.Last());
					Point newH = new Point(head);
					switch (newDir)
					{
						case 0:
							newH.Y -= 1;
							break;
						case 1:
							newH.X += 1;
							break;
						case 2:
							newH.Y += 1;
							break;
						default:
							newH.X -= 1;
							break;
					}

					gg = check.gg(newH.X, newH.Y, snake.Count, boardW, boardH);

					if (newH.X == app.X && newH.Y == app.Y)
					{

						while (true)
						{
							app.X = rng.Next(0, boardW); app.Y = rng.Next(0, boardH);
							bool found = true;
							foreach (Point i in snake)
								if (i.X == app.X && i.Y == app.Y)
								{
									found = false;
									break;
								}
							if (found)
							{
								inUse = true;
								break;
							}
						}

					}

					if (!inUse)
					{
						snake.RemoveAt(0);
						gg = check.canibal(snake, newH.X, newH.Y);

					}

					// WINNER WINNER CHICKEN DINNER
					if (!gg)
					{
						//Kan lage en snake klasse med snake metoder...
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(head.X, head.Y);
						Console.Write("0");
						if (!inUse)
						{
							Console.SetCursorPosition(tail.X, tail.Y);
							Console.Write(" ");
						}
						else
						{
							//Kan fjerne denne metoden fra point og lage den på snake : )
							app.setHead();
							inUse = false;
						}
						snake.Add(newH);
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(newH.X, newH.Y);
						Console.Write("@");
						last = newDir;
					}
				}
			}
		}
	}
}