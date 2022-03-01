using System;

namespace mis321_pa2_rakern
{
    class Program
    {
        static void Main(string[] args)
        {
            int userChoice = 0;
            bool keepGoing;
            Game game = new Game();
            
            Menu programMenu = new Menu(){NewGame = game};

            do {

                userChoice = programMenu.DisplayMainMenu();
                
                keepGoing = programMenu.RouteMainMenu(userChoice);

                
                
            } while (keepGoing);
        }
    }
}
