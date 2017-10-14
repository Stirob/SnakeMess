using System;
using System.Collections.Generic;

namespace SnakeMess
{
    public class Check
    {
        public Check()
        {
        }

        public static Boolean gg(int newPosX, int newPosY, int snakeLength, int boardH, int boardW)
        {
            if (newPosX < 0 || newPosX >= boardW)
                return true;
            if (newPosY < 0 || newPosY >= boardH)
                return true;
            if (snakeLength + 1 >= boardW * boardH)
            {
                // No more room to place apples - game over.
                return true;
            }

            return false;
        }

        public static Boolean canibal(List<Point> snake, int newPosX, int newPosY)
        {
            foreach (Point x in snake)
                if (x.X == newPosX && x.Y == newPosY)
                {
                    // Death by accidental self-cannibalism.
                    return true;
                }
            return false;

        }

            
    }
}