using BingingOfRandy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingingOfRandy.Models
{
    public class BulletHandler
    {
        public static List<Bullet> bullets = new List<Bullet>();

        public static List<Bullet> bulletsToRemove = new List<Bullet>();

        public static void Shoot(Directions direction, int x, int y)
        {
            bullets.Add(new Bullet(direction, x, y));
        }


        public static void MoveBullets()
        {
            foreach (var bullet in bullets)
            {
                MoveBullet(bullet);
            }

        }

        public static void ClearBullets()
        {
            foreach (var bullet in bulletsToRemove)
            {
                bullets.Remove(bullet);
            }
            bulletsToRemove.Clear();
        }

        public static void DeleteBullet(Bullet bullet)
        {
            bulletsToRemove.Add(bullet);
            bullet.crossedOver = bullet.onTopOf;
        }

        private static void MoveBullet(Bullet bullet)
        {
            int nextY;
            int nextX;
            char lastOnTopOf;
            Colliders collider;
            char[,] layout = Program.rooms[Program.player.mapX, Program.player.mapY].layout;

            switch (bullet.Direction)
            {
                case Directions.Up:
                    nextY = bullet.y - 1;
                    bullet.lastY = bullet.y;
                    lastOnTopOf = bullet.onTopOf;
                    if (nextY < 0)
                    {
                       DeleteBullet(bullet);
                       return;
                    }
                    collider = Collision.Check(bullet.x, nextY);
                    if (collider is Colliders.Player or Colliders.Wall or Colliders.Enemy)
                    {
                        //Deal with bullet hitting stuff
                        DeleteBullet(bullet);
                        return;
                    }
                    else
                    {
                        bullet.y = nextY;
                        bullet.onTopOf = (char)collider;
                        bullet.crossedOver = lastOnTopOf;
                    }
                    break;
                case Directions.Down:
                    nextY = bullet.y + 1;
                    bullet.lastY = bullet.y;
                    if (nextY >= layout.GetLength(0))
                    {
                        //Out of range
                        DeleteBullet(bullet);
                        return;
                    }
                    collider = Collision.Check(bullet.x, nextY);
                    if (collider is Colliders.Player or Colliders.Wall or Colliders.Enemy)
                    {
                        //Deal with bullet hitting stuff
                        DeleteBullet(bullet);
                        return;
                    }
                    else
                    {
                        bullet.y = nextY;
                        bullet.crossedOver = bullet.onTopOf;
                        bullet.onTopOf = (char)collider;
                    }
                    break;
                case Directions.Right:
                    nextX = bullet.x + 1;
                    bullet.lastX = bullet.x;
                    if (nextX >= layout.GetLength(1))
                    {
                        //Out of range
                        DeleteBullet(bullet);
                        return;
                    }
                    collider = Collision.Check(nextX, bullet.y);
                    if (collider is Colliders.Player or Colliders.Wall or Colliders.Enemy)
                    {
                        //Deal with bullet hitting stuff
                        DeleteBullet(bullet);
                        return;
                    }
                    else
                    {
                        bullet.x = nextX;
                        bullet.crossedOver = bullet.onTopOf;
                        bullet.onTopOf = (char)collider;
                    }
                    break;
                case Directions.Left:
                    nextX = bullet.x - 1;
                    bullet.lastX = bullet.x;
                    if (nextX < 0)
                    {
                        //Out of range
                        DeleteBullet(bullet);
                        return;
                    }
                    collider = Collision.Check(nextX, bullet.y);
                    if (collider is Colliders.Player or Colliders.Wall or Colliders.Enemy)
                    {
                        //Deal with bullet hitting stuff
                        bulletsToRemove.Add(bullet);
                        bullet.crossedOver = bullet.onTopOf;
                        return;
                    }
                    else
                    {
                        bullet.x = nextX;
                        bullet.crossedOver = bullet.onTopOf;
                        bullet.onTopOf = (char)collider;
                    }
                    break;
            }
        }
    }
}
