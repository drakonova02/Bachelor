
namespace datingApp
{
    partial class SignInForm
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
            this.EmailSignInTextbox = new System.Windows.Forms.TextBox();
            this.PasswordSignInTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SignInbutton = new System.Windows.Forms.Button();
            this.SingUpLabel = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RegistrLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // EmailSignInTextbox
            // 
            this.EmailSignInTextbox.BackColor = System.Drawing.Color.Gainsboro;
            this.EmailSignInTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailSignInTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmailSignInTextbox.Location = new System.Drawing.Point(662, 170);
            this.EmailSignInTextbox.Name = "EmailSignInTextbox";
            this.EmailSignInTextbox.Size = new System.Drawing.Size(415, 27);
            this.EmailSignInTextbox.TabIndex = 3;
            this.EmailSignInTextbox.Enter += new System.EventHandler(this.EmailSignInTextbox_Enter);
            this.EmailSignInTextbox.Leave += new System.EventHandler(this.EmailSignInTextbox_Leave);
            // 
            // PasswordSignInTextbox
            // 
            this.PasswordSignInTextbox.BackColor = System.Drawing.Color.Gainsboro;
            this.PasswordSignInTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordSignInTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordSignInTextbox.Location = new System.Drawing.Point(662, 294);
            this.PasswordSignInTextbox.Name = "PasswordSignInTextbox";
            this.PasswordSignInTextbox.Size = new System.Drawing.Size(415, 27);
            this.PasswordSignInTextbox.TabIndex = 4;
            this.PasswordSignInTextbox.UseSystemPasswordChar = true;
            this.PasswordSignInTextbox.Enter += new System.EventHandler(this.PasswordSignInTextbox_Enter);
            this.PasswordSignInTextbox.Leave += new System.EventHandler(this.PasswordSignInTextbox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(712, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 57);
            this.label1.TabIndex = 5;
            this.label1.Text = "Welcome Back";
            // 
            // SignInbutton
            // 
            this.SignInbutton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.SignInbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SignInbutton.ForeColor = System.Drawing.Color.White;
            this.SignInbutton.Location = new System.Drawing.Point(722, 414);
            this.SignInbutton.Name = "SignInbutton";
            this.SignInbutton.Size = new System.Drawing.Size(302, 67);
            this.SignInbutton.TabIndex = 6;
            this.SignInbutton.Text = "Sign in";
            this.SignInbutton.UseVisualStyleBackColor = false;
            this.SignInbutton.Click += new System.EventHandler(this.SignInbutton_Click);
            // 
            // SingUpLabel
            // 
            this.SingUpLabel.AutoSize = true;
            this.SingUpLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SingUpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingUpLabel.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.SingUpLabel.Location = new System.Drawing.Point(882, 514);
            this.SingUpLabel.Name = "SingUpLabel";
            this.SingUpLabel.Size = new System.Drawing.Size(150, 20);
            this.SingUpLabel.TabIndex = 7;
            this.SingUpLabel.TabStop = true;
            this.SingUpLabel.Text = "Create an account.";
            this.SingUpLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SingUpLabel_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::datingApp.Properties.Resources.abstrakciya_geometriya_linii_2227_crop__2_;
            this.pictureBox1.Location = new System.Drawing.Point(-6, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(602, 638);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // RegistrLabel
            // 
            this.RegistrLabel.AutoSize = true;
            this.RegistrLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.RegistrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrLabel.ForeColor = System.Drawing.Color.Gray;
            this.RegistrLabel.Location = new System.Drawing.Point(718, 514);
            this.RegistrLabel.Name = "RegistrLabel";
            this.RegistrLabel.Size = new System.Drawing.Size(145, 20);
            this.RegistrLabel.TabIndex = 8;
            this.RegistrLabel.Text = "New to MeetShip?";
            // 
            // SignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 574);
            this.Controls.Add(this.RegistrLabel);
            this.Controls.Add(this.SingUpLabel);
            this.Controls.Add(this.SignInbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordSignInTextbox);
            this.Controls.Add(this.EmailSignInTextbox);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SignInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign In to MeetShip account";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignInForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox EmailSignInTextbox;
        private System.Windows.Forms.TextBox PasswordSignInTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SignInbutton;
        private System.Windows.Forms.LinkLabel SingUpLabel;
        private System.Windows.Forms.Label RegistrLabel;
    }
}