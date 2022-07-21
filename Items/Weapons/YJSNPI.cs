using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.Items.Weapons
{
    public class YJSNPI : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'NUH!HEH!HEH!AAAAAAAAAAAA!!'");
        }
        public override void SetDefaults()
        {
            item.damage = 1919;
            item.crit = 810;
            item.scale = 0.8f;
            item.width = 450;
            item.height = 450;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 19f;
            item.value = Item.sellPrice(0, 36, 43, 64);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/EyePower");
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("EyePower");
            item.shootSpeed = 19f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 114514);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}