using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace CleyeraMeme
{
    public class CleyeraMemeWorld : ModWorld
    {
        public static bool downedTheCharacter = false;
        public static bool downedTadokoro = false;
        public static bool downedSpoo = false;

        public override void Initialize()
        {
            downedTheCharacter = false;
            downedTadokoro = false;
            downedSpoo = false;
        }
        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound();
            tag["downedTheCharacter"] = downedTheCharacter;
            tag["downedTadokoro"] = downedTadokoro;
            tag["downedSpoo"] = downedSpoo;
            return tag;
        }
        public override void Load(TagCompound tag)
        {
            downedTheCharacter = tag.GetBool("downedTheCharacter");
            downedTadokoro = tag.GetBool("downedTadokoro");
            downedSpoo = tag.GetBool("downedSpoo");
        }
    }
}