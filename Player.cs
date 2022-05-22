﻿using BingingOfRandy.Enums;
using BingingOfRandy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingingOfRandy
{
    public class Player
    {
        public int lastX = 0;
        public int lastY = 0;
        public int x = (int)Math.Ceiling((float)Program.rooms[50, 50].layout.GetLength(1) / 2) - 1;
        public int y = (int)Math.Ceiling((float)Program.rooms[50, 50].layout.GetLength(0) / 2) - 1;
        public int mapX = 50;
        public int mapY = 50;
        public int health = 100;
        //public int Weapon = default

        internal void Move(int x, int y)
        {
            var roomLayout = Program.rooms[mapX, mapY].layout;

            // is player moving to next room?
            if (this.y == 0 && y == -1) // up
            {
                mapY += y;
                roomLayout = Program.rooms[mapX, mapY].layout;
                BulletHandler.bullets.Clear();

                this.x = (int)Math.Ceiling((float)roomLayout.GetLength(1) / 2) - 1;
                this.y = roomLayout.GetLength(0) - 1;

                Program.drawRoom = true;
                return;
            }

            if (this.x == roomLayout.GetLength(1) - 1 && x == 1) // right
            {
                mapX += x;
                roomLayout = Program.rooms[mapX, mapY].layout;
                BulletHandler.bullets.Clear();

                this.x = 0;
                this.y = (int)Math.Ceiling((float)roomLayout.GetLength(0) / 2) - 1;

                Program.drawRoom = true;
                return;
            }

            if (this.y == roomLayout.GetLength(0) - 1 && y == 1) // down
            {
                mapY += y;
                roomLayout = Program.rooms[mapX, mapY].layout;
                BulletHandler.bullets.Clear();

                this.x = (int)Math.Ceiling((float)roomLayout.GetLength(1) / 2) - 1;
                this.y = 0;

                Program.drawRoom = true;
                return;
            }

            if (this.x == 0 && x == -1) //left
            {
                mapX += x;
                roomLayout = Program.rooms[mapX, mapY].layout;
                BulletHandler.bullets.Clear();

                this.x = roomLayout.GetLength(1) - 1;
                this.y = (int)Math.Ceiling((float)roomLayout.GetLength(0) / 2) - 1;

                Program.drawRoom = true;
                return;
            }

            var collider = Collision.Check(this.x + x, this.y + y);

            if (collider is Colliders.Wall or Colliders.Enemy)
                return;

            if (collider is Colliders.Hole)
                health = 0;

            if (collider is Colliders.Health)
            {
                health += 10 <= 100 ? health += 10 : health = 100;
                Program.rooms[mapX, mapY].layout[this.y + y, this.x + x] = ' ';
            }

            this.x += x;
            this.y += y;

            Program.drawPlayer = true;
        }

        internal void Shoot(Directions direction)
        {

            int startX = 0;
            int startY = 0;

            switch(direction)
            {
                case Directions.Up:
                    startX = x;
                    startY = y - 1;
                    break;
                case Directions.Down:
                    startX = x;
                    startY = y + 1;
                    break;
                case Directions.Right:
                    startX = x + 1;
                    startY = y;
                    break;
                case Directions.Left:
                    startX = x - 1;
                    startY = y;
                    break;
            }

            var bullet = new Bullet(direction, startX, startY);
            BulletHandler.bullets.Add(bullet);
        }

        internal void Damage(int damageAmount)
        {
            health += damageAmount;
        }
    }
}
