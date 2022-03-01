namespace mis321_pa2_rakern
{
    public class JackTheMonkey : Character
    {
        public JackTheMonkey() {
            Identity = "Jack the Monkey";
            AttackBehavior = new ScreechAttack();
        }
    }
}