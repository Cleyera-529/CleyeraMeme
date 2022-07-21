using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace CleyeraMeme.Items.Weapons
{
    public class Idiot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("☺");
            Tooltip.SetDefault("'You are an idiot!"
                + "\n  Ahahahahahaha!!ahahahaha!'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(30, 2));
        }
        public override void SetDefaults()
        {
            item.damage = 66;
            item.width = 30;
            item.height = 30;
            item.useTime = 300;
            item.useAnimation = 300;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = ItemRarityID.Blue;
            item.autoReuse = true;
            item.noUseGraphic = true;
            item.shoot = ModContent.ProjectileType<Projectiles.Idiot>();
            item.shootSpeed = 0.2f;
            item.UseSound = CleyeraMeme.Instance.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Idiot");
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(Main.DiscoR * 0.5f, 0 + (int)(Main.DiscoR * 1.5f), 0 + (int)(Main.DiscoR * 1.5f));
                }
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, Main.rand.Next(2));
            return false;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}