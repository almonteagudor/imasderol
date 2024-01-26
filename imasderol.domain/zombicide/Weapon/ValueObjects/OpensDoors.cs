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

        public bool CanOpenDoors { get; }
        public bool? IsSilent { get; }

        internal OpensDoors(bool canOpenDoors,bool? isSilent)
        {
            Validate(canOpenDoors,isSilent);

            CanOpenDoors = canOpenDoors;
        }

        private static void Validate(bool canOpenDoors, bool? isSilent)
        {
            if (!canOpenDoors && isSilent != null) throw new ValidationException($"For equipment that cannot open doors {nameof(IsSilent)} should be null");            
        }
    }
}
