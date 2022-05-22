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

        private static void MoveBullet(Bullet bullet)
        {
            int nextY;
            int nextX;
            char lastOnTopOf;
            Colliders collider;
            switch (bullet.Direction)
            {
                case Directions.Up:
                    nextY = bullet.y - 1;
                    bullet.lastY = bullet.y;
                    collider = Collision.Check(bullet.x, nextY);
                    lastOnTopOf = bullet.onTopOf;
                    if (collider is Colliders.Player or Colliders.Wall or Colliders.Enemy)
                    {
                        //Deal with bullet hitting stuff
                        bulletsToRemove.Add(bullet);
                        bullet.crossedOver = lastOnTopOf;
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
                    collider = Collision.Check(bullet.x, nextY);
                    lastOnTopOf = bullet.onTopOf;
                    if (collider is Colliders.Player or Colliders.Wall or Colliders.Enemy)
                    {
                        //Deal with bullet hitting stuff
                        bulletsToRemove.Add(bullet);
                        bullet.crossedOver = lastOnTopOf;
                        return;
                    }
                    else
                    {
                        bullet.y = nextY;
                        bullet.onTopOf = (char)collider;
                        bullet.crossedOver = lastOnTopOf;
                    }
                    break;
                case Directions.Right:
                    nextX = bullet.x + 1;
                    bullet.lastX = bullet.x;
                    collider = Collision.Check(nextX, bullet.y);
                    lastOnTopOf = bullet.onTopOf;
                    if (collider is Colliders.Player or Colliders.Wall or Colliders.Enemy)
                    {
                        //Deal with bullet hitting stuff
                        bulletsToRemove.Add(bullet);
                        bullet.crossedOver = lastOnTopOf;
                        return;
                    }
                    else
                    {
                        bullet.x = nextX;
                        bullet.onTopOf = (char)collider;
                        bullet.crossedOver = lastOnTopOf;
                    }
                    break;
                case Directions.Left:
                    nextX = bullet.x - 1;
                    bullet.lastX = bullet.x;
                    collider = Collision.Check(nextX, bullet.y);
                    lastOnTopOf = bullet.onTopOf;
                    if (collider is Colliders.Player or Colliders.Wall or Colliders.Enemy)
                    {
                        //Deal with bullet hitting stuff
                        bulletsToRemove.Add(bullet);
                        bullet.crossedOver = lastOnTopOf;
                        return;
                    }
                    else
                    {
                        bullet.x = nextX;
                        bullet.onTopOf = (char)collider;
                        bullet.crossedOver = lastOnTopOf;
                    }
                    break;
            }
        }
    }
}
