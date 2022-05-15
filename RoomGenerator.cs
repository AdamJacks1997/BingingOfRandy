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
        public static char[,] GenerateRoom()
        {
            int roomSizeX = Program.RandomBetween(11, 21, true);
            int roomSizeY = Program.RandomBetween(11, 21, true);

            char[,] room = new char[roomSizeY, roomSizeX];

            for (int x = 0; x < roomSizeX; x++)
            {
                for (int y = 0; y < roomSizeY; y++)
                {
                    char c;
                    if(y == 0 || x== 0 || y == roomSizeY - 1 || x == roomSizeX - 1)
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
                    AddDoor(room, (0, xCenter));
                    break;
                case Sides.Bottom:
                    AddDoor(room, (room.GetLength(1) - 1, xCenter));
                    break;
                case Sides.Left:
                    AddDoor(room, (yCenter, 0));
                    break;
                case Sides.Right:
                    AddDoor(room, (yCenter, room.GetLength(0) - 1));
                    break;
            }
        }

        private static void AddDoor(char[,] room, (int y, int x) coords)
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
