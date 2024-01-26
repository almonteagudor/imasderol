using imasderol.domain.shared.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imasderol.domain.zombicide.Weapon.ValueObjects
{
    public class Range
    {
        public const int MaxRange = 10;
        public int Min { get; }
        public int Max { get; }

        internal Range(int min, int max)
        {
            Validate(min, max);

            Min = min;
            Max = max;
        }

        private static void Validate(int min, int max)
        {
            if (min < 0) throw new ValidationException("Minimum range is zero");
            if (min > MaxRange) throw new ValidationException($"Minimum range exceeded the range limit ({MaxRange})");
            if (max < min) throw new ValidationException("Maximum range is less than minimum");
            if (max > MaxRange) throw new ValidationException($"Maximum range exceed the range limit ({MaxRange})");
        }
    }
}
