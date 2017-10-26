using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SnakeMess
{
	class Board
	{
		//Bytt til private hvis kode koliderer med hverandre maybe
		private int boardW;
		private int boardH;

		//Har ingen set metode
		public int boardWidth { get { return boardW; } }
		public int boardHeight { get { return boardH; } }


		public Board(int width, int height, string windowTitle)
		{
			boardW = width;
			boardH = height;
			Console.CursorVisible = false;
			Console.Title = windowTitle;
		}
	}
}
