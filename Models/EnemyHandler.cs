using BingingOfRandy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingingOfRandy.Models
{
    public class EnemyHandler
    {
        public static void MoveNShoot()
        {
            var room = Program.rooms[Program.player.mapX, Program.player.mapY];
            var roomLayout = room.layout;

            foreach (var enemy in room.enemies)
            {
                var chanceToMoveOrShoot = Program.RandomBetween(0, 6);

                if (chanceToMoveOrShoot != 0)
                {
                    var direction = Program.RandomBetween(0, 4);
                    var x = 0;
                    var y = 0;

                    switch (direction)
                    {
                        case 0:
                            y -= 1;
                            break;
                        case 1:
                            x += 1;
                            break;
                        case 2:
                            y += 1;
                            break;
                        case 3:
                            x -= 1;
                            break;
                    }

                    if (enemy.y == 0 && y == -1) // up
                    {
                        return;
                    }

                    if (enemy.x == roomLayout.GetLength(1) - 1 && x == 1) // right
                    {
                        return;
                    }

                    if (enemy.y == roomLayout.GetLength(0) - 1 && y == 1) // down
                    {
                        return;
                    }

                    if (enemy.x == 0 && x == -1) //left
                    {
                        return;
                    }

                    var collider = Collision.Check(enemy.x + x, enemy.y + y);

                    if (collider is Colliders.Wall or Colliders.Hole or Colliders.Player or Colliders.Enemy or Colliders.Health)
                        return;

                    enemy.x += x;
                    enemy.y += y;
                }
                else if (chanceToMoveOrShoot != 0)
                {
                    //shoot??????!!!!!!!! TOOOOOOMMMMMM??!!!! :O 8===========D
                }
            }

            Program.drawEnemy = true;
        }

        public static int EnemyCount()
        {
            var count = 0;

            foreach (var room in Program.rooms)
            {
                if (room != null)
                {
                    count += room.enemies.Count;
                }
            }

            return count;
        }

        public static List<Enemy> GenerateEnemies(Room room)
        {
            var enemies = new List<Enemy>();

            for (int x = 0; x < room.enemiesToSpawn; x++)
            {
                var position = RoomGenerator.GetRandomPosition(room.layout);

                var enemy = new Enemy()
                {
                    x = position.x,
                    y = position.y,
                };

                enemies.Add(enemy);
            }

            return enemies;
        }
    }
}
