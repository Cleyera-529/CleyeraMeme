using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.Items.Boss
{
    public class ForbiddenFruit : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 32;
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
            return true;
        }
        public override bool UseItem(Player P)
        {
            Main.PlaySound(SoundID.Item2, (int)P.position.X, (int)P.position.Y);
            NPC.NewNPC((int)P.Center.X, (int)P.Center.Y - 365, mod.NPCType("Center1"), 0, 0f, 0f, 0f, 0f, 255);
            NPC.NewNPC((int)P.Center.X, (int)P.Center.Y + 525, mod.NPCType("Center2"), 0, 0f, 0f, 0f, 0f, 255);
            NPC.NewNPC((int)P.Center.X + 365, (int)P.Center.Y + 65, mod.NPCType("Center3"), 0, 0f, 0f, 0f, 0f, 255);
            NPC.NewNPC((int)P.Center.X - 365, (int)P.Center.Y + 65, mod.NPCType("Center4"), 0, 0f, 0f, 0f, 0f, 255);
            Main.NewText("What might the character look like?", 255, 0, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}