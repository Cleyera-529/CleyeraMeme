using System.Linq;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace CleyeraMeme
{
    public class CleyeraMemePlayer : ModPlayer
    {
        public int chargetime = 0;
        public bool nullified = false;
        public bool UniverseSoul = false;
        public bool EternitySoul = false;
        public override void ResetEffects()
        {
            nullified = false;
            UniverseSoul = false;
            EternitySoul = false;
        }
        public override void PostUpdateBuffs()
        {
            if (nullified)
            {
                Nullify();
            }
        }
        public override void UpdateBadLifeRegen()
        {
        }
        public override void PostUpdate()
        {
            if (NPC.AnyNPCs(mod.NPCType("Spoo")))
            {
                player.controlJump = false;
                player.releaseJump = false;
                player.dash = -1;
                player.wingTime = 0;
                player.wingTimeMax = 0;
                player.velocity.Y = 0;
                if (player.velocity.Y > 0)
                {
                    player.velocity.Y--;
                }
            }
        }
        public override void PostUpdateEquips()
        {
            if (nullified)
            {
                Nullify();
            }
        }
        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
        }
        public override void FrameEffects()
        {
            if (nullified)
            {
                Nullify();
            }
        }
        private void Nullify()
        {
            player.ResetEffects();
            player.head = -1;
            player.body = -1;
            player.legs = -1;
            player.handon = -1;
            player.handoff = -1;
            player.back = -1;
            player.front = -1;
            player.shoe = -1;
            player.waist = -1;
            player.shield = -1;
            player.neck = -1;
            player.face = -1;
            player.balloon = -1;
            nullified = true;
        }

        #region GlowMask
        private static readonly Dictionary<int, Texture2D> ItemGlowMask = new Dictionary<int, Texture2D>();
        internal static void Unload()
        {
            ItemGlowMask.Clear();
        }
        public static void AddGlowMask(int itemType, string texturePath)
        {
            ItemGlowMask[itemType] = ModContent.GetTexture(texturePath);
        }
        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            Texture2D textureLegs;
            if (!player.armor[12].IsAir)
            {
                if (player.armor[12].type >= ItemID.Count && ItemGlowMask.TryGetValue(player.armor[12].type, out textureLegs))
                {
                    InsertAfterVanillaLayer(layers, "Legs", new PlayerLayer(mod.Name, "GlowMaskLegs", delegate (PlayerDrawInfo info)
                    {
                        DrawArmorGlowMask(EquipType.Legs, textureLegs, info);
                    }));
                }
            }
            else if (player.armor[2].type >= ItemID.Count && ItemGlowMask.TryGetValue(player.armor[2].type, out textureLegs))
            {
                InsertAfterVanillaLayer(layers, "Legs", new PlayerLayer(mod.Name, "GlowMaskLegs", delegate (PlayerDrawInfo info)
                {
                    DrawArmorGlowMask(EquipType.Legs, textureLegs, info);
                }));
            }
            Texture2D textureBody;
            if (!player.armor[11].IsAir)
            {
                if (player.armor[11].type >= ItemID.Count && ItemGlowMask.TryGetValue(player.armor[11].type, out textureBody))
                {
                    InsertAfterVanillaLayer(layers, "Body", new PlayerLayer(mod.Name, "GlowMaskBody", delegate (PlayerDrawInfo info)
                    {
                        DrawArmorGlowMask(EquipType.Body, textureBody, info);
                    }));
                }
            }
            else if (player.armor[1].type >= ItemID.Count && ItemGlowMask.TryGetValue(player.armor[1].type, out textureBody))
            {
                InsertAfterVanillaLayer(layers, "Body", new PlayerLayer(mod.Name, "GlowMaskBody", delegate (PlayerDrawInfo info)
                {
                    DrawArmorGlowMask(EquipType.Body, textureBody, info);
                }));
            }
            Texture2D textureHead;
            if (!player.armor[10].IsAir)
            {
                if (player.armor[10].type >= ItemID.Count && ItemGlowMask.TryGetValue(player.armor[10].type, out textureHead))
                {
                    InsertAfterVanillaLayer(layers, "Head", new PlayerLayer(mod.Name, "GlowMaskHead", delegate (PlayerDrawInfo info)
                    {
                        DrawArmorGlowMask(EquipType.Head, textureHead, info);
                    }));
                }
            }
            else if (player.armor[0].type >= ItemID.Count && ItemGlowMask.TryGetValue(player.armor[0].type, out textureHead))
            {
                InsertAfterVanillaLayer(layers, "Head", new PlayerLayer(mod.Name, "GlowMaskHead", delegate (PlayerDrawInfo info)
                {
                    DrawArmorGlowMask(EquipType.Head, textureHead, info);
                }));
            }
            Texture2D textureItem;
            if (player.HeldItem.type >= ItemID.Count && ItemGlowMask.TryGetValue(player.HeldItem.type, out textureItem))
            {
                InsertAfterVanillaLayer(layers, "HeldItem", new PlayerLayer(mod.Name, "GlowMaskHeldItem", delegate (PlayerDrawInfo info)
                {
                    DrawItemGlowMask(textureItem, info);
                }));
            }
        }
        public static void InsertAfterVanillaLayer(List<PlayerLayer> layers, string vanillaLayerName, PlayerLayer newPlayerLayer)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].Name == vanillaLayerName && layers[i].mod == "Terraria")
                {
                    layers.Insert(i + 1, newPlayerLayer);
                    return;
                }
            }
            layers.Add(newPlayerLayer);
        }
        public static void DrawArmorGlowMask(EquipType type, Texture2D texture, PlayerDrawInfo info)
        {
            switch (type)
            {
                case EquipType.Head:
                    {
                        DrawData drawData = new DrawData(texture, new Vector2((int)(info.position.X - Main.screenPosition.X) + ((info.drawPlayer.width - info.drawPlayer.bodyFrame.Width) / 2), (int)(info.position.Y - Main.screenPosition.Y) + info.drawPlayer.height - info.drawPlayer.bodyFrame.Height + 4) + info.drawPlayer.headPosition + info.headOrigin, info.drawPlayer.bodyFrame, info.headGlowMaskColor, info.drawPlayer.headRotation, info.headOrigin, 1f, info.spriteEffects, 0);
                        drawData.shader = info.headArmorShader;
                        Main.playerDrawData.Add(drawData);
                    }
                    return;
                case EquipType.Body:
                    {
                        int k = 0;
                        Rectangle bodyFrame = info.drawPlayer.bodyFrame;
                        int k2 = k;
                        bodyFrame.X += k2;
                        bodyFrame.Width -= k2;
                        if (info.drawPlayer.direction == -1)
                        {
                            k2 = 0;
                        }
                        if (!info.drawPlayer.invis)
                        {
                            DrawData drawData = new DrawData(texture, new Vector2((int)(info.position.X - Main.screenPosition.X - (info.drawPlayer.bodyFrame.Width / 2) + (info.drawPlayer.width / 2) + k2), ((int)(info.position.Y - Main.screenPosition.Y + info.drawPlayer.height - info.drawPlayer.bodyFrame.Height + 4))) + info.drawPlayer.bodyPosition + new Vector2(info.drawPlayer.bodyFrame.Width / 2, info.drawPlayer.bodyFrame.Height / 2), bodyFrame, info.bodyGlowMaskColor, info.drawPlayer.bodyRotation, info.bodyOrigin, 1f, info.spriteEffects, 0);
                            drawData.shader = info.bodyArmorShader;
                            Main.playerDrawData.Add(drawData);
                        }
                    }
                    return;
                case EquipType.Legs:
                    {
                        if (info.drawPlayer.shoe != 15 || info.drawPlayer.wearsRobe)
                        {
                            if (!info.drawPlayer.invis)
                            {
                                DrawData drawData = new DrawData(texture, new Vector2((int)(info.position.X - Main.screenPosition.X - (info.drawPlayer.legFrame.Width / 2) + (info.drawPlayer.width / 2)), (int)(info.position.Y - Main.screenPosition.Y + info.drawPlayer.height - info.drawPlayer.legFrame.Height + 4)) + info.drawPlayer.legPosition + info.legOrigin, info.drawPlayer.legFrame, info.legGlowMaskColor, info.drawPlayer.legRotation, info.legOrigin, 1f, info.spriteEffects, 0);
                                drawData.shader = info.legArmorShader;
                                Main.playerDrawData.Add(drawData);
                            }
                        }
                    }
                    return;
            }
        }
        public static void DrawItemGlowMask(Texture2D texture, PlayerDrawInfo info)
        {
            Item item = info.drawPlayer.HeldItem;
            if (info.shadow != 0f || info.drawPlayer.frozen || ((info.drawPlayer.itemAnimation <= 0 || item.useStyle == 0) && (item.holdStyle <= 0 || info.drawPlayer.pulley)) || info.drawPlayer.dead || item.noUseGraphic || (info.drawPlayer.wet && item.noWet))
            {
                return;
            }
            Vector2 offset = new Vector2();
            float rotOffset = 0;
            Vector2 origin = new Vector2();
            if (item.useStyle == 5)
            {
                if (Item.staff[item.type])
                {
                    rotOffset = 0.785f * info.drawPlayer.direction;
                    if (info.drawPlayer.gravDir == -1f) { rotOffset -= 1.57f * info.drawPlayer.direction; }
                    origin = new Vector2(texture.Width * 0.5f * (1 - info.drawPlayer.direction), (info.drawPlayer.gravDir == -1f) ? 0 : texture.Height);
                    int x = -(int)origin.X;
                    ItemLoader.HoldoutOrigin(info.drawPlayer, ref origin);
                    offset = new Vector2(origin.X + x, 0);
                }
                else
                {
                    offset = new Vector2(10, texture.Height / 2);
                    ItemLoader.HoldoutOffset(info.drawPlayer.gravDir, item.type, ref offset);
                    origin = new Vector2(-offset.X, texture.Height / 2);
                    if (info.drawPlayer.direction == -1)
                        origin.X = texture.Width + offset.X;
                    offset = new Vector2(texture.Width / 2, offset.Y);
                }
            }
            else
            {
                origin = new Vector2(texture.Width * 0.5f * (1 - info.drawPlayer.direction), (info.drawPlayer.gravDir == -1f) ? 0 : texture.Height);
            }
            Main.playerDrawData.Add
            (
                new DrawData
                (
                    texture,
                    info.itemLocation - Main.screenPosition + offset,
                    texture.Bounds,
                    new Color(250, 250, 250, item.alpha),
                    info.drawPlayer.itemRotation + rotOffset,
                    origin,
                    item.scale, info.spriteEffects, 0
                )
            );
        }
        public static void DrawItemGlowMaskWorld(SpriteBatch spriteBatch, Item item, Texture2D texture, float rotation, float scale)
        {
            Main.spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width / 2,
                    item.position.Y - Main.screenPosition.Y + item.height - (texture.Height / 2) + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                new Color(250, 250, 250, item.alpha), rotation,
                new Vector2(texture.Width / 2, texture.Height / 2),
                scale, SpriteEffects.None, 0f
            );
        }
        /*public static void DrawProjectileGlowMaskWorld(SpriteBatch spriteBatch, Projectile projectile, Texture2D texture, float rotation, float scale)
        {
            Main.spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    projectile.position.X - Main.screenPosition.X + projectile.width / 2,
                    projectile.position.Y - Main.screenPosition.Y + projectile.height - (texture.Height / 2) + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                new Color(250, 250, 250, projectile.alpha), rotation,
                new Vector2(texture.Width / 2, texture.Height / 2),
                scale, SpriteEffects.None, 0f
            );
        }
        public static void DrawNPCGlowMask(SpriteBatch spriteBatch, Texture2D texture, NPC npc, Color color, float rotation, float scale)
        {
            if (texture == null || texture.IsDisposed) return;
            SpriteEffects effects = npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Vector2 origin = new Vector2((float)(texture.Width / 2), (float)(texture.Height / Main.npcFrameCount[npc.type] / 2));
            Vector2 position = npc.Center - Main.screenPosition;
            Main.spriteBatch.Draw
            (
                texture,
                position,
                new Rectangle?(npc.frame),
                Color.White,
                rotation,
                origin,
                scale, effects, 0f
            );
        }*/
        #endregion
    }
}