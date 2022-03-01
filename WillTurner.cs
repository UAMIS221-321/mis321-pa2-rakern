namespace mis321_pa2_rakern
{
    public class WillTurner : Character
    {
        public WillTurner() {
            Identity = "Will Turner";
            AttackBehavior = new SwordAttack();
        }
    }
}