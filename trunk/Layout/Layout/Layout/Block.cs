using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Layout
{
  public   class Block:Line
    {
        int power =0;

        public Block(Point point1, Point point2) :
            base(point1, point2) { }



        public Block(int x1, int y1, int x2, int y2) :
            base(x1, y1, x2, y2) { }
        

        /// <summary>
        /// Опасность блока
        /// </summary>
        public int Power
        {
            get { return power; }
            set { power = value; }
        }





    }
}
