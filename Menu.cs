using System;
using System.IO;

namespace mis321_pa2_rakern
{
    public class Menu
    {
        public Game NewGame;


        public int DisplayMainMenu() {
            string userInputString;
            bool validInput = false;

            do { // attempted extra: error handling when the user enters an invalid input
                Console.Clear();
                Console.WriteLine("Welcome to the main menu. Please choose from the following:\n");
                Console.WriteLine("1) Begin Game");
                Console.WriteLine("2) Exit");

                userInputString = Console.ReadLine();
                validInput = CheckValidInput(userInputString, 2);
                
            } while(!validInput);

            return int.Parse(userInputString);
        }
        public bool RouteMainMenu(int userChoice) {
            switch (userChoice) {
                case 1: // Print Playlist
                    NewGame.GamePlay();
                    PressKeyToReturn();
                    return true;
                case 2: // Exit Program
                    DisplayQuitMessage();
                    return false;
                default:
                    Console.WriteLine("Sorry, incorrect input. Goodbye.");
                    return false;
            }
        }

        public static int DisplayStatsMenu() {
            string userInputString;
            bool validInput = false;

            do { // attempted extra: error handling when the user enters an invalid input
                Console.WriteLine("\nWhat would you like to do next?\n");
                Console.WriteLine("1) View Player Stats");
                Console.WriteLine("2) Continue Game");
                Console.WriteLine("3) Exit Game");

                userInputString = Console.ReadLine();
                validInput = CheckValidInput(userInputString, 3);
                
            } while(!validInput);

            return int.Parse(userInputString);
        }

        public static bool CheckValidInput(string userInput, int maxOption) { // input must be between 1 and the max option
            int parsedInput;

            if (!int.TryParse(userInput, out parsedInput)) { // user input is not an integer
                DisplayInvalidInputMessage();
                return false;
            }
            else {
                
                if (parsedInput >= 1 && parsedInput <= maxOption) { // user input is valid
                    return true;
                }

                DisplayInvalidInputMessage();
                return false;
            }
            
        }

        public static void DisplayInvalidInputMessage() {
            Console.WriteLine("Invalid input. Press any key to return and try again.");
            Console.ReadKey();
        }

        public static void DisplayQuitMessage() {
            Console.Clear();
            Console.WriteLine("Goodbye.");
        }

        public static void PressKeyToReturn() {
            Console.WriteLine("\nPress any key to return to the menu.");
            Console.ReadKey();
        }
    }
}