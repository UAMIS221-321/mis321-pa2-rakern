namespace mis321_pa2_rakern
{
    public class JackSparrow : Character
    {
        public JackSparrow() {
            Identity = "Jack Sparrow";
            AttackBehavior = new DistractAttack();
        }
    }
}