using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using WeaponAspects.Projectiles;

namespace WeaponAspects.Weapons
{
	public class GoldBroadswordMidas : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gold Broadsword");
			Tooltip.SetDefault("The weapon of the so called \"Gold King\" was tainted with its own blood.");
		}

		public override void SetDefaults()
		{
			item.SetDefaults1(4);
			item.useAnimation = 20;
			item.damage = 13;
			item.scale = 1.05f;
			item.value = 9000;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.AddBuff(BuffID.Midas, 300);
		}
	}
}