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
			Board gameBoard = new Board(Console.WindowWidth, Console.WindowHeight, "Westerdals Oslo ACT - SNAKE");
			short last = newDir;
			var rng = new Random();
			var set = new Point();
			var app = new Point();
			var snake = new Snake(4);

			//Kan byte ut metoden fra point, setter hode til slangen NB! Lag snake klasse
			app.setFood();
			//Set random food metode, vet ikke om det funker ennå

			while (true)
				{
					bool spot = true;
					app.X = rng.Next(0, gameBoard.BoardWidth);
					app.Y = rng.Next(0, gameBoard.BoardHeight);
					foreach (Point i in snake.GetSnake())
						if (i.X == app.X && i.Y == app.Y)
						{
							spot = false;
							break;
						}
					if (spot)
					{
						app.DrawFood();
						break;
					}
				}

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
					snake.Update();
					switch (newDir)
					{
						case 0:
							snake.NewHead.Y -= 1;
							break;
						case 1:
							snake.NewHead.X += 1;
							break;
						case 2:
							snake.NewHead.Y += 1;
							break;
						default:
							snake.NewHead.X -= 1;
							break;
					}

					gg = check.gg(snake.NewHead.X, snake.NewHead.Y, snake.GetSnake().Count, gameBoard.BoardWidth, gameBoard.BoardHeight);

					if (snake.NewHead.X == app.X && snake.NewHead.Y == app.Y)
					{

						while (true)
						{
							app.X = rng.Next(0, gameBoard.BoardWidth); app.Y = rng.Next(0, gameBoard.BoardHeight);
							bool found = true;
							foreach (Point i in snake.GetSnake())
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
						snake.GetSnake().RemoveAt(0);
						gg = check.canibal(snake.GetSnake(), snake.NewHead.X, snake.NewHead.Y);

					}

					// WINNER WINNER CHICKEN DINNER
					if (!gg)
					{
						snake.PlaceTail();
						if (!inUse)
						{
							snake.DrawNothing();
						}
						else
						{
							app.DrawFood();
							inUse = false;
						}
						snake.GetSnake().Add(snake.NewHead);
						snake.PlaceHead();
						last = newDir;
					}
				}
			}
		}
	}
}