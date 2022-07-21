using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.Items.Weapons
{
    public class SaradaOroshi : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("RRM Sarada-Oroshi");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 4545;
            item.width = 30;
            item.height = 30;
            item.useTime = 7;
            item.useAnimation = 15;
            item.channel = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.axe = 4545 / 5;
            item.tileBoost += 19;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 19;
            item.value = Item.sellPrice(0, 45, 45, 0);
            item.rare = ItemRarityID.Yellow;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.SaradaOroshi>();
            item.shootSpeed = 46f;
            item.UseSound = CleyeraMeme.Instance.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SaradaOroshi");
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