using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SnakeMess
{
	class Snake
	{
		private List<Point> TheSnake;

		private Point tail;
		private Point head;
		private Point newHead;

		public Point Tail { get { return tail; } set { this.tail = value; } }
		public Point Head { get { return head; } set { this.head = value; } }
		public Point NewHead { get { return newHead; } set { this.newHead = value; } }

		public Snake()
		{
		}

		public Snake(int bodyLength)
		{
			TheSnake = new List<Point>();
			for (int i = 0; i < bodyLength; i++)
			{
				TheSnake.Add(new Point(10, 10));
			}
			Update();
		}

		public void Update()
		{
			tail = new Point(TheSnake.First());
			head = new Point(TheSnake.Last());
			newHead = new Point(head);
		}

		public void PlaceTail()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(this.head.X, this.head.Y);
			Console.Write("0");
		}
		public void PlaceHead()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(this.newHead.X, this.newHead.Y);
			Console.Write("@");
		}
		public void DrawNothing()
		{
			Console.SetCursorPosition(this.Tail.X, this.Tail.Y);
			Console.Write(" ");
		}

		public List<Point> GetSnake()
		{
			return TheSnake;
		}
	}
}