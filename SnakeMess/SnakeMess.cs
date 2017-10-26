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
			bool gameOver = false, pause = false, occupied = false;
			short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left6
			Board gameBoard = new Board(Console.WindowWidth, Console.WindowHeight, "Westerdals Oslo ACT - SNAKE");
			short lastDir = newDir;

			var randomApplePos = new Random();
			var apple = new Point();
			var snake = new Snake(4);

			//Kan byte ut metoden fra point, setter hode til slangen NB! Lag snake klasse
			apple.setFood();
			//Set random food metode, vet ikke om det funker ennå

			while (true)
				{
					bool spot = true;
					apple.X = randomApplePos.Next(0, gameBoard.boardWidth);
					apple.Y = randomApplePos.Next(0, gameBoard.boardHeight);
					foreach (Point i in snake.getSnake())
						if (i.X == apple.X && i.Y == apple.Y)
						{
							spot = false;
							break;
						}
					if (spot)
					{
						apple.drawFood();
						break;
					}
				}

			Stopwatch t = new Stopwatch(); //kontrolerer hvor lang tid hver tick i spillet tar
			t.Start();
			// MOVEMENT TIL SNAKE - GIR TASTETRYKK EN MENING
			while (!gameOver)
			{
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo cki = Console.ReadKey(true);
					if (cki.Key == ConsoleKey.Escape)
						gameOver = true;
					else if (cki.Key == ConsoleKey.Spacebar)
						pause = !pause;
					else if (cki.Key == ConsoleKey.UpArrow && lastDir != 2)
						newDir = 0;
					else if (cki.Key == ConsoleKey.RightArrow && lastDir != 3)
						newDir = 1;
					else if (cki.Key == ConsoleKey.DownArrow && lastDir != 0)
						newDir = 2;
					else if (cki.Key == ConsoleKey.LeftArrow && lastDir != 1)
						newDir = 3;
				}


				if (!pause)
				{
					if (t.ElapsedMilliseconds < 100)
						continue;
					t.Restart();
					snake.update();

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

                    if (snake.NewHead.X < 0 || snake.NewHead.X >= gameBoard.boardWidth)
                        gameOver = true;
                    else if (snake.NewHead.Y < 0 || snake.NewHead.Y >= gameBoard.boardHeight)
                        gameOver = true;
                       

					if (snake.NewHead.X == apple.X && snake.NewHead.Y == apple.Y)
					{
                            if (snake.snakeCount() + 1 >= gameBoard.boardWidth * gameBoard.boardHeight)
                                // No more room to place appleles - game over.
                                gameOver = true;

                            while (true)
						    {
							    apple.X = randomApplePos.Next(0, gameBoard.boardWidth); apple.Y = randomApplePos.Next(0, gameBoard.boardHeight);
							    bool found = true;
							    foreach (Point i in snake.getSnake())
								if (i.X == apple.X && i.Y == apple.Y)
                                {
									found = false;
									break;
								}
							    if (found)
                                {
								occupied = true;
								break;
							    }
						    }
					}

					if (!occupied)
					{
                        snake.getSnake().RemoveAt(0);
                        foreach (Point x in snake.getSnake())
                            if (x.X == snake.NewHead.X && x.Y == snake.NewHead.Y)
                            {
                                // Death by accidental self-cannibalism.
                                gameOver = true;
                                break;
                            }
						

                    }

					// WINNER WINNER CHICKEN DINNER
					if (!gameOver)
					{
						snake.placeTail();
						if (!occupied)
						{
							snake.drawNothing();
						}
						else
						{
							apple.drawFood();
							occupied = false;
						}
						snake.getSnake().Add(snake.NewHead);
						snake.placeHead();
						lastDir = newDir;
					}
				}
			}
		}
	}
}