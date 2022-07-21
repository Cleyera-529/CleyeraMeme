using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace CleyeraMeme.Projectiles
{
    public class Onarou : ModProjectile
    {
        public override string Texture
        {
            get
            {
                return "CleyeraMeme/Items/Weapons/Onarou";
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("INGO-roid");
        }
        public override void SetDefaults()
        {
            projectile.thrown = true;
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 2;
            projectile.timeLeft = 300;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.penetrate = -1;
            projectile.netUpdate = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 0;
            aiType = 48;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.timeLeft > 1)
            {
                projectile.timeLeft = 1;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (projectile.timeLeft > 1)
            {
                projectile.timeLeft = 1;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            damage += target.defense / 2;
        }
        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            damage += target.statDefense / 2;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/KonnnamonoBreak"), projectile.position);
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/KonnnamonoBreak"), projectile.position);
            if (projectile.owner == Main.myPlayer)
            {
                projectile.penetrate = -1;
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 120;
                projectile.height = 120;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                projectile.Damage();
            }
            int num3;
            for (int num614 = 0; num614 < 10; num614 = num3 + 1)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
                num3 = num614;
            }
            for (int num615 = 0; num615 < 5; num615 = num3 + 1)
            {
                int num616 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 172, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num616].noGravity = true;
                Main.dust[num616].shader = GameShaders.Armor.GetSecondaryShader(44, Main.LocalPlayer);
                Dust dust = Main.dust[num616];
                dust.velocity *= 3f;
                num616 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 172, 0f, 0f, 100, default(Color), 1.0f);
                Main.dust[num616].shader = GameShaders.Armor.GetSecondaryShader(44, Main.LocalPlayer);
                dust = Main.dust[num616];
                dust.velocity *= 2f;
                num3 = num615;
            }
        }
    }
}