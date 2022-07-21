using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.Projectiles
{
    public class SaradaOroshi : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("RRM Sarada-Oroshi");
        }
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.scale = 0.9f;
            projectile.aiStyle = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 0;
        }
        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 60)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SaradaOroshi"), projectile.position);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SaradaOroshi"), projectile.position);
                projectile.ai[0] = 0;
            }
        }
    }
}