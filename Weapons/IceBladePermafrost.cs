using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WeaponAspects.Projectiles;

namespace WeaponAspects.Weapons
{
	public class IceBladePermafrost : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Blade");
			Tooltip.SetDefault("Shoots an icy bolt");
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

			item.width = 30;
			item.height = 30;
			//The actual sprite size is 34x40 but in vanilla code this is the size
			item.shoot = ProjectileID.IceBolt;
			item.shootSpeed = 9.5f;
			item.knockBack = 4.75f;
			item.melee = true;
			item.value = 20000;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(player.position, new Vector2(10, 10), ModContent.ProjectileType<PermafrostBlizzard>(), 5, 0, player.whoAmI);
			return true;
		}
	}
}