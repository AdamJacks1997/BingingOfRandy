﻿using BingingOfRandy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingingOfRandy
{
    public class RoomGenerator
    {
        public static char[,] Generate()
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

        public static void GenerateDoor(char[,] layout, Sides side)
        {
            int horzCenter = (int)Math.Ceiling((float)layout.GetLength(1) / 2) - 1;
            int vertCenter = (int)Math.Ceiling((float)layout.GetLength(0) / 2) - 1;

            switch (side)
            {
                case Sides.Top:
                    AddDoor(layout, (0, horzCenter), side);
                    break;
                case Sides.Bottom:
                    AddDoor(layout, (layout.GetLength(0) - 1, horzCenter), side);
                    break;
                case Sides.Left:
                    AddDoor(layout, (vertCenter, 0), side);
                    break;
                case Sides.Right:
                    AddDoor(layout, (vertCenter, layout.GetLength(1) - 1), side);
                    break;
            }
        }

        private static void AddDoor(char[,] layout, (int y, int x) coords, Sides side)
        {
            (int y, int x) = coords;

            if (side == Sides.Top || side == Sides.Bottom)
            {
                layout[y, x] = ' ';
                layout[y, x - 1] = ' ';
                layout[y, x + 1] = ' ';
            }
            else
            {
                layout[y, x] = ' ';
                layout[y - 1, x] = ' ';
                layout[y + 1, x] = ' ';
            }
        }
    }
}
