using Terraria.ModLoader;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;

namespace CleyeraMeme
{
	class CleyeraMeme : Mod
	{
        internal static CleyeraMeme Instance;
        public CleyeraMeme()
		{
            Instance = this;
        }
        public override void Load()
        {
            if (!Main.dedServ)
            {
                // Add certain equip textures
                //AddEquipTexture(null, EquipType.Legs, "IndignationistRobe_Legs", "SinsMod/Items/Armor/Vanity/");
            }
        }
        public override void Unload()
        {
            Instance = null;
        }
        public override void PostSetupContent()
        {
            Mod bossList = ModLoader.GetMod("BossChecklist");
            if (bossList != null)
            {
                //SlimeKing = 1f;
                //EyeOfCthulhu = 2f;
                //EaterOfWorlds = 3f;
                //QueenBee = 4f;
                //Skeletron = 5f;
                //WallOfFlesh = 6f;
                //TheTwins = 7f;
                //TheDestroyer = 8f;
                //SkeletronPrime = 9f;
                //Plantera = 10f;
                //Golem = 11f;
                //DukeFishron = 12f;
                //LunaticCultist = 13f;
                //Moonlord = 14f;
                //bossList.Call("AddBossWithInfo", "'Ultimate'The Charecter", 14.58f, (Func<bool>)(() => CleyeraMemeWorld.downedTheCharacter), string.Format("Use a [i:{0}] and defeat Characters", ItemType("")));
                //bossList.Call("AddBossWithInfo", "Tadokoron Prime", 14.56f, (Func<bool>)(() => CleyeraMemeWorld.downedTadokoro), string.Format("Use a [i:{0}] at night", ItemType("")));
                //bossList.Call("AddBossWithInfo", "Spoo", 14.57f, (Func<bool>)(() => CleyeraMemeWorld.downedSpoo), string.Format("Use a [i:{0}]", ItemType("EvilYellowPaint")));
            }
        }
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
            {
                return;
            }
            if (Main.musicVolume != 0f && Main.myPlayer != -1 && !Main.gameMenu && Main.LocalPlayer.active)
            {
                if (Main.LocalPlayer.head == GetEquipSlot("OrgaMask", EquipType.Head) && Main.LocalPlayer.dead)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/フリージア");
                    priority = MusicPriority.BossHigh;
                    return;
                }
            }
        }
        public override void AddRecipes()
        {
            /*
            ModRecipe recipe = new ModRecipe(this);
            recipe = new ModRecipe(this);
            recipe.AddIngredient(素材のアイテムID, 個数);
            recipe.AddIngredient(素材（二種類以上素材を指定する場合はrecipe.AddIngredientを増やします）のアイテムID, 個数);
            recipe.AddTile(クラフトに使う作業場のタイルID);
            recipe.SetResult(このレシピで作成するアイテムのアイテムID);
            recipe.AddRecipe();
             */
        }
    }
}