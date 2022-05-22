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

        private static void DeleteBullet(Bullet bullet)
        {
            bulletsToRemove.Add(bullet);
            bullet.crossedOver = bullet.onTopOf;
        }

        private static void HandleCollision(Bullet bullet, int nextX, int nextY)
        {
            bullet.lastY = bullet.y;
            bullet.lastX = bullet.x;
            char[,] layout = Program.rooms[Program.player.mapX, Program.player.mapY].layout;

            if (nextY < 0 || nextY >= layout.GetLength(0) || nextX >= layout.GetLength(1) || nextX < 0)
            {
                DeleteBullet(bullet);
                return;
            }

            Colliders collider = Collision.Check(nextX, nextY);

            if (collider is Colliders.Player or Colliders.Wall or Colliders.Enemy)
            {
                //Deal with bullet hitting stuff
                if (collider is Colliders.Player)
                {
                    Program.player.health -= 10;
                }
                if (collider is Colliders.Enemy)
                {
                    //Damage enemy
                }
                DeleteBullet(bullet);
                return;
            }
            else
            {
                bullet.y = nextY;
                bullet.x = nextX;
                bullet.crossedOver = bullet.onTopOf;
                bullet.onTopOf = (char)collider;
            }
        }

        private static void MoveBullet(Bullet bullet)
        {

            switch (bullet.Direction)
            {
                case Directions.Up:
                    HandleCollision(bullet, bullet.x, bullet.y - 1);
                    break;
                case Directions.Down:
                    HandleCollision(bullet, bullet.x, bullet.y + 1);
                    break;
                case Directions.Right:
                    HandleCollision(bullet, bullet.x + 1, bullet.y);
                    break;
                case Directions.Left:
                    HandleCollision(bullet, bullet.x - 1, bullet.y);
                    break;
            }
        }
    }
}
