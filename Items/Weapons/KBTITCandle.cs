using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CleyeraMeme.Items.Weapons
{
    public class KBTITCandle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("KBTIT Candle");
            Tooltip.SetDefault("'ArigatoNASU!'");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 50;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 2;
            item.useTime = 4;
            item.noMelee = true;
            item.damage = 180;
            item.knockBack = 3f;
            item.autoReuse = true;
            item.useTurn = false;
            item.rare = ItemRarityID.Yellow;
            item.ranged = true;
            item.value = Item.sellPrice(0, 12, 0, 0);
            item.UseSound = SoundID.Item20;
            item.shoot = ModContent.ProjectileType<Projectiles.Flames>();
            item.useAmmo = AmmoID.Gel;
            item.shootSpeed = 10f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Flamethrower, 1);
            recipe.AddIngredient(ItemID.EldMelter, 1);
            recipe.AddIngredient(ItemID.IllegalGunParts, 10);
            recipe.AddIngredient(ItemID.GoldenCandelabra, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 1f * 1.0f; //Replace 45 with whatever spread you want
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / 4f;
            double offsetAngle;
            int i;
            for (i = 0; i < 5; i++) //Replace 2 with number of projectiles
            {
                offsetAngle = startAngle + deltaAngle * i;
                Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockBack, item.owner);
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            return true;
        }
    }
}