using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
namespace BullsAndCows
{
    class Game
    {

        IGameController gameController; 
        public Game(IGameController controller)
        {
            gameController = controller;
        }
        public void Play()
        {
            Console.WriteLine("Game Bulls and Cows\nEnter you numbers:");
            string userString = Console.ReadLine();
            while (!gameController.DataCheck(userString))
            {
                Console.WriteLine("Invalid data\nWrite again");
                userString = Console.ReadLine();
            }
            Console.WriteLine("Ok");
            Console.WriteLine($"Your number {userString}");
            gameController.LoadGame(userString);
            
        }
    
    }
}
