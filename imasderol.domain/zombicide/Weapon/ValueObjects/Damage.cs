using imasderol.domain.shared.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imasderol.domain.zombicide.Weapon.ValueObjects
{
    public class Damage
    {
        public const int MaxDamage = 12;
        public int Value { get; }

       internal Damage(int value)
        {
            Validate(value);
            Value = value;
        }

        private void Validate(int value)
        {
            if (value < 1) throw new ValidationException("Damage must be at least one");
            if (value > MaxDamage) throw new ValidationException($"Damage must be {MaxDamage} at most");
        }
    }
}
