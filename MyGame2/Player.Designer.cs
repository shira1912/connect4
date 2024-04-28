﻿namespace ConnectFour
{
    partial class Player
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
            this.label1 = new System.Windows.Forms.Label();
            this.connect4title = new System.Windows.Forms.Label();
            this.playerColorL = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.itsLabel = new System.Windows.Forms.Label();
            this.turnPicBox = new System.Windows.Forms.PictureBox();
            this.turnLabel = new System.Windows.Forms.Label();
            this.newGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // connect4title
            // 
            this.connect4title.AutoSize = true;
            this.connect4title.Font = new System.Drawing.Font("David", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect4title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.connect4title.Location = new System.Drawing.Point(413, 55);
            this.connect4title.Name = "connect4title";
            this.connect4title.Size = new System.Drawing.Size(163, 27);
            this.connect4title.TabIndex = 6;
            this.connect4title.Text = "CONNECT 4";
            // 
            // playerColorL
            // 
            this.playerColorL.AutoSize = true;
            this.playerColorL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerColorL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.playerColorL.Location = new System.Drawing.Point(424, 116);
            this.playerColorL.Name = "playerColorL";
            this.playerColorL.Size = new System.Drawing.Size(77, 17);
            this.playerColorL.TabIndex = 7;
            this.playerColorL.Text = "Your color:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(507, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 50);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // itsLabel
            // 
            this.itsLabel.AutoSize = true;
            this.itsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.itsLabel.Location = new System.Drawing.Point(427, 212);
            this.itsLabel.Name = "itsLabel";
            this.itsLabel.Size = new System.Drawing.Size(25, 17);
            this.itsLabel.TabIndex = 9;
            this.itsLabel.Text = "It\'s";
            // 
            // turnPicBox
            // 
            this.turnPicBox.Location = new System.Drawing.Point(458, 199);
            this.turnPicBox.Name = "turnPicBox";
            this.turnPicBox.Size = new System.Drawing.Size(55, 50);
            this.turnPicBox.TabIndex = 10;
            this.turnPicBox.TabStop = false;
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.turnLabel.Location = new System.Drawing.Point(519, 214);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(47, 17);
            this.turnLabel.TabIndex = 11;
            this.turnLabel.Text = "\'s turn";
            // 
            // newGame
            // 
            this.newGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.newGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.newGame.Location = new System.Drawing.Point(458, 297);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(75, 23);
            this.newGame.TabIndex = 12;
            this.newGame.Text = "New Game";
            this.newGame.UseVisualStyleBackColor = false;
            this.newGame.Click += new System.EventHandler(this.newGame_Click);
            // 
            // Player1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(619, 377);
            this.Controls.Add(this.newGame);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.turnPicBox);
            this.Controls.Add(this.itsLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.playerColorL);
            this.Controls.Add(this.connect4title);
            this.Controls.Add(this.label1);
            this.Name = "Player1";
            this.Text = "Player1";
            this.Load += new System.EventHandler(this.Player1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label connect4title;
        private System.Windows.Forms.Label playerColorL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label itsLabel;
        private System.Windows.Forms.PictureBox turnPicBox;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Button newGame;
    }
}