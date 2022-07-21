using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.Projectiles
{
    public class EyePower : ModProjectile
    {
        public override string Texture
        {
            get
            {
                return "CleyeraMeme/Items/Weapons/YJSNPI";
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye Power");
        }
        public override void SetDefaults()
        {
            projectile.width = 649;
            projectile.height = 744;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.scale = 0.8f;
        }
    }
}