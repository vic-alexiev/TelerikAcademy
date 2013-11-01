namespace SnakeGame.UI
{
    partial class FormSnakeGame
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
            this.pictureBoxSnakeGame = new System.Windows.Forms.PictureBox();
            this.timerSnakeGame = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSnakeGame)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxSnakeGame
            // 
            this.pictureBoxSnakeGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxSnakeGame.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSnakeGame.Name = "pictureBoxSnakeGame";
            this.pictureBoxSnakeGame.Size = new System.Drawing.Size(500, 400);
            this.pictureBoxSnakeGame.TabIndex = 0;
            this.pictureBoxSnakeGame.TabStop = false;
            this.pictureBoxSnakeGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxSnakeGame_Paint);
            // 
            // timerSnakeGame
            // 
            this.timerSnakeGame.Enabled = true;
            this.timerSnakeGame.Interval = 200;
            this.timerSnakeGame.Tick += new System.EventHandler(this.timerSnakeGame_Tick);
            // 
            // FormSnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.pictureBoxSnakeGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormSnakeGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSnakeGame_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSnakeGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSnakeGame;
        private System.Windows.Forms.Timer timerSnakeGame;
    }
}

