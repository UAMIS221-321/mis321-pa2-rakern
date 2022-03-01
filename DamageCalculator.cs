using System;
using System.Timers;
using System.Diagnostics;

namespace mis321_pa2_rakern
{
    public class DamageCalculator
    {
        public Character Attacker {get; set;}
        public Character Opponent {get; set;}

        public double CalculateDamage() { // calculate damage done based off given equation
            double typeBonus;
            double damageDealt;

            if (BoostCombo()) {
                typeBonus = 1.2;
            }
            else typeBonus = 1;

            if (Opponent.DefensivePower >= Attacker.AttackStrength) {
                damageDealt = (Attacker.AttackStrength / Opponent.DefensivePower) * Attacker.AttackStrength; // do not want a negative damage
            }
            else {
                damageDealt = (Attacker.AttackStrength - Opponent.DefensivePower) * typeBonus;
            }

            if (ReactionBoost()) { // prompt user to attack and if they respond quick enough, they get an extra boost
                damageDealt += 10;
            }

            return Math.Round((Double) damageDealt,2);
        }

        public bool BoostCombo() {
            // Jack Sparrow beats Will Turner, Will Turner beats Davy Jones, Davy Jones beats Jack Sparrow
            // EXTRA: Jack the Monkey beats Jack Sparrow
            if (Attacker.Identity == "Jack Sparrow" && Opponent.Identity == "Will Turner") {
                return true;
            }
            else if (Attacker.Identity == "Will Turner" && Opponent.Identity == "Davy Jones") {
                return true;
            }
            else if ((Attacker.Identity == "Davy Jones" || Attacker.Identity == "Jack the Monkey") && Opponent.Identity == "Jack Sparrow") {
                return true;
            }
            else return false; // a boost combination does not exist in the current matchup
        }

        public bool ReactionBoost() { // * POTENTIAL EXTRA * if user presses a key to attack in less than 2000 milliseconds, they get an extra 10 point boost on their attack
            Stopwatch stopwatch = new Stopwatch();
            Console.Clear();
            Console.WriteLine($"\t{Attacker.Name}\nQuick! Press any key to attack!");

            stopwatch.Start();
            Console.ReadKey();
            stopwatch.Stop();

            Console.Clear();
            Console.WriteLine("\nYou took {0} milliseconds to attack.", stopwatch.ElapsedMilliseconds);

            if (stopwatch.ElapsedMilliseconds < 2000) {
                Console.WriteLine("You get an extra 10 point attack boost!\n");
                return true;
            }
            else {
                Console.WriteLine("You were too slow to get an attack boost :(\n");
                return false;
            }
        }
    }
}