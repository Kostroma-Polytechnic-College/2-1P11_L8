using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleProject
{
    struct Body
    {
        public char symbol;
        public ConsoleColor color;
    }
    class Program
    {
        static Random rnd = new Random();
        static int h, w;
        static Body[] snake_create()
        {
            Body[] snake = new Body[rnd.Next(3, h / 2)];
            for (int j = 0; j < snake.Length; j++)
            {
                snake[j] = new Body()
                {
                    symbol = (char)rnd.Next('A', 'z' + 1),
                    color = (ConsoleColor)rnd.Next(1, 16)
                };
            }
            return snake;
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(3000);
            h = Console.WindowHeight-2;
            w = Console.WindowWidth;
            //int[,] room = new int[h, w];
            Body[][] snakes = new Body[w][];
            
            for (int i = 0; i < snakes.Length; i++)
            {
                snakes[i] = snake_create();
            }
            int[] locations = new int[w];
            while(true)
            {
                //Console.Clear();

                int j = rnd.Next(w);
                for (int i = 0; i < h + snakes[j].Length; i++)
                {
                    if (i < h && locations[j] - snakes[j].Length < i
                        && locations[j] >= i)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.ForegroundColor = snakes[j][locations[j] - i].color;
                        Console.Write(snakes[j][locations[j] - i].symbol);
                    }
                    if (locations[j] - snakes[j].Length == i)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(" ");
                    }
                }
                if(locations[j] > h + snakes[j].Length)
                {
                    snakes[j] = snake_create(); ;
                    locations[j] = 0;
                }
                else
                    locations[j]++;
                //Thread.Sleep(5);
            }



            Console.ReadKey();
        }
    }
}
