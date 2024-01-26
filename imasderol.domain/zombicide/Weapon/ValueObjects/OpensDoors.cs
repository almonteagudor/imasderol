using imasderol.domain.shared.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imasderol.domain.zombicide.Weapon.ValueObjects
{
    public class OpensDoors
    {

        public bool Value { get; }
        public bool Silent { get; }

        internal OpensDoors(bool value,bool silent)
        {
            Validate(value,silent);

            Value = value;
        }

        private static void Validate(bool value, bool silent)
        {
            if (!value && silent) throw new ValidationException("Equipment that cannot open doors cannot be silent");
        }
    }
}
