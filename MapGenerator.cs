using BingingOfRandy.Enums;
using BingingOfRandy.Models;
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
        public int pathNumber = 1;
        public List<Room> roomsList = new List<Room>();

        internal void Generate()
        {
            CreateRoom(false); // Creates first room

            var directionPositive = Program.RandomBool();

            for (int i = 0; i <= initialCorridorLength; i++)
            {
                CheckAndAdd(directionPositive, false);
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

                randRoom.pathConnectList.Add(pathNumber);
                x = randRoom.mapX;
                y = randRoom.mapY;

                for (int e = 0; e <= sidePathMaxLength; e++)
                {
                    CheckAndAdd(directionPositive, e == 0 ? true : false);
                }

                pathNumber++;
            }
        }

        internal void CheckAndAdd(bool directionPositive, bool isFirst)
        {
            var directionHorizontal = Program.RandomBool();

            if (directionPositive)
            {
                if (directionHorizontal)
                {
                    if (Program.rooms[x + 1, y] == null)
                    {
                        x += 1;
                        CreateRoom(isFirst);
                    }
                    else if (Program.rooms[1, y + 1] == null)
                    {
                        y += 1;
                        CreateRoom(isFirst);
                    }
                    else
                    {
                        CheckAndAdd(!directionPositive, isFirst);
                    }
                }
                else
                {
                    if (Program.rooms[1, y + 1] == null)
                    {
                        y += 1;
                        CreateRoom(isFirst);
                    }
                    else if(Program.rooms[x + 1, y] == null)
                    {
                        x += 1;
                        CreateRoom(isFirst);
                    }
                    else
                    {
                        CheckAndAdd(!directionPositive, isFirst);
                    }
                }
            }
            else
            {
                if (directionHorizontal)
                {
                    if (Program.rooms[x - 1, y] == null)
                    {
                        x -= 1;
                        CreateRoom(isFirst);
                    }
                    else if (Program.rooms[1, y - 1] == null)
                    {
                        x -= 1;
                        CreateRoom(isFirst);
                    }
                    else
                    {
                        CheckAndAdd(!directionPositive, isFirst);
                    }
                }
                else
                {
                    if (Program.rooms[1, y - 1] == null)
                    {
                        y -= 1;
                        CreateRoom(isFirst);
                    }
                    else if (Program.rooms[x - 1, y] == null)
                    {
                        x -= 1;
                        CreateRoom(isFirst);
                    }
                    else
                    {
                        CheckAndAdd(!directionPositive, isFirst);
                    }
                }
            }
        }

        internal void CreateRoom(bool isFirst)
        {
            var newRoom = new Room()
            {
                mapX = x,
                mapY = y,
                pathNumber = pathNumber,
                pathConnectList = new List<int>(),
                layout = RoomGenerator.Generate(),
                enemiesToSpawn = roomsList.Count != 0 ? Program.RandomBetween(1, 3) : 0
            };

            if (isFirst)
            {
                newRoom.pathConnectList.Add(pathNumber);
            }

            newRoom.enemies = EnemyHandler.GenerateEnemies(newRoom);

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

                    if (room != null)
                    {
                        var top = Program.rooms[roomX, roomY - 1];

                        if (top != null)
                        {
                            if (room.pathNumber == top.pathNumber ||
                                room.pathConnectList.Intersect(top.pathConnectList).Any())
                            {
                                RoomGenerator.GenerateDoor(room.layout, Sides.Top);
                            }
                        }

                        var right = Program.rooms[roomX + 1, roomY];

                        if (right != null)
                        {
                            if (room.pathNumber == right.pathNumber ||
                                room.pathConnectList.Intersect(right.pathConnectList).Any())
                            {
                                RoomGenerator.GenerateDoor(room.layout, Sides.Right);
                            }
                        }

                        var bottom = Program.rooms[roomX, roomY + 1];

                        if (bottom != null)
                        {
                            if (room.pathNumber == bottom.pathNumber ||
                                room.pathConnectList.Intersect(bottom.pathConnectList).Any())
                            {
                                RoomGenerator.GenerateDoor(room.layout, Sides.Bottom);
                            }
                        }

                        var left = Program.rooms[roomX - 1, roomY];

                        if (left != null)
                        {
                            if (room.pathNumber == left.pathNumber ||
                                room.pathConnectList.Intersect(left.pathConnectList).Any())
                            {
                                RoomGenerator.GenerateDoor(room.layout, Sides.Left);
                            }
                        }
                    }
                }
            }
        }
    }
}
