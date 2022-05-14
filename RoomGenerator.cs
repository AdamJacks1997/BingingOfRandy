using BingingOfRandy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingingOfRandy
{
    
    public class RoomGenerator
    {
        public static char[,] GenerateRoom(int yLength, int xLength)
        {
            char[,] room = new char[yLength, xLength];

            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    char c;
                    if(y == 0 || x== 0 || y == yLength - 1 || x == xLength - 1)
                    {
                        c = '#';
                    } else
                    {
                        c = ' ';
                    }
                    room[y, x] = c;
                }
            }

            return room;

        }

        public static void GenerateDoor(char[,] room, Sides side)
        {
            int xCenter = (int)Math.Ceiling((float)room.GetLength(1) / 2) - 1;
            int yCenter = (int)Math.Ceiling((float)room.GetLength(0) / 2) - 1;

            switch (side)
            {
                case Sides.Top:
                    WriteDoor(room, (0, xCenter));
                    break;
                case Sides.Bottom:
                    WriteDoor(room, (room.GetLength(1) - 1, xCenter));
                    break;
                case Sides.Left:
                    WriteDoor(room, (yCenter, 0));
                    break;
                case Sides.Right:
                    WriteDoor(room, (yCenter, room.GetLength(0) - 1));
                    break;
            }
        }

        private static void WriteDoor(char[,] room, (int y, int x) coords)
        {
            (int y, int x) = coords;
            if (x > 0)
            {
                room[y, x] = ' ';
                room[y, x - 1] = ' ';
                room[y, x + 1] = ' ';
            } else
            {
                room[y, x] = ' ';
                room[y - 1, x] = ' ';
                room[y + 1, x] = ' ';
            }

        }

        public static void DrawRoom(char[,] room)
        {
            for (int i = 0; i < room.GetLength(0); i++)
            {
                for (int j = 0; j < room.GetLength(1); j++)
                {
                    Console.Write(room[i, j]);
                }
                Console.WriteLine();
            }
        }





    }
}
