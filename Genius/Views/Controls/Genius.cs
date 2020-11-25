using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Genius
{
    public partial class Genius : UserControl
    {
        public Genius()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint, true);

            Size = new Size(410, 410);

            Cursor = Cursors.Default;

            CarregarImagens(StateGame.Jogar); ;
        }

        public void CarregarImagens(StateGame stateGame)
        {           

            #region PIC_Cores
            PICVerde = new PictureBox()
            {
                Name = "PICVerde",
                Size = new Size(195, 195),
                Location = new Point(5, 5),
                BackgroundImage = Path.Verde_NotPressioned
            };

            PICVermelho = new PictureBox()
            {
                Name = "PICVermelho",
                Size = new Size(195, 195),
                Location = new Point(210, 5),
                BackgroundImage = Path.Vermelho_NotPressioned
            };

            PICAmarelo = new PictureBox()
            {
                Name = "PICAmarelo",
                Size = new Size(195, 195),
                Location = new Point(5, 210),
                BackgroundImage = Path.Amarelo_NotPressioned
            };

            PICAzul = new PictureBox()
            {
                Name = "PICAzul",
                Size = new Size(195, 195),
                Location = new Point(210, 210),
                BackgroundImage = Path.Azul_NotPressioned
            };
            #endregion PIC_Cores

            BTNSair = new Button()
            {
                Name = "BTNSair",
                AutoSize = true,
                Location = new Point(220, 178),
                Text = "ESC - Sair",
                Font = new Font("Arial", 8.25F, FontStyle.Regular),
                ForeColor = Color.White
            };

            BTNAjuda = new Button()
            {
                Name = "BTNAjuda",
                AutoSize = true,
                Location = new Point(120, 178),
                Text = "F1 - Ajuda",
                Font = new Font("Arial", 8.25F, FontStyle.Regular),
                ForeColor = Color.White
            };

            LBLAcertos = new Label()
            {
                Name = "LBLAcertos",
                AutoSize = true,
                Location = new Point(145, 210),
                Text = "ACERTOS",
                Font = new Font(Fontes.Fonte(FontType.LiquidCrystal_Normal), 17.25F, FontStyle.Bold),
                ForeColor = Color.Red,
                Visible = false
            };

            LBLPlacar = new Label()
            {
                Name = "LBLPlacar",
                Size = new Size(70, 23),
                Location = new Point(172, 248),
                Text = "00",
                Font = new Font(Fontes.Fonte(FontType.LiquidCrystal_Normal), 17.25F, FontStyle.Regular),
                ForeColor = Color.Red,
                Visible = false
            };

            Controls.Add(PICVerde);
            Controls.Add(PICVermelho);
            Controls.Add(PICAmarelo);
            Controls.Add(PICAzul);
            Controls.Add(BTNSair);
            Controls.Add(BTNAjuda);
            Controls.Add(LBLAcertos);
            Controls.Add(LBLPlacar);

            foreach (Control control in Controls)
            {
                if (control is Button)
                {
                    (control as Button).TextAlign = ContentAlignment.MiddleCenter;
                    (control as Button).FlatAppearance.BorderSize = 0;
                    (control as Button).FlatAppearance.MouseOverBackColor = Color.Transparent;
                    (control as Button).FlatAppearance.MouseDownBackColor = Color.Transparent;
                    (control as Button).MouseEnter += new EventHandler(BTN_MouseEnter);
                    (control as Button).MouseLeave += new EventHandler(BTN_MouseLeave);
                    (control as Button).Click += new EventHandler(BTN_Click);
                    (control as Button).FlatStyle = FlatStyle.Flat;
                    (control as Button).Cursor = Cursors.Hand;
                }
                else if (control is Label)
                {
                    (control as Label).TextAlign = ContentAlignment.MiddleCenter;
                    (control as Label).FlatStyle = FlatStyle.Flat;
                    (control as Label).Cursor = Cursors.Default;
                }
                else if (control is PictureBox)
                {
                    (control as PictureBox).Cursor = Cursors.Hand;
                    (control as PictureBox).BorderStyle = BorderStyle.None;
                    (control as PictureBox).Click += new EventHandler(PIC_Click);
                }
                control.KeyDown += new KeyEventHandler(Genius_KeyDown);
                control.BringToFront();
            }

            switch (stateGame)
            {
                case StateGame.Jogar: BackgroundImage = Path.BackgroundJogar; break;
                case StateGame.Jogando: BackgroundImage = Path.BackgroundAcertos; break;
                default: break;
            }
        }

        private void BTN_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = Color.Yellow;
        }
        private void BTN_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = Color.White;
        }

        private void BTN_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Name == BTNAjuda.Name) { Window.InstanciarView(this, MenuList.Ajuda); }
            if ((sender as Button).Name == BTNSair.Name) { Window.InstanciarView(this, MenuList.Sair); }
        }

        private void Genius_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Window.InstanciarView(this, MenuList.Sair); }
            if (e.KeyCode == Keys.F1) { Window.InstanciarView(this, MenuList.Ajuda) ; }
        }

        private void PIC_Click(object sender, EventArgs e)
        {
            AcionaCor((PictureBox)sender);
        }

        public void AcionaCor(PictureBox sender)
        {
            if (sender.Name.Equals("PICVermelho"))
            {
                sender.Image = Path.Vermelho_Pressioned;
                Audio.Abrir(Sfx.Vermelho);
                Tempo();
                sender.Image = Path.Vermelho_NotPressioned;
            }
            else if (sender.Name.Equals("PICVerde"))
            {
                sender.Image = Path.Verde_Pressioned;
                Audio.Abrir(Sfx.Verde);
                Tempo();
                sender.Image = Path.Verde_NotPressioned;
            }
            else if (sender.Name.Equals("PICAmarelo"))
            {
                sender.Image = Path.Amarelo_Pressioned;
                Audio.Abrir(Sfx.Amarelo);
                Tempo();
                sender.Image = Path.Amarelo_NotPressioned;
            }
            else if (sender.Name.Equals("PICAzul"))
            {
                sender.Image = Path.Azul_Pressioned;
                Audio.Abrir(Sfx.Azul);
                Tempo();
                sender.Image = Path.Azul_NotPressioned;
            }
            void Tempo()
            {
                Application.DoEvents();
                Thread.Sleep(300);
            }
        }

        private readonly Path Path = new Path();
        private readonly Sound Audio = new Sound();
        private readonly Fontes Fontes = new Fontes();

        private Button BTNSair = null;
        private Button BTNAjuda = null;
        private Label LBLAcertos = null;
        private Label LBLPlacar = null;

        private PictureBox PICVerde = null;
        private PictureBox PICVermelho = null;
        private PictureBox PICAmarelo = null;
        private PictureBox PICAzul = null;
    }
}
