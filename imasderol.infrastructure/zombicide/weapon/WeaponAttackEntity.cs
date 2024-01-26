using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imasderol.infrastructure.zombicide.weapon
{
    public class WeaponAttackEntity
    {
        public Guid Id { get; set; }
        public int Type { get; set; }
        public int MinimumRange { get; set; }
        public int MaximumRange { get; set; }
        public int NumberOfDice { get; set; }
        public int Accuracy { get; set; }
        public int Damage { get; set; }
        public int AmmunitionType { get; set; }
        public bool Silent { get; set; }

    }
}
