namespace Space_Invaders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelScore = new System.Windows.Forms.Label();
            this.lvlabel = new System.Windows.Forms.Label();
            this.labelHealth = new System.Windows.Forms.Label();
            this.hp2 = new System.Windows.Forms.PictureBox();
            this.hp1 = new System.Windows.Forms.PictureBox();
            this.hp0 = new System.Windows.Forms.PictureBox();
            this.pause = new System.Windows.Forms.PictureBox();
            this.Field = new System.Windows.Forms.PictureBox();
            this.gOver = new System.Windows.Forms.PictureBox();
            this.labelToStart = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.hp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hp0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gOver)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft New Tai Lue", 17.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(250)));
            this.labelScore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelScore.Location = new System.Drawing.Point(47, 0);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(115, 30);
            this.labelScore.TabIndex = 2;
            this.labelScore.Text = "SCORE : 0";
            // 
            // lvlabel
            // 
            this.lvlabel.AutoSize = true;
            this.lvlabel.Font = new System.Drawing.Font("Microsoft New Tai Lue", 17.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(250)));
            this.lvlabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvlabel.Location = new System.Drawing.Point(390, 0);
            this.lvlabel.Name = "lvlabel";
            this.lvlabel.Size = new System.Drawing.Size(65, 30);
            this.lvlabel.TabIndex = 3;
            this.lvlabel.Text = "LVL1";
            // 
            // labelHealth
            // 
            this.labelHealth.AutoSize = true;
            this.labelHealth.Font = new System.Drawing.Font("Microsoft New Tai Lue", 17.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(250)));
            this.labelHealth.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHealth.Location = new System.Drawing.Point(704, 0);
            this.labelHealth.Name = "labelHealth";
            this.labelHealth.Size = new System.Drawing.Size(57, 30);
            this.labelHealth.TabIndex = 4;
            this.labelHealth.Text = ": HP";
            // 
            // hp2
            // 
            this.hp2.BackgroundImage = global::Space_Invaders.Properties.Resources.heart;
            this.hp2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hp2.Location = new System.Drawing.Point(605, 0);
            this.hp2.Name = "hp2";
            this.hp2.Size = new System.Drawing.Size(30, 30);
            this.hp2.TabIndex = 7;
            this.hp2.TabStop = false;
            // 
            // hp1
            // 
            this.hp1.BackgroundImage = global::Space_Invaders.Properties.Resources.heart;
            this.hp1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hp1.Location = new System.Drawing.Point(641, 0);
            this.hp1.Name = "hp1";
            this.hp1.Size = new System.Drawing.Size(30, 30);
            this.hp1.TabIndex = 6;
            this.hp1.TabStop = false;
            // 
            // hp0
            // 
            this.hp0.BackgroundImage = global::Space_Invaders.Properties.Resources.heart;
            this.hp0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hp0.Location = new System.Drawing.Point(677, 0);
            this.hp0.Name = "hp0";
            this.hp0.Size = new System.Drawing.Size(30, 30);
            this.hp0.TabIndex = 5;
            this.hp0.TabStop = false;
            // 
            // pause
            // 
            this.pause.BackgroundImage = global::Space_Invaders.Properties.Resources.pause;
            this.pause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pause.Enabled = false;
            this.pause.Location = new System.Drawing.Point(26, 310);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(100, 50);
            this.pause.TabIndex = 1;
            this.pause.TabStop = false;
            this.pause.Visible = false;
            // 
            // Field
            // 
            this.Field.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Field.Location = new System.Drawing.Point(0, 0);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(834, 612);
            this.Field.TabIndex = 0;
            this.Field.TabStop = false;
            // 
            // gOver
            // 
            this.gOver.BackgroundImage = global::Space_Invaders.Properties.Resources.gameover;
            this.gOver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gOver.Enabled = false;
            this.gOver.Location = new System.Drawing.Point(26, 384);
            this.gOver.Name = "gOver";
            this.gOver.Size = new System.Drawing.Size(100, 50);
            this.gOver.TabIndex = 8;
            this.gOver.TabStop = false;
            this.gOver.Visible = false;
            // 
            // labelToStart
            // 
            this.labelToStart.AutoSize = true;
            this.labelToStart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelToStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelToStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelToStart.Location = new System.Drawing.Point(313, 195);
            this.labelToStart.Name = "labelToStart";
            this.labelToStart.Size = new System.Drawing.Size(204, 26);
            this.labelToStart.TabIndex = 9;
            this.labelToStart.Text = "Press \'z\' to start lvl1";
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 5000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Space_Invaders.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(834, 612);
            this.Controls.Add(this.labelToStart);
            this.Controls.Add(this.gOver);
            this.Controls.Add(this.hp2);
            this.Controls.Add(this.hp1);
            this.Controls.Add(this.hp0);
            this.Controls.Add(this.labelHealth);
            this.Controls.Add(this.lvlabel);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.Field);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Space Invaders";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.hp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hp0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gOver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Field;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pause;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label lvlabel;
        private System.Windows.Forms.Label labelHealth;
        private System.Windows.Forms.PictureBox hp0;
        private System.Windows.Forms.PictureBox hp1;
        private System.Windows.Forms.PictureBox hp2;
        private System.Windows.Forms.PictureBox gOver;
        private System.Windows.Forms.Label labelToStart;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
    }
}

