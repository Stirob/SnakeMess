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

		public Point Tail { get { return tail; } set { tail = value; } }
		public Point Head { get { return head; } set { head = value; } }
		public Point NewHead { get { return newHead; } set { newHead = value; } }
        
		public Snake(int bodyLength)
		{
			TheSnake = new List<Point>();
			for (int i = 0; i < bodyLength; i++)
			{
				TheSnake.Add(new Point(10, 10));
			}
			update();
		}

        public int snakeCount()
        {
            return TheSnake.Count;
        }
		public void update()
		{
			tail = new Point(TheSnake.First());
			head = new Point(TheSnake.Last());
			newHead = new Point(head);
		}

		public void placeTail()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(head.X, head.Y);
			Console.Write("0");
		}
		public void placeHead()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(newHead.X, newHead.Y);
			Console.Write("@");
		}
		public void drawNothing()
		{
			Console.SetCursorPosition(Tail.X, Tail.Y);
			Console.Write(" ");
		}

		public List<Point> getSnake()
		{
			return TheSnake;
		}
	}
}