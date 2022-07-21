using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.NPCs.TheCharacter
{
    [AutoloadBossHead]
    public class Center3 : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Character(3)");
        }
        public override void SetDefaults()
        {
            npc.aiStyle = 51;
            aiType = NPCID.Plantera;
            npc.lifeMax = 114514;        //this is the npc health
            npc.damage = 200;    //this is the npc damage
            npc.defense = 0;         //this is the npc defense
            npc.knockBackResist = 0f;
            npc.width = 140; //this is where you put the npc sprite width.     important
            npc.height = 177; //this is where you put the npc sprite height.   important
            npc.lavaImmune = true;       //this make the npc immune to lava
            npc.noGravity = true;           //this make the npc float
            npc.noTileCollide = true;        //this make the npc go tru walls
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath62;
            npc.npcSlots = 10f;
            npc.netAlways = true;
            npc.netUpdate = true;
            npc.scale = 0.9f;
            npc.value = Item.buyPrice(1, 14, 5, 14);
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
            npc.lifeMax = 114514;        //this is the npc health
            npc.damage = 300;    //this is the npc damage
            npc.defense = 0;         //this is the npc defense
            npc.value = Item.buyPrice(1, 0, 0, 0);
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;   //this make the NPC Health Bar biger
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
            if (!NPC.AnyNPCs(mod.NPCType("Center1")) && !NPC.AnyNPCs(mod.NPCType("Center2")) && !NPC.AnyNPCs(mod.NPCType("Center4")))
            {
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("TheCharacter"));
            }
            return true;
        }
    }
}