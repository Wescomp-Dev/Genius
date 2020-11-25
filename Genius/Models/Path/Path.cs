using System.Drawing;
using System.IO;

namespace Genius
{
    public class Path
    {
        ///<summary>Representa o caminho dos sprites</summary>
        public string Sprites { get => string.Concat(Directory.GetCurrentDirectory(), @"\Resources\Sprites\"); }
        public Image Vermelho_NotPressioned { get => Image.FromFile(string.Concat(Sprites, "Vermelho_NotPressioned.png")); }
        public Image Verde_NotPressioned { get => Image.FromFile(string.Concat(Sprites, "Verde_NotPressioned.png")); }
        public Image Azul_NotPressioned { get => Image.FromFile(string.Concat(Sprites, "Azul_NotPressioned.png")); }
        public Image Amarelo_NotPressioned { get => Image.FromFile(string.Concat(Sprites, "Amarelo_NotPressioned.png")); }
        public Image Vermelho_Pressioned { get => Image.FromFile(string.Concat(Sprites, "Vermelho_Pressioned.png")); }
        public Image Verde_Pressioned { get => Image.FromFile(string.Concat(Sprites, "Verde_Pressioned.png")); }
        public Image Azul_Pressioned { get => Image.FromFile(string.Concat(Sprites, "Azul_Pressioned.png")); }
        public Image Amarelo_Pressioned { get => Image.FromFile(string.Concat(Sprites, "Amarelo_Pressioned.png")); }

        ///<summary>Representa o caminho do HUD do menu</summary>
        public string HUD { get => string.Concat(Sprites, @"\HUD\"); }
        public Image BackgroundJogar { get => Image.FromFile(string.Concat(HUD, "BackgroundJogar.png")); }
        public Image BackgroundAcertos { get => Image.FromFile(string.Concat(HUD, "BackgroundAcertos.png")); }
        public Image BackgroundManual { get => Image.FromFile(string.Concat(HUD, "Background.png")); }
        public Image BackgroundAjuda { get => Image.FromFile(string.Concat(HUD, "Background.png")); }

        ///<summary>Representa o caminho dos áudios WAV</summary>
        public string Audios { get => string.Concat(Directory.GetCurrentDirectory(), @"\Resources\Audios\"); }

        public class PathFontes
        {
            ///<summary>Representa o caminho das fontes ttf/otf</summary>summary>
            public string Fontes { get => string.Concat(Directory.GetCurrentDirectory(), @"\Resources\Fontes\"); }
            public string LiquidCrystal_Normal { get => string.Concat(Fontes, @"LiquidCrystal-Normal.otf"); }

        }
    }
}
