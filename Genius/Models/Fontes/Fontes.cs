using System.Drawing;
using System.Drawing.Text;
using System.Linq;

namespace Genius
{
    public class Fontes
    {
        public FontFamily Fonte(FontType fontType)
        {
            var pfc = new PrivateFontCollection();

            switch (fontType)
            {
                case FontType.LiquidCrystal_Normal: pfc.AddFontFile(PathFontes.LiquidCrystal_Normal); break;
                case FontType.Tahoma: return new FontFamily("Tahoma");
                default: return new FontFamily("Arial");
            }

            return new FontFamily(pfc.Families.First().Name, pfc);
        }

        private readonly Path.PathFontes PathFontes = new Path.PathFontes();
    }
}
