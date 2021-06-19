
namespace datingApp
{
    partial class MeetShipForm
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
            this.MainPic = new System.Windows.Forms.PictureBox();
            this.NameApp = new System.Windows.Forms.Label();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.buttonSignUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainPic)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPic
            // 
            this.MainPic.Image = global::datingApp.Properties.Resources.imgonline_com_ua_Resize_s9Z90nrin9Xq3Teb;
            this.MainPic.Location = new System.Drawing.Point(94, 12);
            this.MainPic.Name = "MainPic";
            this.MainPic.Size = new System.Drawing.Size(338, 326);
            this.MainPic.TabIndex = 0;
            this.MainPic.TabStop = false;
            // 
            // NameApp
            // 
            this.NameApp.AutoSize = true;
            this.NameApp.Font = new System.Drawing.Font("Script MT Bold", 34.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameApp.Location = new System.Drawing.Point(133, 341);
            this.NameApp.Name = "NameApp";
            this.NameApp.Size = new System.Drawing.Size(254, 70);
            this.NameApp.TabIndex = 3;
            this.NameApp.Text = "MeetShip";
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSignIn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonSignIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.buttonSignIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.buttonSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSignIn.Location = new System.Drawing.Point(42, 445);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(173, 84);
            this.buttonSignIn.TabIndex = 1;
            this.buttonSignIn.Text = "Sign in";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.buttonSignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSignUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSignUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCyan;
            this.buttonSignUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.buttonSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSignUp.Location = new System.Drawing.Point(311, 445);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(173, 84);
            this.buttonSignUp.TabIndex = 2;
            this.buttonSignUp.Text = "Sign up";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // MeetShipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(524, 574);
            this.Controls.Add(this.NameApp);
            this.Controls.Add(this.buttonSignUp);
            this.Controls.Add(this.buttonSignIn);
            this.Controls.Add(this.MainPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MeetShipForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeetShip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.MainPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPic;
        private System.Windows.Forms.Label NameApp;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.Button buttonSignUp;
    }
}

