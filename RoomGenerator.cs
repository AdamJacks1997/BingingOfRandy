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
                    if (y == 0 || x == 0 || y == roomSizeY - 1 || x == roomSizeX - 1)
                    {
                        c = '#';
                    }
                    else
                    {
                        c = ' ';
                    }
                    room[y, x] = c;
                }
            }

            int roomArea = roomSizeX * roomSizeY;
            int obstacleCount = 2;

            if(roomArea > 300)
            {
                obstacleCount = 3;
            }

            for(int i = 0; i < obstacleCount; i++)
            {
                AddObstacle(room, Program.RandomBool());
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

        private static void AddObstacle(char[,] room, bool isHole)
        {
            int yLength = room.GetLength(0);
            int xLength = room.GetLength(1);

            int xObstacleStart = Program.RandomBetween(1, xLength - 2);
            int yObstacleStart = Program.RandomBetween(1, yLength - 2);

            char obstacle = isHole ? 'O' : '#';

            room[yObstacleStart, xObstacleStart] = obstacle;

            for (int i = 0; i < 3; i++)
            {
                Sides direction = (Sides)Program.RandomBetween(0, 3);
                switch (direction)
                {
                    case (Sides.Top):
                        if (yObstacleStart > 3 && yObstacleStart < yLength - 3) yObstacleStart++;
                        break;
                    case (Sides.Bottom):
                        if (yObstacleStart < yLength - 3 && yObstacleStart > 3) yObstacleStart--;
                        break;
                    case (Sides.Left):
                        if (xObstacleStart > 3 && xObstacleStart < xLength - 3) xObstacleStart--;
                        break;
                    case (Sides.Right):
                        if (xObstacleStart < xLength - 3 && xObstacleStart > 3) xObstacleStart++;
                        break;
                }
                room[yObstacleStart, xObstacleStart] = obstacle;
            }
        }
    }
}
