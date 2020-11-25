using System;

namespace Genius
{
    public class Sound
    {
        public Sound() { }

        public void Abrir(Sfx sons = Sfx.Nenhum)
        {
            //Use esse para reproduzir um arquivo wav
            WinApi.MciSendString("close myaudio", "", 0, IntPtr.Zero);
            WinApi.MciSendString(string.Concat("open ", Caminho.Audios, sons, ".wav", " alias myaudio"), "", 0, IntPtr.Zero);
            WinApi.MciSendString("set myaudio time format ms", "", 0, IntPtr.Zero);
            WinApi.MciSendString("status myaudio length", new string(Convert.ToChar(" "), 128), 128, IntPtr.Zero);

            Reproduzir(sons);
        }
        public void Fechar()
        {
            WinApi.MciSendString("close myaudio", "", 0, IntPtr.Zero);
        }
        public void IniciarEm(int ms)
        {
            WinApi.MciSendString(string.Concat("play myaudio from ", Convert.ToString(ms)), "", 0, IntPtr.Zero);
        }
        public void Reproduzir(Sfx sons = Sfx.Nenhum)
        {
            Console.Beep((int)sons, 200);
            
            //Use esse para reproduzir um arquivo wav
            //WinApi.MciSendString("play myaudio", "", 0, IntPtr.Zero);
        }

        private readonly Path Caminho = new Path();
    }
}
