using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.Items.Weapons
{
    public class Onarou : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("RRM-de-Onarou");
            Tooltip.SetDefault("'Such a thing!'");
        }
        public override void SetDefaults()
        {
            item.damage = 4545;
            item.crit = 931;
            item.width = 50;
            item.height = 50;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.knockBack = 20f;
            item.value = Item.sellPrice(0, 45, 45, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = CleyeraMeme.Instance.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Konnnamono");
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Onarou");
            item.shootSpeed = 11f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 45);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}