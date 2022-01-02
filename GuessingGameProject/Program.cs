using System;
using GuessingGameProject.Class;

namespace GuessingGameProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            int gameStatus = game.Start();

            while (gameStatus == 0)
            {
                Console.Clear();
                gameStatus = game.Start();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Obrigado por jogar :3");
            Console.ReadLine();
        }
    }
}
