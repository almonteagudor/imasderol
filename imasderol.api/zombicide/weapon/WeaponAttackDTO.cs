namespace imasderol.api.zombicide.weapon
{
    public class WeaponAttackDTO
    {
        public AttackType AttackType { get; set; }
        public int MinimumRange {  get; set; }
        public int MaximumRange { get; set; }
        public int NumberOfDice { get; set; }
        public int Accuracy { get; set; }
        public int Damage { get; set; }
        public bool Silent { get; set; }

        public WeaponAttackDTO() { }
    }
}
