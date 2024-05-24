namespace Game
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TickRate = new System.Windows.Forms.Timer(this.components);
            this.StatusLabel = new System.Windows.Forms.Label();
            this.PlayerAttackTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayerDeathTimer = new System.Windows.Forms.Timer(this.components);
            this.playButton = new System.Windows.Forms.Button();
            this.MainPB = new System.Windows.Forms.PictureBox();
            this.BackPB = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.regenButton = new System.Windows.Forms.Button();
            this.regenLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.speedButton = new System.Windows.Forms.Button();
            this.speedLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.healthButton = new System.Windows.Forms.Button();
            this.healthLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.damageButton = new System.Windows.Forms.Button();
            this.damageLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.endGameTimer = new System.Windows.Forms.Timer(this.components);
            this.deathLabel = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.ScoreNum = new System.Windows.Forms.Label();
            this.TimeNum = new System.Windows.Forms.Label();
            this.LevelNum = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.pauseTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackPB)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TickRate
            // 
            this.TickRate.Interval = 10;
            this.TickRate.Tick += new System.EventHandler(this.TickRate_Tick);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Location = new System.Drawing.Point(904, 9);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(266, 23);
            this.StatusLabel.TabIndex = 1;
            this.StatusLabel.Text = "label1";
            // 
            // PlayerAttackTimer
            // 
            this.PlayerAttackTimer.Interval = 40;
            this.PlayerAttackTimer.Tick += new System.EventHandler(this.PlayerAttackTimer_Tick);
            // 
            // PlayerDeathTimer
            // 
            this.PlayerDeathTimer.Tick += new System.EventHandler(this.PlayerDeathTimer_Tick);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Transparent;
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playButton.FlatAppearance.BorderSize = 0;
            this.playButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Location = new System.Drawing.Point(89, 177);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(244, 113);
            this.playButton.TabIndex = 2;
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playButton_MouseDown);
            this.playButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.playButton_MouseUp);
            // 
            // MainPB
            // 
            this.MainPB.BackColor = System.Drawing.SystemColors.Control;
            this.MainPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MainPB.Image = global::Game.Properties.Resources.MainMap;
            this.MainPB.Location = new System.Drawing.Point(0, 0);
            this.MainPB.Name = "MainPB";
            this.MainPB.Size = new System.Drawing.Size(2700, 2700);
            this.MainPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.MainPB.TabIndex = 0;
            this.MainPB.TabStop = false;
            this.MainPB.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPB_Paint);
            // 
            // BackPB
            // 
            this.BackPB.Image = global::Game.Properties.Resources.mainmenu;
            this.BackPB.Location = new System.Drawing.Point(0, 0);
            this.BackPB.Name = "BackPB";
            this.BackPB.Size = new System.Drawing.Size(100, 50);
            this.BackPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackPB.TabIndex = 3;
            this.BackPB.TabStop = false;
            this.BackPB.Paint += new System.Windows.Forms.PaintEventHandler(this.BackPB_Paint);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Game.Properties.Resources.upmenu;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.regenButton);
            this.panel1.Controls.Add(this.regenLabel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.speedButton);
            this.panel1.Controls.Add(this.speedLabel);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.healthButton);
            this.panel1.Controls.Add(this.healthLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.damageButton);
            this.panel1.Controls.Add(this.damageLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1011, 380);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 431);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 30);
            this.label2.TabIndex = 12;
            this.label2.Text = "LEVEL UP!";
            // 
            // regenButton
            // 
            this.regenButton.BackColor = System.Drawing.Color.Transparent;
            this.regenButton.FlatAppearance.BorderSize = 0;
            this.regenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regenButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regenButton.Location = new System.Drawing.Point(246, 256);
            this.regenButton.Name = "regenButton";
            this.regenButton.Size = new System.Drawing.Size(43, 33);
            this.regenButton.TabIndex = 11;
            this.regenButton.Text = "+";
            this.regenButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.regenButton.UseVisualStyleBackColor = false;
            this.regenButton.Click += new System.EventHandler(this.regenButton_Click);
            // 
            // regenLabel
            // 
            this.regenLabel.BackColor = System.Drawing.Color.Transparent;
            this.regenLabel.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regenLabel.Location = new System.Drawing.Point(197, 262);
            this.regenLabel.Name = "regenLabel";
            this.regenLabel.Size = new System.Drawing.Size(43, 32);
            this.regenLabel.TabIndex = 10;
            this.regenLabel.Text = "0";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(62, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 32);
            this.label8.TabIndex = 9;
            this.label8.Text = "REGEN";
            // 
            // speedButton
            // 
            this.speedButton.BackColor = System.Drawing.Color.Transparent;
            this.speedButton.FlatAppearance.BorderSize = 0;
            this.speedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedButton.Location = new System.Drawing.Point(246, 211);
            this.speedButton.Name = "speedButton";
            this.speedButton.Size = new System.Drawing.Size(43, 33);
            this.speedButton.TabIndex = 8;
            this.speedButton.Text = "+";
            this.speedButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.speedButton.UseVisualStyleBackColor = false;
            this.speedButton.Click += new System.EventHandler(this.speedButton_Click);
            // 
            // speedLabel
            // 
            this.speedLabel.BackColor = System.Drawing.Color.Transparent;
            this.speedLabel.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedLabel.Location = new System.Drawing.Point(197, 217);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(43, 32);
            this.speedLabel.TabIndex = 7;
            this.speedLabel.Text = "0";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(62, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 32);
            this.label6.TabIndex = 6;
            this.label6.Text = "SPEED";
            // 
            // healthButton
            // 
            this.healthButton.BackColor = System.Drawing.Color.Transparent;
            this.healthButton.FlatAppearance.BorderSize = 0;
            this.healthButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.healthButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthButton.Location = new System.Drawing.Point(246, 162);
            this.healthButton.Name = "healthButton";
            this.healthButton.Size = new System.Drawing.Size(43, 33);
            this.healthButton.TabIndex = 5;
            this.healthButton.Text = "+";
            this.healthButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.healthButton.UseVisualStyleBackColor = false;
            this.healthButton.Click += new System.EventHandler(this.healthButton_Click);
            // 
            // healthLabel
            // 
            this.healthLabel.BackColor = System.Drawing.Color.Transparent;
            this.healthLabel.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthLabel.Location = new System.Drawing.Point(197, 168);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(43, 32);
            this.healthLabel.TabIndex = 4;
            this.healthLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "HEALTH";
            // 
            // damageButton
            // 
            this.damageButton.BackColor = System.Drawing.Color.Transparent;
            this.damageButton.FlatAppearance.BorderSize = 0;
            this.damageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.damageButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.damageButton.Location = new System.Drawing.Point(246, 114);
            this.damageButton.Name = "damageButton";
            this.damageButton.Size = new System.Drawing.Size(43, 33);
            this.damageButton.TabIndex = 2;
            this.damageButton.Text = "+";
            this.damageButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.damageButton.UseVisualStyleBackColor = false;
            this.damageButton.Click += new System.EventHandler(this.damageButton_Click);
            // 
            // damageLabel
            // 
            this.damageLabel.BackColor = System.Drawing.Color.Transparent;
            this.damageLabel.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.damageLabel.Location = new System.Drawing.Point(197, 121);
            this.damageLabel.Name = "damageLabel";
            this.damageLabel.Size = new System.Drawing.Size(43, 32);
            this.damageLabel.TabIndex = 1;
            this.damageLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "DAMAGE";
            // 
            // endGameTimer
            // 
            this.endGameTimer.Interval = 25;
            this.endGameTimer.Tick += new System.EventHandler(this.endGameTimer_Tick);
            // 
            // deathLabel
            // 
            this.deathLabel.BackColor = System.Drawing.Color.Transparent;
            this.deathLabel.Font = new System.Drawing.Font("Copperplate Gothic Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.deathLabel.Location = new System.Drawing.Point(186, 150);
            this.deathLabel.Name = "deathLabel";
            this.deathLabel.Size = new System.Drawing.Size(798, 73);
            this.deathLabel.TabIndex = 5;
            this.deathLabel.Text = "YOU ARE DEAD";
            this.deathLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.ScoreLabel.Font = new System.Drawing.Font("Copperplate Gothic Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ScoreLabel.Location = new System.Drawing.Point(336, 269);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(183, 43);
            this.ScoreLabel.TabIndex = 6;
            this.ScoreLabel.Text = "SCORE:";
            // 
            // TimeLabel
            // 
            this.TimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimeLabel.Font = new System.Drawing.Font("Copperplate Gothic Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.TimeLabel.Location = new System.Drawing.Point(336, 335);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(183, 43);
            this.TimeLabel.TabIndex = 7;
            this.TimeLabel.Text = "TIME:";
            // 
            // LevelLabel
            // 
            this.LevelLabel.BackColor = System.Drawing.Color.Transparent;
            this.LevelLabel.Font = new System.Drawing.Font("Copperplate Gothic Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.LevelLabel.Location = new System.Drawing.Point(336, 402);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(183, 43);
            this.LevelLabel.TabIndex = 8;
            this.LevelLabel.Text = "LEVEL:";
            // 
            // ScoreNum
            // 
            this.ScoreNum.BackColor = System.Drawing.Color.Transparent;
            this.ScoreNum.Font = new System.Drawing.Font("Copperplate Gothic Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreNum.ForeColor = System.Drawing.SystemColors.Control;
            this.ScoreNum.Location = new System.Drawing.Point(566, 269);
            this.ScoreNum.Name = "ScoreNum";
            this.ScoreNum.Size = new System.Drawing.Size(274, 43);
            this.ScoreNum.TabIndex = 9;
            this.ScoreNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TimeNum
            // 
            this.TimeNum.BackColor = System.Drawing.Color.Transparent;
            this.TimeNum.Font = new System.Drawing.Font("Copperplate Gothic Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeNum.ForeColor = System.Drawing.SystemColors.Control;
            this.TimeNum.Location = new System.Drawing.Point(566, 335);
            this.TimeNum.Name = "TimeNum";
            this.TimeNum.Size = new System.Drawing.Size(274, 43);
            this.TimeNum.TabIndex = 10;
            this.TimeNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LevelNum
            // 
            this.LevelNum.BackColor = System.Drawing.Color.Transparent;
            this.LevelNum.Font = new System.Drawing.Font("Copperplate Gothic Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelNum.ForeColor = System.Drawing.SystemColors.Control;
            this.LevelNum.Location = new System.Drawing.Point(566, 402);
            this.LevelNum.Name = "LevelNum";
            this.LevelNum.Size = new System.Drawing.Size(274, 43);
            this.LevelNum.TabIndex = 11;
            this.LevelNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitButton.FlatAppearance.BorderSize = 2;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Copperplate Gothic Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.Control;
            this.exitButton.Location = new System.Drawing.Point(505, 504);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(176, 76);
            this.exitButton.TabIndex = 12;
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // pauseTimer
            // 
            this.pauseTimer.Interval = 15;
            this.pauseTimer.Tick += new System.EventHandler(this.pauseTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = global::Game.Properties.Resources.mainmenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 688);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.LevelNum);
            this.Controls.Add(this.TimeNum);
            this.Controls.Add(this.ScoreNum);
            this.Controls.Add(this.LevelLabel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.deathLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BackPB);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.MainPB);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.MainPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackPB)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer TickRate;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Timer PlayerAttackTimer;
        private System.Windows.Forms.Timer PlayerDeathTimer;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.PictureBox MainPB;
        private System.Windows.Forms.PictureBox BackPB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button damageButton;
        private System.Windows.Forms.Label damageLabel;
        private System.Windows.Forms.Button regenButton;
        private System.Windows.Forms.Label regenLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button speedButton;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button healthButton;
        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer endGameTimer;
        private System.Windows.Forms.Label deathLabel;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.Label ScoreNum;
        private System.Windows.Forms.Label TimeNum;
        private System.Windows.Forms.Label LevelNum;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Timer pauseTimer;
    }
}

