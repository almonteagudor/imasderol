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
        public int Type { get; }
        public int MinimumRange { get; }
        public int MaximumRange { get; }
        public int NumberOfDice { get; }
        public int Accuracy { get; }
        public int Damage { get; }
        public bool Silent { get; }

        internal Attack(Guid id,Type type, Range range, NumberOfDice numberOfDice, Accuracy accuracy, Damage damage, bool silent)
        {
            Validate(type,range,numberOfDice,accuracy,damage);

            Type = type.Value;
            MinimumRange = range.Min;
            MaximumRange = range.Max;
            NumberOfDice = numberOfDice.Value;
            Accuracy = accuracy.Value;
            Damage = damage.Value;
            Silent = silent;
            
        }

        private static void Validate(Type type, Range range, NumberOfDice numberOfDice, Accuracy accuracy, Damage damage)
        {
            if ( type.Value == (int)AttackType.Melee && range.Max>0) throw new ValidationException("Mele attacks cannot have a range greater than zero");
            if ((numberOfDice.Value * 6) < accuracy.Value) throw new ValidationException("accuracy exceeds the maximum possible roll of dice");
        }
    }
}
