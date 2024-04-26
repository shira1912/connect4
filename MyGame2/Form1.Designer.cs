namespace MyGame2
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
            this.SuspendLayout();
            // 
            // signUpB1
            // 
            this.signUpB1.Location = new System.Drawing.Point(168, 183);
            this.signUpB1.Name = "signUpB1";
            this.signUpB1.Size = new System.Drawing.Size(75, 23);
            this.signUpB1.TabIndex = 3;
            this.signUpB1.Text = "Sign Up";
            this.signUpB1.UseVisualStyleBackColor = true;
            this.signUpB1.Click += new System.EventHandler(this.signUpB1_Click);
            // 
            // loginB1
            // 
            this.loginB1.Location = new System.Drawing.Point(168, 154);
            this.loginB1.Name = "loginB1";
            this.loginB1.Size = new System.Drawing.Size(75, 23);
            this.loginB1.TabIndex = 2;
            this.loginB1.Text = "Login";
            this.loginB1.UseVisualStyleBackColor = true;
            this.loginB1.Click += new System.EventHandler(this.loginB1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 360);
            this.Controls.Add(this.signUpB1);
            this.Controls.Add(this.loginB1);
            this.Name = "Form1";
            this.Text = "Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button signUpB1;
        private System.Windows.Forms.Button loginB1;
    }
}

