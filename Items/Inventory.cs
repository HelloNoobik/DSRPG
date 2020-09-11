using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Enums;
using Inventory.Classes;

namespace Inventory
{
    class Inventory
    {
        public WeaponsSlot WeaponSlot { get; }
        public ArmorsSlot HeadArmor = new ArmorsSlot(ArmorsType.Helmet);
        public ArmorsSlot BodyArmor = new ArmorsSlot(ArmorsType.Body);
        public ArmorsSlot LegsArmor = new ArmorsSlot(ArmorsType.Leg);
        public ArmorsSlot BootsArmor = new ArmorsSlot(ArmorsType.Boot);
    }
}
