using imasderol.domain.shared.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imasderol.domain.zombicide.Weapon.ValueObjects
{
    public class Attack
    {
        public int MinimumRange { get; }
        public int MaximumRange { get; }
        public int NumberOfDice { get; }
        public bool UsesAmmunition { get; }        
        public int Accuracy { get; }
        public int Damage { get; }
        public bool? IsSilent { get; }

        internal Attack(Guid id, Range range, NumberOfDice numberOfDice, Accuracy accuracy, Damage damage, bool silent)
        {
            Validate(range,numberOfDice,accuracy,damage);

            MinimumRange = range.Min;
            MaximumRange = range.Max;
            NumberOfDice = numberOfDice.Value;
            Accuracy = accuracy.Value;
            Damage = damage.Value;
            IsSilent = silent;
            
        }

        private static void Validate( Range range, NumberOfDice numberOfDice, Accuracy accuracy, Damage damage)
        {            
            if ((numberOfDice.Value * 6) < accuracy.Value) throw new ValidationException("accuracy exceeds the maximum possible roll of dice");
        }
    }
}
