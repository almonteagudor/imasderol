using imasderol.domain.shared.exceptions;
using imasderol.domain.shared.valueObjects;
using imasderol.domain.zombicide.Weapon.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace imasderol.domain.zombicide.Weapon
{
    public class Weapon
    {
        public Guid Id { get; init; }
        public Name Name { get;  }
        public bool DualWield { get; }
        public OpensDoors Doors { get; }
        public Attack PrimaryAttack { get; }
        public Attack SecondaryAttack { get; }
        public AmmunitionType AmmunitionType { get; }

        internal Weapon(Guid id, Name name, bool dualWield, OpensDoors doors, Attack primaryAttack, Attack secondaryAttack, AmmunitionType ammunition)
        {
            Validate(name, doors, primaryAttack, secondaryAttack);
            Id = id;
            Name = name;
            DualWield = dualWield;
            Doors = doors;
            PrimaryAttack = primaryAttack;
            SecondaryAttack = secondaryAttack;
            AmmunitionType = ammunition;
        }

        private void Validate(Name name, OpensDoors doors, Attack primaryAttack, Attack secondaryAttack)
        {            
            if (PrimaryAttack == null && secondaryAttack == null) throw new ValidationException("A weapon must have at least one attack");
            if (SecondaryAttack != null && PrimaryAttack == null) throw new ValidationException("A weapon cannot have a secondary attack without a primary one");
        }
    }
}
