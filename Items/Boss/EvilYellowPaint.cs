using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.Items.Boss
{
    public class EvilYellowPaint : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Evil Paint");
            Tooltip.SetDefault("Summons spoo");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.maxStack = 20;
            item.value = 0;
            item.rare = ItemRarityID.Purple;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("Spoo"));
        }
        public override bool UseItem(Player P)
        {
            Main.PlaySound(SoundID.Roar, (int)P.position.X, (int)P.position.Y, 0);
            if (P.direction > 0)
            {
                NPC.NewNPC((int)P.Center.X + 600, (int)P.Center.Y, mod.NPCType("Spoo"), 0, 0f, 0f, 0f, 0f, 255);
            }
            else
            {
                NPC.NewNPC((int)P.Center.X - 600, (int)P.Center.Y, mod.NPCType("Spoo"), 0, 0f, 0f, 0f, 0f, 255);
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}