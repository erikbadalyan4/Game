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
            this.MainPB = new System.Windows.Forms.PictureBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.PlayerAttackTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayerDeathTimer = new System.Windows.Forms.Timer(this.components);
            this.playButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainPB)).BeginInit();
            this.SuspendLayout();
            // 
            // TickRate
            // 
            this.TickRate.Interval = 10;
            this.TickRate.Tick += new System.EventHandler(this.TickRate_Tick);
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
            this.playButton.Location = new System.Drawing.Point(471, 288);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(244, 113);
            this.playButton.TabIndex = 2;
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playButton_MouseDown);
            this.playButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.playButton_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = global::Game.Properties.Resources.mainmenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 688);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.MainPB);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.MainPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPB;
        private System.Windows.Forms.Timer TickRate;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Timer PlayerAttackTimer;
        private System.Windows.Forms.Timer PlayerDeathTimer;
        private System.Windows.Forms.Button playButton;
    }
}

