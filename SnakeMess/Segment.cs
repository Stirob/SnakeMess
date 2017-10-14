using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Segment
    {
        var rng = new Random();
        var app = new Point();
        List<Point> snake = new List<Point>();
        snake.Add(new Point(10, 10));
		snake.Add(new Point(10, 10));
		snake.Add(new Point(10, 10));
		snake.Add(new Point(10, 10));
    }

    while (true) {
				app.X = rng.Next(0, boardW);
				app.Y = rng.Next(0, boardH);

				bool spot = true;

				foreach (Point i in snake)
					if (i.X == app.X && i.Y == app.Y) {
						spot = false;
						break;
					}
					if (spot) {
					Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(app.X, app.Y); Console.Write("$");
					break;
				}
}
