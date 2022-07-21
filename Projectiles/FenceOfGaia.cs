using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.Projectiles
{
    public class FenceOfGaia : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fence of Gaia");
        }
        public override void SetDefaults()
        {
            projectile.width = 168;
            projectile.height = 168;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.scale = 1.0f;
        }
    }
}