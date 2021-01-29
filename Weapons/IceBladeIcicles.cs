using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using WeaponAspects.Projectiles;

namespace WeaponAspects.Weapons
{
	public class IceBladeIcicles : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Blade");
			Tooltip.SetDefault("You can throw the blade with Right-Click, although swinging it no longer shoots icy bolts.");
		}

		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.crit = 2;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.useStyle = 1;
			item.damage = 17;
			item.useAnimation = 20;
			item.useTime = 55;
			item.width = 34;
			item.height = 36;
			item.knockBack = 4.75f;
			item.melee = true;
			item.value = 20000;
		}
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.shoot = ProjectileType<Icicle>();
				item.shootSpeed = 9.5f;
				item.useAnimation = 40;
				item.useTime = 40;
				item.noMelee = true;
				item.noUseGraphic = true;
			}
			else
			{
				item.shoot = ProjectileID.None;
				item.useAnimation = 20;
				item.useTime = 55;
				item.noMelee = false;
				item.noUseGraphic = false;
			}
			return true;
			}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}	
	}
}