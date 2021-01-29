using System;
using Terraria;
using Terraria.ModLoader;

namespace WeaponAspects.Projectiles
{
    public class PermafrostBlizzard : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blizzard");
        }
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.timeLeft = 100;
            projectile.tileCollide = false;
        }
		public override void AI()
		{
            Dust dust;
            dust = Main.dust[Dust.NewDust(projectile.Center, 30, 30, 16, 0f, 0f, 0, default, 1.7f)];
            dust.noGravity = true;
            double deg = (double)projectile.ai[1];
            double rad = deg * (Math.PI / 180);
            double dist = 32;

            projectile.position.X = Main.player[projectile.owner].Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2 - 20;
            projectile.position.Y = Main.player[projectile.owner].Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2 - 20;

            projectile.ai[1] += 10f;
        }
	}
}
 