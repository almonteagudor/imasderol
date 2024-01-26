﻿using imasderol.domain.shared.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imasderol.domain.zombicide.Weapon.ValueObjects
{
    public class AmmunitionType
    {
        public int Value { get; }

        internal AmmunitionType(int value)
        {
            Validate(value);
            Value = value;
        }

        private void Validate(int value)
        {
            if ( !Enum.IsDefined(typeof(MunitionType), value)) throw new ValidationException($"The Attack Type must be one of these :{String.Join(",", Enum.GetNames(typeof(MunitionType)))}");
        }
    }
}
