using System;
namespace mis321_pa2_rakern
{
    public class SwordAttack : IAttack
    {
        public void Attack(Character attacker, Character opponent) {
            DamageCalculator damageCalculator = new DamageCalculator() {Attacker = attacker, Opponent = opponent};

            Console.Clear();
            double damageDealt = damageCalculator.CalculateDamage();

            
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($" \t{attacker.Name} swings their sword at {opponent.Name}.");
            Console.WriteLine($" \tDamage Dealt: {damageDealt}");
            Console.WriteLine("---------------------------------------------------\n");
            
            opponent.TakeDamage(damageDealt);
            opponent.ShowStats();

        }
        
    }
}