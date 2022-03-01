namespace mis321_pa2_rakern
{
    public class DavyJones : Character
    {
        public DavyJones() {
            Identity = "Davy Jones";
            AttackBehavior = new CannonAttack();
        }
    }
}