using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Game
{
    public partial class Form1 : Form
    {
        int Time = 0;//Время в миллисекундах
        bool Moving = false;
        List<Enemy> Enemies = new List<Enemy>();
        bool PlayerAttackStart = false;//Когда начинается аттака персонажа, переменная становится true
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
        double LevelExp = 100;//Сколько опыта надо получить для следующего уроня, с каждым уровнем значение увеличивается
        Stopwatch Stopwatch = new Stopwatch();
        int Transparent = 0;
        int PauseTransparent;
        int Minutes;
        int Seconds;
        public Form1()
        {
            InitializeComponent();
        }
        public void StartGame() 
        {
            playButton.Visible = false;
            deathLabel.Visible = false;
            MainPB.Visible = true;
            panel1.Location = new Point(409, 132);
            BackPB.Image = Properties.Resources.treesback;
            ResizeMap();
            Time = 0;
            Player = new Warrior();
            Stopwatch.Start();
            TickRate.Start();
            //Enemies.Add(new Bird(-MainPB.Left + (this.Width / 2 - PlayerSprite.Width / 2) - 100, -MainPB.Top + (this.Height / 2 - PlayerSprite.Height / 2) - 20 - 150));
            //Enemies.Add(new Slime(-MainPB.Left + (this.Width / 2 - PlayerSprite.Width / 2) +100, -MainPB.Top + (this.Height / 2 - PlayerSprite.Height / 2) - 20 + 150));
        }
        public void StopGame() 
        {
            TickRate.Stop();
            Stopwatch.Stop();
            Moving = false;
            TwoKey = false;
            APress = false;
            WPress = false;
            SPress = false;
            DPress = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            MainPB.Visible = false;
            deathLabel.Visible = false;
            ScoreLabel.Visible = false;
            ScoreNum.Visible = false;
            TimeLabel.Visible = false;
            TimeNum.Visible = false;
            LevelLabel.Visible = false;
            LevelNum.Visible = false;
            exitButton.Visible = false;
            playButton.Location = new Point(471, 288);
            BackPB.Dock = DockStyle.Fill;
            BackPB.SendToBack();
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
            if (TickRate.Enabled) 
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
                MainPB.Invalidate();
            }
            if (e.KeyCode == Keys.Escape && !playButton.Visible) 
            {
                if (TickRate.Enabled)
                {
                    StopGame();
                    pauseTimer.Start();
                    
                }
                else 
                {
                    TickRate.Start();
                    Stopwatch.Start();
                    pauseTimer.Stop();
                    PauseTransparent = 0;
                    
                }
                    
            }
        }

        private void TickRate_Tick(object sender, EventArgs e)
        {
            MainPB.Invalidate();
            BackPB.Invalidate();
            Time += TickRate.Interval;
            if (Time % Player.AttackInterval == 0) 
            {
                PlayerAttackTimer.Start();
                AttackIndex = 0;
            }
            if (Player.Health <= 0&&!PlayerDeathTimer.Enabled) 
            {
                DeathIndex = 0;
                if (XShadow == 0)
                {
                    Player.DeathR();
                }
                else
                {
                    Player.DeathL();
                }
                TickRate.Stop();
                PlayerDeathTimer.Start(); 
            }
            if (Player.Health > 0 && Time % 660 == 0) 
            {
                if (Player.Health + Player.Regen < Player.MaxHealth) Player.Health += Player.Regen;
                else Player.Health = Player.MaxHealth;
            }
            if (Time % 10000 == 0 && Enemies.Count<16)
            {
                Random rand = new Random();
                int numberMob = rand.Next(1, 3);//Всего прописано два моба, будет создаваться на рандом моб:1-птица,2-слизень
                int RightOrLeft = rand.Next(1, 3);//1-будем генерировать моба справа, 2 - слева
                int TopOrBottom = rand.Next(1, 3);//1-будем генерировать сверху, 2 - снизу
                int X, Y;
                if (RightOrLeft == 1)
                {
                    X = Player.HitBox.X - rand.Next(610, 650);
                }
                else
                {
                    X = Player.HitBox.X + rand.Next(610, 650);
                }
                if (TopOrBottom == 1)
                {
                    Y = Player.HitBox.Y - rand.Next(360, 400);
                }
                else
                {
                    Y = Player.HitBox.Y + rand.Next(360, 400);
                }
                if (numberMob == 1)
                {
                    Enemies.Add(new Bird(X, Y));
                }
                else if (numberMob == 2)
                {
                    Enemies.Add(new Slime(X, Y));
                }
            }
            foreach (Enemy enemy in Enemies) 
            {
                
                if (PlayerDeathTimer.Enabled && enemy.Damage!=0)
                {
                    if (enemy.Step.X > 0)
                    {
                        enemy.StayR();
                    }
                    else
                    {
                        enemy.StayL();
                    }
                }
                if (enemy.Health <= 0 && enemy.Damage != 0) 
                {
                    if (enemy.Step.X > 0)
                    {
                        enemy.DeathR();
                    }
                    else
                    {
                        enemy.DeathL();
                    }
                    Player.Experience += enemy.Experience;
                    Player.MaxExperience += enemy.Experience;
                    enemy.DeathTime = Time;
                }
                if (Time % 40 == 0)
                {
                    enemy.CalculateVector(Player);
                    enemy.NextStep();
                    if (Time % 320 == 0 && enemy.Damage != 0)//Проверяю дамаг, так как после прошлой проверки моб мог умереть
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
                    if (Time % 80 == 0&&enemy.DeathSpriteIndex!=4)
                    {
                        enemy.EnemySprite = new Bitmap(enemy.Sprites.Dequeue());
                        enemy.Sprites.Enqueue(enemy.EnemySprite);
                        if(enemy.Damage == 0) enemy.DeathSpriteIndex++;
                    }
                    Rectangle NewHitbox = new Rectangle(enemy.HitBox.X + enemy.Step.X, enemy.HitBox.Y + enemy.Step.Y, enemy.EnemySprite.Width, enemy.EnemySprite.Height);
                    bool notCross = true;
                        
                    foreach (Enemy newen in Enemies) // Это делается для того, чтобы если будет близко находится несколько врагов, их текстуры не сливались
                    {
                        if (enemy != newen && (Math.Abs(NewHitbox.X - newen.HitBox.X) < 7 && Math.Abs(NewHitbox.Y - newen.HitBox.Y) < 7)&&newen.Damage!=0)
                        {
                            notCross = false;
                            break;
                        }
                    }
                    if (notCross && enemy.Damage != 0) enemy.HitBox = NewHitbox;
                }
                if (Player.HitBox.IntersectsWith(new Rectangle(enemy.HitBox.X, enemy.HitBox.Y, enemy.HitBox.Width - 15, enemy.HitBox.Height-15)) && (Time - enemy.AttackTime >= 1000))
                {
                    if (Player.Health - enemy.Damage > 0) Player.Health -= enemy.Damage;
                    else Player.Health = 0;
                    enemy.AttackTime = Time;
                }
                if (enemy.Damage==0&&Time - enemy.DeathTime > 5000) 
                {
                    Random rand = new Random();
                    int RightOrLeft = rand.Next(1, 3);//1-будем генерировать моба справа, 2 - слева
                    int TopOrBottom = rand.Next(1, 3);//1-будем генерировать сверху, 2 - снизу
                    int X, Y;
                    if (RightOrLeft == 1)
                    {
                        X = Player.HitBox.X - rand.Next(610, 650);
                    }
                    else
                    {
                        X = Player.HitBox.X + rand.Next(610, 650);
                    }
                    if (TopOrBottom == 1)
                    {
                        Y = Player.HitBox.Y - rand.Next(360, 400);
                    }
                    else
                    {
                        Y = Player.HitBox.Y + rand.Next(360, 400);
                    }
                    enemy.Rebith(X,Y);
                }
                 
            }
            if (Player.Experience >= LevelExp) 
            {
                Player.Experience -= Convert.ToInt32(LevelExp);
                LevelExp =Convert.ToInt32(LevelExp* 1.2);
                Player.Level++;
                StopGame();
                if (Player.Level < 14)
                {
                    panel1.Visible = true;
                    
                }
                else 
                {
                    endGameTimer.Start();
                }
                pauseTimer.Start();
            }
            StatusLabel.Text = "X: " + MainPB.Left + "  Y: " + MainPB.Top + "Time: " + Time;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TickRate.Stop();
        }

        private void PlayerAttackTimer_Tick(object sender, EventArgs e)
        {
            if (AttackIndex < 30&&!PlayerDeathTimer.Enabled)//30 чтобы анимация 5 раз повторилась
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
                PlayerSprite = new Bitmap(Player.Sprites.Dequeue());
                Player.Sprites.Enqueue(PlayerSprite);
                DeathIndex++;
                MainPB.Invalidate();
            }
            else 
            {
                PlayerDeathTimer.Stop();
                Stopwatch.Stop();
                endGameTimer.Start();
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            
        }

        private void playButton_MouseDown(object sender, MouseEventArgs e)
        {
            playButton.BackgroundImage = Properties.Resources.playbutton2;
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (TickRate.Enabled) 
            {
                Graphics g = e.Graphics;
                g.DrawImage(Health, 6, 22);
                g.DrawString(Convert.ToString(Player.Health) + "/" + Convert.ToString(Player.MaxHealth), new Font("Copperplate Gothic Bold", 14), Brushes.White, 6+ Health.Width, 30);
            }
            
        }

        private void BackPB_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (!playButton.Visible) 
            {
                g.DrawImage(Health, 6, 22);
                g.DrawString(Convert.ToString(Player.Health) + "/" + Convert.ToString(Player.MaxHealth), new Font("Copperplate Gothic Bold", 14), Brushes.White, 6 + Health.Width, 30);
                g.DrawString("Level " + Convert.ToString(Player.Level), new Font("Copperplate Gothic Bold", 14), Brushes.White, 6, 65);
                if (Player.Level < 10)
                {
                    g.DrawRectangle(Pens.Black, 93, 67, 92, 16);
                    g.FillRectangle(Brushes.Green, 92, 67, (float)(92 / LevelExp * Player.Experience) - 1, 16 - 1);
                }
                else
                {
                    g.DrawRectangle(Pens.Black, 106, 67, 92, 16);
                    g.FillRectangle(Brushes.Green, 105, 67, (float)(92 / LevelExp * Player.Experience) - 1, 16 - 1);
                }
                g.DrawString("Time: " + Minutes + ":" + (Seconds).ToString("00"), new Font("Copperplate Gothic Bold", 14), Brushes.White, 6, 95);
            }
                
                

            
            if (endGameTimer.Enabled)
            {
                Color redSemiTransparentColor = Color.FromArgb(Transparent, 255, 0, 0);
                SolidBrush semiTransparentBrush = new SolidBrush(redSemiTransparentColor);
                g.FillRectangle(semiTransparentBrush, 0, 0, this.Width, this.Height);
            }
            if (pauseTimer.Enabled)
            {
                Color graySemiTransparentColor = Color.FromArgb(PauseTransparent, 64, 64, 64);
                SolidBrush semiTransparentBrush = new SolidBrush(graySemiTransparentColor);
                g.FillRectangle(semiTransparentBrush, 0, 0, this.Width, this.Height);
                g.DrawString("PAUSE", new Font("Copperplate Gothic Bold", 48), Brushes.White, 461,140);
            }
        }

        private void damageButton_Click(object sender, EventArgs e)
        {
            damageLabel.Text = (Convert.ToInt32(damageLabel.Text) + 1).ToString();
            if (damageLabel.Text == "3") 
            {
                damageButton.Visible = false;
                damageLabel.Size = new Size(76, 32);
                damageLabel.Text = "MAX";
            } 
            Player.Damage += 1;
            panel1.Visible = false;
            pauseTimer.Stop();
            TickRate.Start();
        }

        private void healthButton_Click(object sender, EventArgs e)
        {
            healthLabel.Text = (Convert.ToInt32(healthLabel.Text) + 1).ToString();
            if (healthLabel.Text == "3")
            {
                healthButton.Visible = false;
                healthLabel.Size = new Size(76, 32);
                healthLabel.Text = "MAX";
            }
            Player.MaxHealth += 50;
            panel1.Visible = false;
            pauseTimer.Stop();
            TickRate.Start();
        }

        private void speedButton_Click(object sender, EventArgs e)
        {
            speedLabel.Text = (Convert.ToInt32(speedLabel.Text) + 1).ToString();
            if (speedLabel.Text == "3")
            {
                speedButton.Visible = false;
                speedLabel.Size = new Size(76, 32);
                speedLabel.Text = "MAX";
            }
            Player.Speed += 1;
            panel1.Visible = false;
            pauseTimer.Stop();
            TickRate.Start();
        }

        private void regenButton_Click(object sender, EventArgs e)
        {
            regenLabel.Text = (Convert.ToInt32(regenLabel.Text) + 1).ToString();
            if (regenLabel.Text == "3")
            {
                regenButton.Visible = false;
                regenLabel.Size = new Size(76, 32);
                regenLabel.Text = "MAX";
            }
            Player.Regen += 5;
            panel1.Visible = false;
            pauseTimer.Stop();
            TickRate.Start();
        }

        private void endGameTimer_Tick(object sender, EventArgs e)
        {
            if (Transparent + 5 < 255) Transparent += 5;
            else 
            {
                Transparent = 255;
                
            }
            
            MainPB.Invalidate();
            BackPB.Invalidate();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pauseTimer_Tick(object sender, EventArgs e)
        {
            if (PauseTransparent + 5 < 128) PauseTransparent += 5;
            else
            {
                PauseTransparent = 128;

            }
            BackPB.Invalidate();
            MainPB.Invalidate();
        }

        private void playButton_MouseUp(object sender, MouseEventArgs e)
        {
            playButton.BackgroundImage = Properties.Resources.playbutton1;
            StartGame();
        }

        private void MainPB_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //Отрисовка персонажа 
            Player.HitBox = new Rectangle(-MainPB.Left + (this.Width / 2 - PlayerSprite.Width / 2), -MainPB.Top + (this.Height / 2 - PlayerSprite.Height / 2) - 20,Player.HitBox.Width, Player.HitBox.Height);

            if (PlayerAttackStart)
            {
                Player.AttackHitBox = new Rectangle(Player.HitBox.X - 50 + XShadow, Player.HitBox.Y, 150, 75);
                g.DrawImage(AttackSprite, Player.HitBox.X - 50 + XShadow, Player.HitBox.Y );
            }
            g.DrawImage(Shadow, Player.HitBox.X-15+XShadow, Player.HitBox.Y-6);
            foreach (Enemy enemy in Enemies) 
            {
                g.DrawImage(new Bitmap(Shadow, 90, 100), enemy.HitBox.X +enemy.Shadow.X, enemy.HitBox.Y +enemy.Shadow.Y);
            }
            g.DrawImage(PlayerSprite,Player.HitBox.X,Player.HitBox.Y);
            //Отрисовка врагов
            foreach (Enemy enemy in Enemies) 
            {
                g.DrawImage(enemy.EnemySprite, enemy.HitBox.X, enemy.HitBox.Y);
                g.DrawRectangle(Pens.Black, enemy.HitBox.X, enemy.HitBox.Y-5,enemy.HealthBoxWith,5);
                g.FillRectangle(Brushes.Red, enemy.HitBox.X+1, enemy.HitBox.Y - 4, (float)(((enemy.HealthBoxWith)/enemy.MaxHealth)*enemy.Health), 4);
            }
            //Отрисовка Hud
            g.DrawImage(Health, Player.HitBox.X - 572, Player.HitBox.Y - 300);
            g.DrawString(Convert.ToString(Player.Health) + "/" + Convert.ToString(Player.MaxHealth), new Font("Copperplate Gothic Bold", 14),Brushes.White, Player.HitBox.X - 572+Health.Width, Player.HitBox.Y - 290);
            g.DrawString("Level "+ Convert.ToString(Player.Level), new Font("Copperplate Gothic Bold", 14), Brushes.White, Player.HitBox.X - 572, Player.HitBox.Y - 255);
            if (Player.Level < 10)
            {
                g.DrawRectangle(Pens.Black, Player.HitBox.X - 485, Player.HitBox.Y - 253, 92, 16);
                g.FillRectangle(Brushes.Green, Player.HitBox.X - 484, Player.HitBox.Y - 252, (float)(92 / LevelExp * Player.Experience) - 1, 16 - 1);
            }
            else 
            {
                g.DrawRectangle(Pens.Black, Player.HitBox.X - 472, Player.HitBox.Y - 253, 92, 16);
                g.FillRectangle(Brushes.Green, Player.HitBox.X - 471, Player.HitBox.Y - 252, (float)(92 / LevelExp * Player.Experience) - 1, 16 - 1);
            }
            Minutes = (int)Stopwatch.Elapsed.TotalMinutes;
            Seconds = (int)(Stopwatch.Elapsed.TotalSeconds - 60 * (int)Stopwatch.Elapsed.TotalMinutes);
            g.DrawString("Time: " + Minutes + ":" + (Seconds).ToString("00"), new Font("Copperplate Gothic Bold", 14), Brushes.White, Player.HitBox.X - 572, Player.HitBox.Y - 225);
            if (endGameTimer.Enabled) 
            {
                Color redSemiTransparentColor = Color.FromArgb(Transparent, 255, 0, 0);
                SolidBrush semiTransparentBrush = new SolidBrush(redSemiTransparentColor);
                g.FillRectangle(semiTransparentBrush,Player.HitBox.X - 580, Player.HitBox.Y - 320,this.Width,this.Height);
                if (Transparent == 255) 
                {
                    if (!deathLabel.Visible)
                    {
                        this.BackgroundImage = null;
                        this.BackColor = Color.Red;
                        deathLabel.Visible = true;
                        if (Player.Level == 14)
                        {
                            deathLabel.Text = "GAME IS COMPLITED";
                        }
                        else 
                        {
                            deathLabel.Text = "YOU ARE DEAD";
                        }
                        ScoreLabel.Visible = true;
                        ScoreNum.Visible = true;
                        TimeLabel.Visible = true;
                        TimeNum.Visible = true;
                        LevelLabel.Visible = true;
                        LevelNum.Visible = true;
                        ScoreNum.Text = Player.MaxExperience.ToString();
                        TimeNum.Text = (int)Stopwatch.Elapsed.TotalMinutes + ":" + ((int)(Stopwatch.Elapsed.TotalSeconds - 60 * (int)Stopwatch.Elapsed.TotalMinutes)).ToString("00");
                        LevelNum.Text = Player.Level.ToString();
                        exitButton.Visible = true;
                    }

                }
            }
            if (pauseTimer.Enabled) 
            {
                Color graySemiTransparentColor = Color.FromArgb(PauseTransparent, 64,64,64);
                SolidBrush semiTransparentBrush = new SolidBrush(graySemiTransparentColor);
                g.FillRectangle(semiTransparentBrush, Player.HitBox.X - 580, Player.HitBox.Y - 320, this.Width, this.Height);
                if(!panel1.Visible) g.DrawString("PAUSE", new Font("Copperplate Gothic Bold", 48), Brushes.White, Player.HitBox.X - 117, Player.HitBox.Y - 180);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (TickRate.Enabled) 
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
}
