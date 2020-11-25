using System;
using System.Drawing;
using System.Windows.Forms;

namespace Genius
{
    public partial class Manual : UserControl
    {
        public Manual()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint, true);

            Size = new Size(410, 410);

            Cursor = Cursors.Default;
            
            BackgroundImage = Path.BackgroundManual;

            LBLManual = new Label()
            {
                Name = "LBLManual",
                AutoSize = true,
                Location = new Point(20, 100),
                Text = "                                    MANUAL DE INSTRUÇÕES" + Environment.NewLine + Environment.NewLine+ Environment.NewLine +
                       "OBJETIVO:" + Environment.NewLine + Environment.NewLine +
                       "1 - Aperte o botão de partida." + Environment.NewLine +
                       "2 - O Genius vai dar apenas o primeiro sinal." + Environment.NewLine +
                       "3 - O jogo começou: repita o sinal, clicando a mesma cor." + Environment.NewLine +
                       "4 - O jogo repetirá o primeiro sinal e vai acrescentar mais um." + Environment.NewLine +
                       "5 - Continue desta forma, enquanto você conseguir repetir cada sequência" + Environment.NewLine +
                       "    de sinais corretamente." + Environment.NewLine +
                       "6 - Se você não repetir alguma sequência corretamente ou demorar para" + Environment.NewLine + 
                       "    repetir um sinal, o jogo responderá com um som grave." + Environment.NewLine + 
                       "7 - É o sinal da derrota: você perdeu o jogo e a sequência de sinal acabou." + Environment.NewLine,
                Font = new Font("Tahoma", 8.25F, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };

            Controls.Add(LBLManual);
        }

        private readonly Label LBLManual = null;
        private readonly Path Path = new Path();
    }
}
