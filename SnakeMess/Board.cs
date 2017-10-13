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
	}
}
