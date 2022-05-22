using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingingOfRandy.Models
{
    public class Room
    {
        public int mapX;
        public int mapY;
        public int pathNumber;
        public List<int> pathConnectList;
        public char[,] layout;
        public int enemiesToSpawn;
        public List<Enemy> enemies;
    }
}
