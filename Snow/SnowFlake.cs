using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow
{
    class SnowFlake
    {
        private int x, y;
        private ConsoleColor color;
        private int speedY;
        private char look;

        public SnowFlake()
        {
            x = y = 0;
            color = ConsoleColor.White;
            speedY = 1;
            look = '*';
        }

        public SnowFlake(int x, int y, ConsoleColor color, int speedY, char look)
        {
            this.y = y;
            this.x = x;
            this.color = color;
            this.speedY = speedY;
            this.look = look;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(look);
        }

        public void Fall()
        {
            y += speedY;
        }

        public void SetY(int y) 
        {
            this.y = y;
        }

        public int GetY()
        {
            return y;
        }
    }
}
