using System;
using System.IO;

namespace mis321_pa2_rakern
{
    public class Game
    {
        public Character player1 {get; set;}
        public Character player2 {get; set;}
        public bool playerQuit {get; set;}

        public string PromptName() {
            Console.WriteLine("\nWhat is your name?");
            return Console.ReadLine();
        }

        public int PromptCharacter() {                
            string userInput;
            bool validInput;
            
            do {
                Console.WriteLine("Which character would you like to play as?");
                Console.WriteLine("1.) Jack Sparrow");
                Console.WriteLine("2.) Will Turner");
                Console.WriteLine("3.) Davy Jones");
                userInput = Console.ReadLine();
                validInput = Menu.CheckValidInput(userInput, 3);
                if (!validInput) Console.Clear();

            } while (!validInput); // ID entered must be an integer
            
            return int.Parse(userInput);
        }
        public Character PlayerChoice() { // let the user choose which character they want to play as
            int charChoice = PromptCharacter();
            string charName = PromptName();
            Character player = new Character();

            switch (charChoice) {
                case 1:
                    player = new JackSparrow(){Name = charName};
                    break;
                case 2:
                    player = new WillTurner(){Name = charName};
                    break;
                case 3:
                    player = new DavyJones(){Name = charName};
                    break;
                default:
                    break;                
            }

            return player;
        }

        public void GameSetup() { // prompts both users for their player choice and name
            Console.Clear();
            Console.WriteLine("Welcome to Pirates of the Console-bbean!\n");
            Console.WriteLine("Player 1:");
            player1 = PlayerChoice();

            PressKeyToContinue();
            Console.Clear();
            Console.WriteLine("Player 2:");
            player2 = PlayerChoice();
            
        }

        public void GamePlay() {
            GameSetup(); // gets players set up
            int firstPlayer = chooseFirst(); // returns 1 or 2 for who goes first in game
            playerQuit = false; // *Potential Extra* : if player decides to quit mid-game, playerQuit = true, game will end


            while (!CheckForEnd() && !playerQuit) {

                BasePlay(firstPlayer);
                
                if (!CheckForEnd() && !playerQuit) { // let user see stats if the game is not set to end
                    ProvideStats();
                }
                
            }

            
            if (CheckForEnd()) {
                if (player1.Health <= 0) { // player 1 lost
                    DisplayWinner(player2, player1);
                }
                else if (player2.Health <= 0) { // player 2 lost          
                    DisplayWinner(player1, player2);
                }
                
            }
            
        }

        public void BasePlay(int firstPlayer) { 
            // On each attack write the power and the damage
            // done to the screen, then display the attacked
            // character’s stats

            if (firstPlayer == 1) { // player 1 was chosen to go first
                playerOneAttack();
                if (!CheckForEnd()) { // game isn't over --> no one has gotten to 0 health yet
                    ProvideStats();
                    if (!playerQuit) { // player does not want to quit mid-game
                        playerTwoAttack();
                    }
                }
            }
            else { // player 2 was chosen to go first
                playerTwoAttack();
                if (!CheckForEnd()) { // game isn't over --> no one has gotten to 0 health yet
                    ProvideStats();
                    if (!playerQuit) { // player does not want to quit mid-game
                        playerOneAttack();
                    }
                }
            }
        }

        public void ProvideStats() { // POTENTIAL EXTRA: user can decide to quit mid-game
            int userChoice = Menu.DisplayStatsMenu(); // 1 for player status, 2 for continue game, 3 for quit game altogether; 
            
            while (userChoice == 1) {
                Console.Clear();
                Console.WriteLine("\t\tPLAYER STATS:");
                player1.ShowStats();
                player2.ShowStats();
                PressKeyToContinue();

                userChoice = Menu.DisplayStatsMenu();
            }
            if (userChoice == 3) {
                playerQuit = true;
            }
            else playerQuit = false;

        }
        
        public void playerOneAttack() { // call player 1's attack behavior
            player1.AttackBehavior.Attack(player1, player2);
        }

        public void playerTwoAttack() { // call player 2's attack behavior
            player2.AttackBehavior.Attack(player2, player1);
            
        }
        public int chooseFirst() { // randomly decides which player goes first
            Console.Clear();
            Console.WriteLine("Let's get this game started! Press any key to begin.");
            Console.ReadKey();
            return RandNum(2);
        }

        public bool CheckForEnd() { // returns true if either player has reached 0 health
            if (player1.Health <= 0 || player2.Health <= 0) {                
                return true;
            }
            else return false;
        }

        public void DisplayWinner(Character winner, Character loser) {

            Console.WriteLine("\n\n\n---------------------------------------------------------------------------------------\n");
            for (int i = 0; i < 12; i++) {
                Console.Write("*\t");
            }
            Console.WriteLine();
            for (int i = 0; i < 11; i++) {
                Console.Write("    *   ");
            }
                
            Console.WriteLine($"\n\t\t{winner.Name} wins!! Better luck next time, {loser.Name}!\n");

            for (int i = 0; i < 11; i++) {
                Console.Write("*\t");
            }
            Console.WriteLine();
            for (int i = 0; i < 11; i++) {
                Console.Write("    *   ");
            }
            
            Console.WriteLine("\n---------------------------------------------------------------------------------------");
        }

        public void PressKeyToContinue() {
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        public static int RandNum(int maxNum) { // generates random number between 1 and maxNum 
            Random randomNumber = new Random();
            int num = randomNumber.Next(maxNum);
            return num + 1; // the min val is 1 and the max val is maxNum
        }
    }
}