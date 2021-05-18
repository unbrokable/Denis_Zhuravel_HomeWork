using System;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameController gameController = new GameController(4);
            Game game = new Game(gameController);
            game.Play();
        }
    }
}
