using System;
using System.Drawing;
using System.Windows.Forms;

namespace Genius
{
    public partial class Ajuda : UserControl
    {
        public Ajuda()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint, true);

            Size = new Size(410, 410);

            Cursor = Cursors.Default;

            BackgroundImage = Path.BackgroundAjuda;

            LBLAjuda = new Label()
            {
                Name = "LBLAjuda",
                AutoSize = true,
                Location = new Point(20, 100),
                Text = "                AJUDA" + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                       "F1 - Comandos" + Environment.NewLine +
                       "F2 - Sobre" + Environment.NewLine +
                       "ESC - Sair",
                Font = new Font("Tahoma", 18.25F, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };

            Controls.Add(LBLAjuda);

            KeyDown += new KeyEventHandler(Ajuda_KeyDown);
        }

        private void Ajuda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Window.InstanciarView(this, MenuList.Genius); }
        }

        private readonly Label LBLAjuda = null;
        private readonly Path Path = new Path();
    }
}
