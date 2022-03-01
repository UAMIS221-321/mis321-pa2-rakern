using System;

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

            return Math.Round((Double) damageDealt,2);
        }

        public bool BoostCombo() {
            // Jack Sparrow beats Will Turner, Will Turner beats Davy Jones, Davy Jones beats Jack Sparrow
            if (Attacker.Identity == "Jack Sparrow" && Opponent.Identity == "Will Turner") {
                return true;
            }
            else if (Attacker.Identity == "Will Turner" && Opponent.Identity == "Davy Jones") {
                return true;
            }
            else if (Attacker.Identity == "Davy Jones" && Opponent.Identity == "Jack Sparrow") {
                return true;
            }
            else return false; // a boost combination does not exist in the current game
        }
    }
}