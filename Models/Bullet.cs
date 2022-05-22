using BingingOfRandy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingingOfRandy.Models
{
    public class Bullet
    {
        public Directions Direction { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int lastX { get; set; }
        public int lastY { get; set; }
        public char onTopOf { get; set; }
        public char crossedOver { get; set; }

        public Bullet(Directions direction, int x, int y)
        {
            Direction = direction;
            this.x = x;
            this.y = y;
            lastX = x;
            lastY = y;
            onTopOf = (char)Collision.Check(x, y);
        }
    }
}
