using imasderol.domain.shared.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace imasderol.domain.zombicide.Weapon.ValueObjects
{
    public class Accuracy
    {
        public const int MaxValue = 12;
        public int Value { get; }
        internal Accuracy(int value) {
            Validate(value);
            Value = value;
        }

        private void Validate(int value)
        {
            if (value < 1) throw new ValidationException("Accuracy must be at least One");
            if (value > MaxValue) throw new ValidationException($"Accuracy must be {MaxValue} at most");
        }
    }
}
