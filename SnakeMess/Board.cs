using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
	class Board
	{
		//Bytt til private hvis kode koliderer med hverandre maybe
		public int boardW;
		public int boardH;

		//Har ingen set metode
		public int BoardWidth { get { return boardW; } }
		public int boardHeight { get { return boardH; } }


		public Board(int width, int height, string windowTitle)
		{
			this.boardW = width;
			this.boardH = height;
			Console.CursorVisible = false;
			Console.Title = windowTitle;
		}
		public void setFood(Point app, Random rng, List<Point> snake, int width, int height)
		{
			while (true)
			{
				app.X = rng.Next(0, width);
				app.Y = rng.Next(0, height);

				bool spot = true;

				foreach (Point i in snake)
					if (i.X == app.X && i.Y == app.Y)
					{
						spot = false;
						break;
					}
				if (spot)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.SetCursorPosition(app.X, app.Y);
					Console.Write("$");
					break;
				}
			}
		}
	}
}
