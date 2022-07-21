using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.NPCs.TheCharacter
{
    [AutoloadBossHead]
    public class Center4 : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Character(4)");
        }
        public override void SetDefaults()
        {
            npc.aiStyle = 11;
            aiType = NPCID.DungeonGuardian;
            npc.lifeMax = 810;
            npc.damage = 200;
            npc.defense = 0;
            npc.knockBackResist = 0f;
            npc.width = 178;
            npc.height = 158;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath62;
            npc.netUpdate = true;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                if (k != 69)
                {
                    npc.buffImmune[k] = true;
                }
            }
        }
        public override void BossHeadRotation(ref float rotation)
        {
            rotation = npc.rotation;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1919;
            npc.damage = 300;
            npc.defense = 0;
            npc.value = Item.buyPrice(1, 0, 0, 0);
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
        }
        public override bool PreNPCLoot()
        {
            return false;
        }
        public override bool CheckDead()
        {
            if (!NPC.AnyNPCs(mod.NPCType("Center1")) && !NPC.AnyNPCs(mod.NPCType("Center2")) && !NPC.AnyNPCs(mod.NPCType("Center3")))
            {
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("TheCharacter"));
            }
            return true;
        }
    }
}