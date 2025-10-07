using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CharlieDobson_MiniGameWithLoops_Programming1
{
    internal class Program
    {
        static bool gameOver = false;
        static int x = 0;
        static int y = 0;
        static ConsoleKeyInfo movement = new ConsoleKeyInfo();

        static void Main(string[] args)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                    Thread.Sleep(10);
                }
                Console.Write("\n");
                Thread.Sleep(10);
            }
            PlayerDraw(x, y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;

            while (gameOver == false)
            {
                movement = Console.ReadKey(true);
                Console.SetCursorPosition(x, y);

                PlayerUpdate();
                PlayerDraw(x, y);

                Thread.Sleep(10);
            }

            Console.Clear();

            Console.Write("GAME OVER!");
        }

        static void PlayerDraw(int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write(" ");
            Console.ResetColor();
            Console.SetCursorPosition(x, y);
            Console.Write("O");
        }

        static void PlayerUpdate()
        {
            
            if (movement.Key == ConsoleKey.W)
            {
                y--;
            }
            else if (movement.Key == ConsoleKey.S)
            {
                y++;
            }
            else if (movement.Key == ConsoleKey.A)
            {
                x--;
            }
            else if (movement.Key == ConsoleKey.D)
            {
                x++;
            }
            else if(movement.Key == ConsoleKey.Escape)
            {
                gameOver = true;
            }

            if (x >= 30)
            {
                x -= 1;
            }
            else if (x < 0)
            {
                x += 1;
            }
            else if (y >= 15)
            {
                y -= 1;
            }
            else if (y < 0)
            {
                y += 1;
            }

        }

       
    }
}
