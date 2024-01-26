using imasderol.domain.shared.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imasderol.domain.zombicide.Weapon.ValueObjects
{
    public class NumberOfDice
    {
        public const int MaxDice = 2;
        public int Value { get; }
        internal NumberOfDice(int value)
        {
            Validate(value);
            Value= value;
        }

        private void Validate(int value)
        {
            if (value < 1) throw new ValidationException("Number of dice must be at least one");
            if (value > MaxDice) throw new ValidationException($"Number of Dice must be {MaxDice} at most");
        }
    }
}
