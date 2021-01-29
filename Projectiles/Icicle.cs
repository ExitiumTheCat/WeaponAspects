using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace WeaponAspects.Projectiles
{
    public class Icicle : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icicle");
        }
        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 36;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.melee = true;
            projectile.timeLeft = 60 * 10;
            projectile.tileCollide = true;
            projectile.aiStyle = 1;
        }
		public override void AI()
		{
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45f);
            projectile.velocity.Y += 0.1f;
        }
	}
}
 