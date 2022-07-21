using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.Items.Weapons
{
    public class OBackSuchAsTheEndOfTheWorld : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("O-Back such as the end of the world");
            Tooltip.SetDefault("'Too big NKTI'");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 30;
            item.damage = 334;
            item.knockBack = 3.0F;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.melee = true;
            item.rare = ItemRarityID.Pink;
            item.UseSound = CleyeraMeme.Instance.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/NKTIBRMK");
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shootSpeed = 12.0f;
            item.useTime = 5;
            item.useAnimation = 55;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.OBackSuchAsTheEndOfTheWorld>();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = Main.rand.Next(2, 4);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(45));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}