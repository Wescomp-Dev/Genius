using System;
using System.Drawing;
using System.Windows.Forms;

namespace Genius
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint, true);

            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.None;
            Size = new Size(410, 410);

            InstanciarView(this, MenuList.Genius);
        }

        private void Window_Shown(object sender, EventArgs e)
        {
            Location = new Point((Screen.PrimaryScreen.Bounds.Width - Width) / 2, (Screen.PrimaryScreen.Bounds.Height - Height) / 2);
            Focus();
        }

        public static void InstanciarView(Control sender, MenuList menu)
        {
            var form = sender.FindForm(); form.Controls.Remove(sender);

            switch (menu)
            {
                case MenuList.Genius: { Instanciar(new Genius()); break; }                
                case MenuList.Ajuda: { Instanciar(new Ajuda()); break; }
                case MenuList.Manual: { Instanciar(new Manual()); break; }
                default: { Sair(); break; }
            }

            void Instanciar(UserControl mUserControl)
            {
                mUserControl.Location = new Point((form.Width - mUserControl.Width) / 2, (form.Height - mUserControl.Height) / 2);
                form.Controls.Add(mUserControl); mUserControl.Focus();
            }

            void Sair()
            {
                Application.Exit();
            }
        }
    }
}
