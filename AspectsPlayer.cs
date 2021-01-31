using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace WeaponAspects
{
    public class AspectsPlayer : ModPlayer
    {
        public int WHichAspectToUnlock;
        public int[] IceBlade = new int[3];
        public int[] GoldBroadsword = new int[3];

        public override void OnHitAnything(float x, float y, Entity victim)
        {
            if (Main.rand.NextFloat() < .50f)
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
                    case ("Gold Broadsword"):
                        if (GoldBroadsword[WHichAspectToUnlock] == 0)
                        {
                            GoldBroadsword[WHichAspectToUnlock] = 1;
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
        {"GoldBroadsword", GoldBroadsword},
    };
        }

        public override void Load(TagCompound tag)
        {
            if (tag.ContainsKey("GoldBroadsword"))
                GoldBroadsword = tag.GetIntArray("GoldBroadsword");
            if (tag.ContainsKey("GoldBroadsword"))
                GoldBroadsword = tag.GetIntArray("GoldBroadsword");
        }
    }
  }
