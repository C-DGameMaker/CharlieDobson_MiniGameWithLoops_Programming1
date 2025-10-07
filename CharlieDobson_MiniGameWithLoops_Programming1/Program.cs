using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            Console.WriteLine("Makeshift Snake the Game");
            Console.WriteLine("Press D for Draw mode");
            Console.WriteLine("Press P for Play mode");
            Console.WriteLine("Press ESC to quit anytime.");

            ConsoleKeyInfo choice = new ConsoleKeyInfo();
            choice = Console.ReadKey(true);
            if(choice.Key == ConsoleKey.D)
            {
                Console.Clear();
                DrawMode();
            }
            else if(choice.Key == ConsoleKey.P)
            {
                Console.Clear();
                PlayMode();
            }
            

            Console.Clear();

            Console.Write("GAME OVER!");
        }

        static void DrawMode()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                    //Thread.Sleep(10);
                }
                Console.Write("\n");
                Thread.Sleep(10);
            }
            Console.SetCursorPosition(0, 0);
            Console.Write("O");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;

            while (gameOver == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                movement = Console.ReadKey(true);
                Console.SetCursorPosition(x, y);

                PlayerUpdate();
                PlayerDraw(x, y);


                Thread.Sleep(10);
            }
        }

        static void PlayMode()
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
            Console.SetCursorPosition(0, 0);
            Console.Write("O");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;

            bool[,] visited = new bool[30, 15];

            while (gameOver == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                movement = Console.ReadKey(true);
                Console.SetCursorPosition(x, y);
                visited[x, y] = true;

                PlayerUpdate();
                PlayerDraw(x, y);

                if (visited[x,y] == true)
                {
                    gameOver = true;
                }


                Thread.Sleep(10);
            }
        }

        static void PlayerDraw(int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
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
