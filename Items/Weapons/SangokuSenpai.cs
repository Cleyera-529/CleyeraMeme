using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CleyeraMeme.Items.Weapons
{
    public class SangokuSenpai : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Taichi Sangoku");
            Tooltip.SetDefault("'Fence of Gaia!!'");
        }
        public override void SetDefaults()
        {
            item.crit = 1081;
            item.damage = 359;
            item.width = 200;
            item.height = 200;
            item.scale = 0.9f;
            item.rare = ItemRarityID.Yellow;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 190;
            item.useAnimation = 190;
            item.knockBack = 10F;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/FenceOfGaia");
            item.shoot = ModContent.ProjectileType<Projectiles.FenceOfGaia>();
            item.shootSpeed = 30;
            item.value = Item.sellPrice(3, 59, 10, 81);
            item.autoReuse = false;
            item.noMelee = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 15; i++)
            {
                position = player.Center + new Vector2((-(float)Main.rand.Next(0, 901) * player.direction), -600f);
                position.Y -= (100 * i);
                Vector2 heading = target - position;
                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }
                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }
                heading.Normalize();
                heading *= new Vector2(speedX, speedY).Length();
                speedX = heading.X;
                speedY = heading.Y + Main.rand.Next(-800, 800) * 0.02f;
                Projectile.NewProjectile(position.X, position.Y, speedX / 2, speedY / 2, type, damage * 2, knockBack, player.whoAmI, 0f, ceilingLimit);

            }
            return false;
        }
    }
}