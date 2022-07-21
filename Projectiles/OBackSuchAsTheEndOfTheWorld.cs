using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace CleyeraMeme.Projectiles
{
    public class OBackSuchAsTheEndOfTheWorld : ModProjectile
    {
        public override string Texture
        {
            get
            {
                return "CleyeraMeme/Items/Weapons/OBackSuchAsTheEndOfTheWorld";
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("O-Back such as the end of the world");
        }
        public override void SetDefaults()
        {
            projectile.timeLeft = 450;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.width = 16;
            projectile.height = 16;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.extraUpdates = 0;
            projectile.light = 0.25f;
        }
        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 390f)
            {
                projectile.alpha += 4;
                projectile.damage = (int)(projectile.damage * 0.95);
                projectile.knockBack = (int)(projectile.knockBack * 0.95);
            }
            projectile.rotation += 0.25f;
            float num1 = projectile.Center.X;
            float num2 = projectile.Center.Y;
            float num3 = 600f;
            bool flag = false;
            for (int num4 = 0; num4 < 200; num4++)
            {
                if (Main.npc[num4].CanBeChasedBy(projectile, false) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[num4].Center, 1, 1))
                {
                    float num5 = Main.npc[num4].position.X + (float)(Main.npc[num4].width / 2);
                    float num6 = Main.npc[num4].position.Y + (float)(Main.npc[num4].height / 2);
                    float num7 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num5) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num6);
                    if (num7 < num3)
                    {
                        num3 = num7;
                        num1 = num5;
                        num2 = num6;
                        flag = true;
                    }
                }
            }
            if (flag)
            {
                float num8 = 25f;
                Vector2 vector35 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num9 = num1 - vector35.X;
                float num10 = num2 - vector35.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                projectile.velocity.X = (projectile.velocity.X * 20f + num9) / 21f;
                projectile.velocity.Y = (projectile.velocity.Y * 20f + num10) / 21f;
                return;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int num303 = 0; num303 < 3; num303++)
            {
                int num304 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 73, 0f, 0f, 100, default(Color), 0.8f);
                Main.dust[num304].noGravity = true;
                Main.dust[num304].velocity *= 1.2f;
                Main.dust[num304].velocity -= projectile.oldVelocity * 0.3f;
            }
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
    }
}