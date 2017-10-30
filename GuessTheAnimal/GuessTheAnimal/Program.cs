using System;
using GuessTheAnimal.Logic;

namespace GuessTheAnimal
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game( new ConsoleDisplay());
            game.Play();

            Console.Read();

        }
    }
}
