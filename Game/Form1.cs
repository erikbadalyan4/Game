using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        bool Moving = false;
        bool APress, WPress, SPress,DPress;//Переменные для обработки одновременно нажатия клавиш
        bool TwoKey;//Если нажаты две и более клавиш то true
        Player Player = new Warrior();
        Bitmap PlayerSprite = Properties.Resources.wstanright;
        Bitmap Shadow = new Bitmap(Properties.Resources.BShadow,70,80);
        int XShadow = 0;// При движении в левую стророну тень смещалась немного вперед, для это нужна эта переменная
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResizeMap();
            TickRate.Start();
        }
        private void ResizeMap()// метод для того чтобы карта корректно отображалась в picrurebox
        {
            Image ResizedImage = new Bitmap(MainPB.Image, 2700, 2700);
            MainPB.Image = ResizedImage;
            MainPB.Left = -749;
            MainPB.Top = -985;
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) 
            {
                case Keys.W:
                    if (MainPB.Top < 320)
                    {
                        if (APress)
                        {
                            MainPB.Top += Player.Speed - 1;
                            MainPB.Left += Player.Speed - 1;
                        }
                        else if (DPress)
                        {
                            MainPB.Top += Player.Speed - 1;
                            MainPB.Left -= Player.Speed - 1;
                        }
                        else 
                        {
                            MainPB.Top += Player.Speed;
                        }
                        
                    }
                    PlayerSprite = new Bitmap(Player.Sprites.Dequeue());
                    Player.Sprites.Enqueue(PlayerSprite);
                    break;
                case Keys.S:
                    if (MainPB.Top > -2323) 
                    {
                        if (APress)
                        {
                            MainPB.Top -= Player.Speed - 1;
                            MainPB.Left += Player.Speed - 1;
                        }
                        else if (DPress)
                        {
                            MainPB.Top -= Player.Speed - 1;
                            MainPB.Left -= Player.Speed - 1;
                        }
                        else
                        {
                            MainPB.Top -= Player.Speed;
                        }
                    }
                    PlayerSprite = new Bitmap(Player.Sprites.Dequeue());
                    Player.Sprites.Enqueue(PlayerSprite);
                    break;
                case Keys.A:
                    if (MainPB.Left < 577) 
                    {
                        if (WPress)
                        {
                            MainPB.Top += Player.Speed - 1;
                            MainPB.Left += Player.Speed - 1;
                        }
                        else if (SPress)
                        {
                            MainPB.Top -= Player.Speed - 1;
                            MainPB.Left += Player.Speed - 1;
                        }
                        else if (DPress) { }
                        else
                        {
                            MainPB.Left += Player.Speed;
                        } 
                    }
                    if (!DPress) 
                    {
                        PlayerSprite = new Bitmap(Player.Sprites.Dequeue());
                        Player.Sprites.Enqueue(PlayerSprite);
                    }
                    break;
                case Keys.D:
                    if (MainPB.Left > -2075)
                    {
                        if (WPress)
                        {
                            MainPB.Top += Player.Speed - 1;
                            MainPB.Left -= Player.Speed - 1;
                        }
                        else if (SPress)
                        {
                            MainPB.Top -= Player.Speed - 1;
                            MainPB.Left -= Player.Speed - 1;
                        }
                        else if (APress) { }
                        else
                        {
                            MainPB.Left -= Player.Speed;
                        }
                    }
                    if (!APress) 
                    {
                        PlayerSprite = new Bitmap(Player.Sprites.Dequeue());
                        Player.Sprites.Enqueue(PlayerSprite);
                    }
                    break;
            }
            MainPB.Invalidate();
            StatusLabel.Text = "X: " + MainPB.Left+"  Y: "+MainPB.Top;
        }

        private void TickRate_Tick(object sender, EventArgs e)
        {
            MainPB.Invalidate();
            
        }

        private void MainPB_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Player.HitBox = new Rectangle(-MainPB.Left + (this.Width / 2 - PlayerSprite.Width / 2), -MainPB.Top + (this.Height / 2 - PlayerSprite.Height / 2) - 20,PlayerSprite.Width, PlayerSprite.Height);

            g.DrawImage(Shadow, Player.HitBox.X-15+XShadow, Player.HitBox.Y-6);
            g.DrawImage(PlayerSprite,Player.HitBox.X,Player.HitBox.Y);
            MainPB.Invalidate();
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (!Moving)
                    {
                        Moving = true;
                        WPress = true;
                        if (XShadow == 0)
                        {
                            Player.MoveRight();
                        }
                        else
                        {
                            Player.MoveLeft();
                            XShadow = 12;
                        }
                    }

                    break;
                case Keys.S:
                    if (!Moving)
                    {
                        Moving = true;
                        SPress = true;
                        if (XShadow == 0)
                        {
                            Player.MoveRight();
                        }
                        else
                        {
                            Player.MoveLeft();
                            XShadow = 12;
                        }
                    }
                    break;
                case Keys.A:
                    APress = true;
                    if (!Moving)
                    {
                        Moving = true;
                        Player.MoveLeft();
                        XShadow = 12;
                    }
                    if ((WPress || SPress)&&!TwoKey) 
                    {
                        TwoKey = true;
                        Player.MoveLeft();
                        XShadow = 12;
                    }
                    break;
                case Keys.D:
                    DPress = true;
                    if (!Moving)
                    {
                        Moving = true;
                        Player.MoveRight();
                        XShadow = 0;
                    }
                    if ((WPress || SPress) && !TwoKey)
                    {
                        TwoKey = true;
                        Player.MoveRight();
                        XShadow = 0;
                    }
                    break;
            }
            MainPB.Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (Moving) 
            {
                Moving = false;
                if (XShadow == 0) 
                {
                    Player.StayR();
                }
                else 
                {
                    XShadow = 7;
                    Player.StayL();
                }
                PlayerSprite = new Bitmap(Player.Sprites.Dequeue());
                Player.Sprites.Enqueue(PlayerSprite);
            }
            switch (e.KeyCode) 
            {
                case Keys.W:
                    WPress = false;
                    TwoKey = false;
                    break;
                case Keys.S:
                    SPress = false;
                    TwoKey = false;
                    break;
                case Keys.A:
                    APress = false;
                    break;
                case Keys.D:
                    DPress = false;
                    break;
            }
        }

    }
}
