using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snow
{
    class SnowFlakesManeger
    {
        private Random rnd;
        private int minX, minY, maxX, maxY;
        private SnowFlake[] snowFlake;

        public SnowFlakesManeger(int minX, int minY, int maxX, int maxY, int countSnowFlakes) 
        {
            this.rnd = new Random();
            this.minX = minX;
            this.minY = minY;
            this.maxX = maxX;
            this.maxY = maxY;
            this.snowFlake = new SnowFlake[countSnowFlakes]; 

            InitSnowflaks();
        }

        private void InitSnowflaks()
        {
            char[] looks = ("1234567890").ToCharArray();

            for (int i = 0; i < snowFlake.Length; i++)
            {
                snowFlake[i] = new SnowFlake(
                    rnd.Next(minX , maxX + 1),
                    rnd.Next(minY, maxY + 1),
                    (ConsoleColor)rnd.Next(1, 15 + 1),
                    rnd.Next(1, 2),
                    looks[rnd.Next(0, looks.Length)]
                    );
            }
        }

        private void StepSnowflaks() 
        {
            char[] looks = ("1234567890").ToCharArray();

            for (int i = 0; i < snowFlake.Length; i++) 
            {
                snowFlake[i].Fall();

                if (snowFlake[i].GetY() > maxY) 
                {
                    snowFlake[i].SetY(maxY);
                }
            }
        }

        private void MoveSnowflaks() 
        {
            for (int i = 0; i < snowFlake.Length; i++) 
            {
                snowFlake[i].Draw();
            }
        }

        public void RunSnow() 
        {
            while (true) 
            {

                Console.Clear();

                MoveSnowflaks();
                
                StepSnowflaks();

                Thread.Sleep(300);
            }
        }
    }
}

