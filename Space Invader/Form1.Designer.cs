namespace Space_Invader
{
    partial class SpaceInvaders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpaceInvaders));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel = new System.Windows.Forms.Label();
            this.livesLabel = new System.Windows.Forms.Label();
            this.scoreNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.livesNumber = new System.Windows.Forms.Label();
            this.spaceLabel = new System.Windows.Forms.Label();
            this.invadersLabel = new System.Windows.Forms.Label();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(12, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(84, 28);
            this.scoreLabel.TabIndex = 0;
            this.scoreLabel.Text = "SCORE";
            // 
            // livesLabel
            // 
            this.livesLabel.AutoSize = true;
            this.livesLabel.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livesLabel.ForeColor = System.Drawing.Color.White;
            this.livesLabel.Location = new System.Drawing.Point(673, 9);
            this.livesLabel.Name = "livesLabel";
            this.livesLabel.Size = new System.Drawing.Size(63, 28);
            this.livesLabel.TabIndex = 1;
            this.livesLabel.Text = "LIVES";
            // 
            // scoreNumber
            // 
            this.scoreNumber.AutoSize = true;
            this.scoreNumber.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreNumber.ForeColor = System.Drawing.Color.LawnGreen;
            this.scoreNumber.Location = new System.Drawing.Point(123, 9);
            this.scoreNumber.Name = "scoreNumber";
            this.scoreNumber.Size = new System.Drawing.Size(26, 28);
            this.scoreNumber.TabIndex = 2;
            this.scoreNumber.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(590, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 28);
            this.label4.TabIndex = 3;
            // 
            // livesNumber
            // 
            this.livesNumber.AutoSize = true;
            this.livesNumber.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livesNumber.ForeColor = System.Drawing.Color.LawnGreen;
            this.livesNumber.Location = new System.Drawing.Point(756, 9);
            this.livesNumber.Name = "livesNumber";
            this.livesNumber.Size = new System.Drawing.Size(26, 28);
            this.livesNumber.TabIndex = 4;
            this.livesNumber.Text = "0";
            // 
            // spaceLabel
            // 
            this.spaceLabel.Font = new System.Drawing.Font("Bauhaus 93", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spaceLabel.ForeColor = System.Drawing.Color.White;
            this.spaceLabel.Location = new System.Drawing.Point(215, 21);
            this.spaceLabel.Name = "spaceLabel";
            this.spaceLabel.Size = new System.Drawing.Size(393, 136);
            this.spaceLabel.TabIndex = 5;
            this.spaceLabel.Text = "SPACE";
            this.spaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // invadersLabel
            // 
            this.invadersLabel.Font = new System.Drawing.Font("Bauhaus 93", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invadersLabel.ForeColor = System.Drawing.Color.LawnGreen;
            this.invadersLabel.Location = new System.Drawing.Point(227, 157);
            this.invadersLabel.Name = "invadersLabel";
            this.invadersLabel.Size = new System.Drawing.Size(381, 91);
            this.invadersLabel.TabIndex = 6;
            this.invadersLabel.Text = "INVADERS";
            this.invadersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Font = new System.Drawing.Font("Bauhaus 93", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel.ForeColor = System.Drawing.Color.White;
            this.instructionLabel.Location = new System.Drawing.Point(240, 317);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(368, 43);
            this.instructionLabel.TabIndex = 7;
            this.instructionLabel.Text = "PRESS ENTER TO PLAY";
            // 
            // SpaceInvaders
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.invadersLabel);
            this.Controls.Add(this.spaceLabel);
            this.Controls.Add(this.livesNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.scoreNumber);
            this.Controls.Add(this.livesLabel);
            this.Controls.Add(this.scoreLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Bauhaus 93", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SpaceInvaders";
            this.Text = "Space Invaders";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SpaceInvaders_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpaceInvaders_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SpaceInvaders_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label livesLabel;
        private System.Windows.Forms.Label scoreNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label livesNumber;
        private System.Windows.Forms.Label spaceLabel;
        private System.Windows.Forms.Label invadersLabel;
        private System.Windows.Forms.Label instructionLabel;
    }
}

