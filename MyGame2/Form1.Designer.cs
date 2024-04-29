namespace ConnectFour
{
    partial class Form1
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
            this.signUpB1 = new System.Windows.Forms.Button();
            this.loginB1 = new System.Windows.Forms.Button();
            this.returnPicBox = new System.Windows.Forms.PictureBox();
            this.connect4title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.returnPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // signUpB1
            // 
            this.signUpB1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.signUpB1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.signUpB1.Location = new System.Drawing.Point(168, 183);
            this.signUpB1.Name = "signUpB1";
            this.signUpB1.Size = new System.Drawing.Size(75, 23);
            this.signUpB1.TabIndex = 3;
            this.signUpB1.Text = "Sign Up";
            this.signUpB1.UseVisualStyleBackColor = false;
            this.signUpB1.Click += new System.EventHandler(this.signUpB1_Click);
            // 
            // loginB1
            // 
            this.loginB1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.loginB1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.loginB1.Location = new System.Drawing.Point(168, 154);
            this.loginB1.Name = "loginB1";
            this.loginB1.Size = new System.Drawing.Size(75, 23);
            this.loginB1.TabIndex = 2;
            this.loginB1.Text = "Login";
            this.loginB1.UseVisualStyleBackColor = false;
            this.loginB1.Click += new System.EventHandler(this.loginB1_Click);
            // 
            // returnPicBox
            // 
            this.returnPicBox.Image = global::ConnectFour.Properties.Resources.return_arrow_without_background;
            this.returnPicBox.Location = new System.Drawing.Point(343, 301);
            this.returnPicBox.Name = "returnPicBox";
            this.returnPicBox.Size = new System.Drawing.Size(47, 47);
            this.returnPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.returnPicBox.TabIndex = 4;
            this.returnPicBox.TabStop = false;
            this.returnPicBox.Click += new System.EventHandler(this.returnPicBox_Click);
            // 
            // connect4title
            // 
            this.connect4title.AutoSize = true;
            this.connect4title.Font = new System.Drawing.Font("David", 35.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect4title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.connect4title.Location = new System.Drawing.Point(61, 75);
            this.connect4title.Name = "connect4title";
            this.connect4title.Size = new System.Drawing.Size(286, 47);
            this.connect4title.TabIndex = 5;
            this.connect4title.Text = "CONNECT 4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(411, 360);
            this.Controls.Add(this.connect4title);
            this.Controls.Add(this.returnPicBox);
            this.Controls.Add(this.signUpB1);
            this.Controls.Add(this.loginB1);
            this.Name = "Form1";
            this.Text = "Login and Sign Up";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.returnPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button signUpB1;
        private System.Windows.Forms.Button loginB1;
        private System.Windows.Forms.PictureBox returnPicBox;
        private System.Windows.Forms.Label connect4title;
    }
}

