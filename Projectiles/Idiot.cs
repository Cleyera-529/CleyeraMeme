using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CleyeraMeme.Projectiles
{
    public class Idiot : ModProjectile
    {
        public override string Texture
        {
            get
            {
                return "CleyeraMeme/Items/Weapons/Idiot";
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("☺");
            Main.projFrames[projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 34;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ranged = true;
            projectile.magic = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 1;
            projectile.netUpdate = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 0;
        }
        public override void OnHitPvp(Player player, int damage, bool crit)
        {
            damage *= 1000000;
        }
        public override void AI()
        {
            projectile.frame = (int)projectile.ai[0];
            projectile.spriteDirection = 0;
            projectile.localAI[1]++;
            if (projectile.localAI[1] >= 300)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Idiot"), projectile.position);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0.1f, mod.ProjectileType("Idiot"), (int)(projectile.damage), 0, projectile.owner, Main.rand.Next(2));
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0.1f, 0f, mod.ProjectileType("Idiot"), (int)(projectile.damage), 0, projectile.owner, Main.rand.Next(2));
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -0.1f, mod.ProjectileType("Idiot"), (int)(projectile.damage), 0, projectile.owner, Main.rand.Next(2));
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -0.1f, 0f, mod.ProjectileType("Idiot"), (int)(projectile.damage), 0, projectile.owner, Main.rand.Next(2));
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0.07f, 0.07f, mod.ProjectileType("Idiot"), (int)(projectile.damage), 0, projectile.owner, Main.rand.Next(2));
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0.07f, -0.07f, mod.ProjectileType("Idiot"), (int)(projectile.damage), 0, projectile.owner, Main.rand.Next(2));
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -0.07f, 0.07f, mod.ProjectileType("Idiot"), (int)(projectile.damage), 0, projectile.owner, Main.rand.Next(2));
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -0.07f, -0.07f, mod.ProjectileType("Idiot"), (int)(projectile.damage), 0, projectile.owner, Main.rand.Next(2));
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}