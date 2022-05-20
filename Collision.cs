using BingingOfRandy.Enums;
using BingingOfRandy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingingOfRandy
{
    public static class Collision
    {
        public static Colliders Check(int x, int y)
        {
            var player = Program.player;
            var room = Program.rooms[player.mapX, player.mapY];

            if (room.layout[y, x] == '#')
            {
                return Colliders.Wall;
            }

            if (room.layout[y, x] == 'O')
            {
                return Colliders.Hole;
            }

            if (player.x == x && player.y == y)
            {
                return Colliders.Player;
            }

            // check if coords match any enemy in current room

            return Colliders.None;
        }

        public static Colliders CheckRoom(char[,] room, int x, int y)
        {
            if (room[y, x] == '#')
            {
                return Colliders.Wall;
            }

            if (room[y, x] == 'O')
            {
                return Colliders.Hole;
            }

            // check if coords match any enemy in current room

            return Colliders.None;
        }
    }
}
