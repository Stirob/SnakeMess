﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SnakeMess
{
    class check
    {
            public check()
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

