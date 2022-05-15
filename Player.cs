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
        public int x = 0;
        public int y = 0;
        public int mapX = 50;
        public int mapY = 50;
        public int health = 10;
        //public int Weapon = default

        internal void Move(int x, int y)
        {
            this.mapX += x;
            this.mapY += y;

            Program.drawPlayer = true;
            Program.drawRoom = true;
        }
    }
}
