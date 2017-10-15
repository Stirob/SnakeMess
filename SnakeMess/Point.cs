﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SnakeMess
{
	class Point
	{
		public int X;
		public int Y;
		public Point(int x = 0, int y = 0)
		{
			X = x; Y = y;
		}
		public Point(Point input)
		{
			X = input.X; Y = input.Y;
		}

		public void setFood()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(10, 10);
			Console.Write("@");
		}

		public void DrawFood()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(this.X, this.Y);
			Console.Write("$");
		}
	}
}
