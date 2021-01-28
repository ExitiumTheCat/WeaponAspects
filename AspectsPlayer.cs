using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace WeaponAspects
{
    public class AspectsPlayer : ModPlayer
    {
        public int WHichAspectToUnlock;
        public int[] IceBlade = new int[3];

        public override void OnHitAnything(float x, float y, Entity victim)
        {
            if (IceBlade[0] == 0)
            {
                IceBlade[0] = 1;
                IceBlade[1] = 1;
            }
            else
            {
                IceBlade[0] = 0;
                IceBlade[1] = 1;
            }
            if (Main.rand.NextFloat() < .01f)
            {
                WHichAspectToUnlock = Main.rand.Next(0, 3);
                switch (player.HeldItem.Name) {
                    case ("Ice Blade"):
                        if (IceBlade[WHichAspectToUnlock] == 0)
                        {
                            IceBlade[WHichAspectToUnlock] = 1;
                            //Do Stuff
                        }
                        break;
                }
            }
        }
        public override TagCompound Save()
        {
            return new TagCompound {
        {"IceBlade", IceBlade},
    };
        }

        public override void Load(TagCompound tag)
        {
            if (tag.ContainsKey("IceBlade"))
                IceBlade = tag.GetIntArray("IceBlade");
        }
    }
  }
