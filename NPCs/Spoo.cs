using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.NPCs
{
    [AutoloadBossHead]
    public class Spoo : ModNPC
    {
        private bool Esc;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 1;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 220000;
            npc.damage = 300;
            npc.defense = 100;
            npc.knockBackResist = 0f;
            npc.width = 226;
            npc.height = 158;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            //npc.HitSound = SoundID.NPCHit57;
            //npc.DeathSound = SoundID.NPCDeath61;
            npc.HitSound = SoundID.NPCDeath61;
            npc.DeathSound = SoundID.NPCHit57;
            npc.npcSlots = 5f;
            npc.netAlways = true;
            npc.scale = 1.0f;
            npc.value = Item.buyPrice(4, 0, 0, 0);
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
            npc.boss = true;
            music = MusicID.Boss2;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 300000;
            npc.damage = 400;
            npc.defense = 200; 
            npc.value = Item.buyPrice(2, 0, 0, 0);
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.2f;
            return null;
        }
        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            Player player = Main.player[npc.target];
            if (Main.rand.Next(10) == 0)
            {
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SpooBall"));
            }
            return true;
        }
        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;
            if (player.dead || !player.active)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (player.dead || !player.active)
                {
                    if (npc.direction > 0)
                    {
                        npc.velocity.X = -12f;
                    }
                    else
                    {
                        npc.velocity.X = 12f;
                    }
                    if (!Esc)
                    {
                        npc.timeLeft = 120;
                        Esc = true;
                    }
                }
            }
            npc.spriteDirection = -npc.direction;
            player.gravity = 0f;
            player.releaseMount = false;
            if (player.mount.Active)
            {
                player.mount.Dismount(player);
            }
            npc.TargetClosest(true);
            float speed = 6f;
            npc.velocity.X = (float)Math.Cos((float)Math.Atan2(npc.Center.Y - Main.player[npc.target].Center.Y, npc.Center.X - Main.player[npc.target].Center.X)) * -speed;
            npc.velocity.Y = (float)Math.Sin((float)Math.Atan2(npc.Center.Y - Main.player[npc.target].Center.Y, npc.Center.X - Main.player[npc.target].Center.X)) * -speed;
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.SuperHealingPotion;
            if (Main.expertMode)
            {

            }
            else
            {

            }
            //SinsWorld.downedSpoo = true;
        }
    }
}
