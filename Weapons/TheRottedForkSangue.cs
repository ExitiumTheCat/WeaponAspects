using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using WeaponAspects.Projectiles;

namespace WeaponAspects.Weapons
{
	public class TheRottedForkSangue : ModItem
	{
		public int Bingus;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Rotted Fork");
			Tooltip.SetDefault("Bingus");
		}

		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useStyle = 5;
			item.useAnimation = 31;
			item.useTime = 31;
			item.shootSpeed = 4f;
			item.knockBack = 5f;
			item.width = 40;
			item.height = 40;
			item.damage = 14;
			item.scale = 1.1f;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<TheRottedForkSangueProj>();
			item.rare = 1;
			item.value = Item.sellPrice(0, 1, 50, 0);
			item.noMelee = true;
			item.noUseGraphic = true;
			item.melee = true;
		}		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
			}
			else
			{
			}
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
			
		public override bool AltFunctionUse(Player player)
		{
			if (Bingus >= 5)
			{
				return true;
			}
			return false;
		}	
	}
}