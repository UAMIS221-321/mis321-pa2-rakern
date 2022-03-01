
using System;
namespace mis321_pa2_rakern
{
    public class DistractAttack : IAttack
    {
        public void Attack(Character attacker, Character opponent) {
            DamageCalculator damageCalculator = new DamageCalculator() {Attacker = attacker, Opponent = opponent};

            double damageDealt = damageCalculator.CalculateDamage();

            Console.Clear();
            Console.WriteLine($"\t{attacker.Name}\nPress any key to attack!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("------------------------------------");
            Console.WriteLine($" \t{attacker.Name} distracts {opponent.Name}.");
            Console.WriteLine($" \tDamage Dealt: {damageDealt}");
            Console.WriteLine("------------------------------------\n");
            
            opponent.TakeDamage(damageDealt);
            opponent.ShowStats();

        }
        

    }
}