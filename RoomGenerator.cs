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
                AddObstacle(room);
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
                    AddDoor(room, (0, xCenter), side);
                    break;
                case Sides.Bottom:
                    AddDoor(room, (room.GetLength(0) - 1, xCenter), side);
                    break;
                case Sides.Left:
                    AddDoor(room, (yCenter, 0), side);
                    break;
                case Sides.Right:
                    AddDoor(room, (yCenter, room.GetLength(1) - 1), side);
                    break;
            }
        }

        private static void AddDoor(char[,] room, (int y, int x) coords, Sides side)
        {
            (int y, int x) = coords;

            if (side == Sides.Top || side == Sides.Bottom)
            {
                room[y, x] = ' ';
                room[y, x - 1] = ' ';
                room[y, x + 1] = ' ';
            }
            else
            {
                room[y, x] = ' ';
                room[y - 1, x] = ' ';
                room[y + 1, x] = ' ';
            }
        }

        private static void AddObstacle(char[,] room)
        {
            int yLength = room.GetLength(0);
            int xLength = room.GetLength(1);

            int xObstacleStart = Program.RandomBetween(1, xLength - 2);
            int yObstacleStart = Program.RandomBetween(1, yLength - 2);

            room[yObstacleStart, xObstacleStart] = 'O';

            for (int i = 0; i < 3; i++)
            {
                Sides direction = (Sides)Program.RandomBetween(0, 3);
                switch (direction)
                {
                    case (Sides.Top):
                        if (yObstacleStart > 3 && yObstacleStart < yLength - 3)
                        {
                            yObstacleStart++;
                        }
                        break;
                    case (Sides.Bottom):
                        if (yObstacleStart < yLength - 3 && yObstacleStart > 3)
                        {
                            yObstacleStart--;
                        }
                        break;
                    case (Sides.Left):
                        if (xObstacleStart > 3 && xObstacleStart < xLength - 3)
                        {
                            xObstacleStart--;
                        }
                        break;
                    case (Sides.Right):
                        if (xObstacleStart < xLength - 3 && xObstacleStart > 3)
                        {
                            xObstacleStart++;
                        }
                        break;

                }
                room[yObstacleStart, xObstacleStart] = 'O';
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
