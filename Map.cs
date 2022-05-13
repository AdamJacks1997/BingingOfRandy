using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingingOfRandy
{
    public class Map
    {
        public int x = 50;
        public int y = 50;
        public int initialCorridorLength = Program.RandomBetween(3, 6);
        public int numberOfSidePaths = Program.RandomBetween(1, 3);
        public int sidePathMaxLength = Program.RandomBetween(1, 4);
        public List<Room> roomsList;

        internal void Generate()
        {
            Program.rooms[50, 50] = CreateRoom();

            var directionPositive = Program.RandomBool();

            for (int i = 0; i <= initialCorridorLength; i++)
            {
                CheckAndAdd(directionPositive);
            }

            GenerateSidePath();

            GenerateDoors();
        }

        internal void GenerateSidePath()
        {
            for (int i = 0; i <= numberOfSidePaths; i++)
            {
                var directionPositive = Program.RandomBool();

                var randRoom = roomsList[Program.RandomBetween(1, roomsList.Count)];

                x = randRoom.x;
                y = randRoom.y;

                for (int e = 0; e <= sidePathMaxLength; e++)
                {
                    CheckAndAdd(directionPositive);
                }
            }
        }

        internal void CheckAndAdd(bool directionPositive)
        {
            var directionHorizontal = Program.RandomBool();

            if (directionPositive)
            {
                if (directionHorizontal)
                {
                    if (!Program.rooms[x + 1, y])
                    {
                        x += 1;
                        CreateRoom();
                    }
                    else if (!Program.rooms[1, y + 1])
                    {
                        y += 1;
                        CreateRoom();
                    }
                    else
                    {
                        CheckAndAdd(!directionPositive);
                    }
                }
                else
                {
                    if (!Program.rooms[1, y + 1])
                    {
                        y += 1;
                        CreateRoom();
                    }
                    else if(!Program.rooms[x + 1, y])
                    {
                        x += 1;
                        CreateRoom();
                    }
                    else
                    {
                        CheckAndAdd(!directionPositive);
                    }
                }
            }
            else
            {
                if (directionHorizontal)
                {
                    if (!Program.rooms[x - 1, y])
                    {
                        x -= 1;
                        CreateRoom();
                    }
                    else if (!Program.rooms[1, y - 1])
                    {
                        x -= 1;
                        CreateRoom();
                    }
                    else
                    {
                        CheckAndAdd(!directionPositive);
                    }
                }
                else
                {
                    if (!Program.rooms[1, y - 1])
                    {
                        y -= 1;
                        CreateRoom();
                    }
                    else if (!Program.rooms[x - 1, y])
                    {
                        x -= 1;
                        CreateRoom();
                    }
                    else
                    {
                        CheckAndAdd(!directionPositive);
                    }
                }
            }
        }

        internal void CreateRoom()
        {
            var newRoom = Room.Generate();
            Program.rooms[x, y] = newRoom;
            roomsList.Add(newRoom);
        }

        internal void GenerateDoors()
        {
            for (int roomX = 0; roomX < 100; roomX++)
            {
                for (int roomY = 0; roomY < 100; roomY++)
                {
                    var room = Program.rooms[roomX, roomY];

                    if (room)
                    {
                        if (Program.rooms[roomX, roomY - 1])
                        {
                            Room.GenerateDoor(room, Sides.Top);
                        }

                        if (Program.rooms[roomX + 1, roomY])
                            Room.GenerateDoor(room, Sides.Right);
                        }

                        if (Program.rooms[roomX, roomY + 1])
                            Room.GenerateDoor(room, Sides.Bottom);
                        }

                        if (Program.rooms[roomX - 1, roomY])
                        {
                            Room.GenerateDoor(room, Sides.Left);
                        }
                    }
                }
            }
        }
    }
}
