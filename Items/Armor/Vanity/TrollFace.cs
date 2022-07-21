using Terraria.ModLoader;

namespace CleyeraMeme.Items.Armor.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class TrollFace : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
		{
			item.width = 28;
			item.height = 20;
			item.rare = 1;
			item.vanity = true;
		}
		public override bool DrawHead()
		{
			return false;
		}
	}
}