using System;
namespace mis321_pa2_rakern
{
    public class Character
    {
        public string Name {get; set;}
        public string Identity {get; set;}
        public int MaxPower {get; set;}
        public double Health {get; set;}
        public double AttackStrength {get; set;}
        public double DefensivePower {get; set;}
        public IAttack AttackBehavior {get; set;} 

        public Character() {
            Health = 100;
            MaxPower = Game.RandNum(100);
            AttackStrength = Game.RandNum(MaxPower);
            DefensivePower = Game.RandNum(MaxPower);

            // MaxPower should be set to a random number between 1 and 100
            // AttackStrength random num between 1 and max power
            // DefensivePower random num between 1 and max power
        }

        public void ShowStats() { // Show player stats
            Console.WriteLine($"{Name} Stats:\n\tPlayer Type: {Identity} \n\tHealth: {Health}\n\tAttack Strength: {AttackStrength}\n\tDefensivePower: {DefensivePower}");
        }

        public void TakeDamage(double damageAmount) { // Decrease damage when attacked
            Health -= damageAmount;
            Health = Math.Round((Double) Health,2);
        }

        public void SetAttackBehavior(IAttack newAttackBehavior) {
            AttackBehavior = newAttackBehavior;
        }
    }
}