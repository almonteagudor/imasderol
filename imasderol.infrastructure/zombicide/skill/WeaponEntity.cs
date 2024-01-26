using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imasderol.infrastructure.zombicide.skill
{
    public class WeaponEntity
    {
        public Guid Id { get; init; }

        public string Name { get; set; }
      
        public bool DuaWield { get; set; }

        public bool OpensDoors { get; set; }

        public bool OpensDoorsSilently { get; set; }

        public int? AmmoType { get; set; }

        public required List<WeaponAttackEntity> Attacks { get; set; }
    }
}
