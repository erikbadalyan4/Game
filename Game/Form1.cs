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
        int Time = 0;//Время в миллисекундах
        bool Moving = false;
        List<Enemy> Enemies = new List<Enemy>();
        bool PlayerAttackStart = false;//Когда начинается аттака персонажа, переменная становится true
        bool PlayerDeathStart = false;//Когда начинается анимация смерти персонажа, переменная становится true
        int AttackIndex = 0;//Номер спрайта атаки, всего их шесть
        int DeathIndex = 0;//Номер спрайта смерти, всего их 5
        bool APress, WPress, SPress,DPress;//Переменные для обработки одновременно нажатия клавиш
        bool TwoKey;//Если нажаты две и более клавиш то true
        Player Player = new Warrior();
        Bitmap PlayerSprite = Properties.Resources.wstanright;
        Bitmap AttackSprite;
        Bitmap Shadow = new Bitmap(Properties.Resources.BShadow,70,80);
        Bitmap Health = new Bitmap(Properties.Resources.healthpng,80,40);
        int XShadow = 0;// При движении в левую стророну тень смещалась немного вперед, для это нужна эта переменная
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResizeMap();
            TickRate.Start();
            Enemies.Add(new Bird(-MainPB.Left + (this.Width / 2 - PlayerSprite.Width / 2)-100, -MainPB.Top + (this.Height / 2 - PlayerSprite.Height / 2) - 20-150));
            //Enemies.Add(new Bird(-MainPB.Left + (this.Width / 2 - PlayerSprite.Width / 2) +100, -MainPB.Top + (this.Height / 2 - PlayerSprite.Height / 2) - 20 + 150));

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
            if (!PlayerDeathStart) 
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        if (MainPB.Top < 320)
                        {
                            if (APress && MainPB.Left < 577)
                            {
                                MainPB.Top += Player.Speed - 1;
                                MainPB.Left += Player.Speed - 1;
                            }
                            else if (DPress && MainPB.Left > -2075)
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
                            if (APress && MainPB.Left < 577)
                            {
                                MainPB.Top -= Player.Speed - 1;
                                MainPB.Left += Player.Speed - 1;
                            }
                            else if (DPress && MainPB.Left > -2075)
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
                            if (WPress && MainPB.Top < 320)
                            {
                                MainPB.Top += Player.Speed - 1;
                                MainPB.Left += Player.Speed - 1;
                            }
                            else if (SPress && MainPB.Top > -2323)
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
                            if (WPress && MainPB.Top < 320)
                            {
                                MainPB.Top += Player.Speed - 1;
                                MainPB.Left -= Player.Speed - 1;
                            }
                            else if (SPress && MainPB.Top > -2323)
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
            }
            
            MainPB.Invalidate();
            
        }

        private void TickRate_Tick(object sender, EventArgs e)
        {
            MainPB.Invalidate();
            Time += TickRate.Interval;
            if (Time % Player.AttackInterval == 0) 
            {
                PlayerAttackTimer.Start();
                AttackIndex = 0;
            }
            if (Player.Health <= 0&&!PlayerDeathStart) 
            {
                if (XShadow == 0)
                {
                    Player.DeathR();
                }
                else
                {
                    Player.DeathL();
                }
                PlayerDeathTimer.Start();
                DeathIndex = 0;
            }
            foreach (Enemy enemy in Enemies) 
            {
                if (Time % 20 == 0) 
                {
                    enemy.CalculateVector(Player);
                    enemy.NextStep();
                    if (Time % 160 == 0) 
                    {
                        if (enemy.Step.X > 0)
                        {
                            enemy.MoveRight();
                        }
                        else 
                        {
                            enemy.MoveLeft();
                        }
                    }
                    if (Time % 40 == 0) 
                    {
                        enemy.EnemySprite = new Bitmap(enemy.Sprites.Dequeue());
                        enemy.Sprites.Enqueue(enemy.EnemySprite);
                    }
                    Rectangle NewHitbox = new Rectangle(enemy.HitBox.X + enemy.Step.X, enemy.HitBox.Y + enemy.Step.Y, enemy.EnemySprite.Width, enemy.EnemySprite.Height);
                    bool notCross = true;
                    foreach (Enemy newen in Enemies) // Это делается для того, чтобы если будет близко находится несколько врагов, их текстуры не сливались
                    {
                        if (enemy != newen &&(Math.Abs(NewHitbox.X-newen.HitBox.X)<10 && Math.Abs(NewHitbox.Y - newen.HitBox.Y)<10))
                        {
                            notCross = false;
                        }
                    }
                    if (notCross) enemy.HitBox = NewHitbox;
                }
                if (Player.HitBox.IntersectsWith(new Rectangle(enemy.HitBox.X,enemy.HitBox.Y,enemy.HitBox.Width - 50,enemy.HitBox.Height-30)) &&(Time-enemy.AttackTime>=1000)) 
                {
                    Player.Health -= enemy.Damage;
                    enemy.AttackTime = Time;
                } 
            }
            StatusLabel.Text = "X: " + MainPB.Left + "  Y: " + MainPB.Top + "Time: " + Time;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TickRate.Stop();
        }

        private void PlayerAttackTimer_Tick(object sender, EventArgs e)
        {
            if (AttackIndex < 30)//30 чтобы анимация 5 раз повторилась
            {
                PlayerAttackStart = true;
                foreach (Enemy enemy in Enemies) 
                {
                    if (Player.AttackHitBox.IntersectsWith(enemy.HitBox)) 
                    {
                        enemy.Health -= Player.Damage;
                    }
                }
                AttackSprite = new Bitmap(Player.AttackSprite.Dequeue());
                Player.AttackSprite.Enqueue(AttackSprite);
                AttackIndex++;
            }
            else 
            {
                PlayerAttackTimer.Stop();
                PlayerAttackStart = false;
            }
            
        }

        private void PlayerDeathTimer_Tick(object sender, EventArgs e)
        {
            if (DeathIndex < 5)
            {
                PlayerDeathStart = true;
                PlayerSprite = new Bitmap(Player.Sprites.Dequeue());
                Player.Sprites.Enqueue(PlayerSprite);
                DeathIndex++;
            }
            else 
            {
                PlayerDeathTimer.Stop();
                
            }
        }

        private void MainPB_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //Отрисовка персонажа 
            Player.HitBox = new Rectangle(-MainPB.Left + (this.Width / 2 - PlayerSprite.Width / 2), -MainPB.Top + (this.Height / 2 - PlayerSprite.Height / 2) - 20,PlayerSprite.Width, PlayerSprite.Height);

            if (PlayerAttackStart)
            {
                Player.AttackHitBox = new Rectangle(Player.HitBox.X - 50 + XShadow, Player.HitBox.Y, 150, 75);
                g.DrawImage(AttackSprite, Player.HitBox.X - 50 + XShadow, Player.HitBox.Y );
            }
            g.DrawImage(Shadow, Player.HitBox.X-15+XShadow, Player.HitBox.Y-6);
            g.DrawImage(PlayerSprite,Player.HitBox.X,Player.HitBox.Y);
            //Отрисовка врагов
            foreach (Enemy enemy in Enemies) 
            {
                g.DrawImage(new Bitmap(Shadow,90,100), enemy.HitBox.X - 15 + XShadow, enemy.HitBox.Y - 6);
                g.DrawImage(enemy.EnemySprite, enemy.HitBox.X, enemy.HitBox.Y);
                g.DrawRectangle(Pens.Black, enemy.HitBox.X, enemy.HitBox.Y-5,enemy.HitBox.Width-5,5);
                g.FillRectangle(Brushes.Red, enemy.HitBox.X+1, enemy.HitBox.Y - 4, (float)(((enemy.HitBox.Width - 5)/enemy.MaxHealth)*enemy.Health), 4);
            }
            //Отрисовка Hud
            g.DrawImage(Health, Player.HitBox.X - 572, Player.HitBox.Y - 300);
            g.DrawString(Convert.ToString(Player.Health) + "/" + Convert.ToString(Player.MaxHealth), new Font("Copperplate Gothic Bold", 14),Brushes.White, Player.HitBox.X - 572+Health.Width, Player.HitBox.Y - 290);
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!PlayerDeathStart) 
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
                        if ((WPress || SPress) && !TwoKey)
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
