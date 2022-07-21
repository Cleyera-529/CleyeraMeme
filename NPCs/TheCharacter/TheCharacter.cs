using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.NPCs.TheCharacter
{
    [AutoloadBossHead]
    public class TheCharacter : ModNPC
    {
        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 99999999;
            npc.damage = 9999999;
            npc.defense = 1000;
            npc.knockBackResist = 0f;
            npc.width = 460;
            npc.height = 360;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath62;
            npc.npcSlots = 20f;
            npc.netAlways = true;
            npc.netUpdate = true;
            npc.scale = 1.0f;
            npc.value = Item.buyPrice(999, 99, 99, 99);
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
            npc.boss = true;
            music = MusicID.LunarBoss;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 666666666;
            npc.damage = 99999999;
            npc.defense = 5000;
            npc.value = Item.buyPrice(999, 99, 99, 99);
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
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
                    npc.active = false;
                }
            }
            player.releaseMount = false;
            if (player.mount.Active)
            {
                player.mount.Dismount(player);
            }
            npc.TargetClosest(true);
            float speed = 17f;
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
            //SinsWorld.downedTheCharacter = true;
        }
    }
}