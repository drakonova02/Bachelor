
namespace datingApp
{
    partial class UserInfoForm2
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
            System.Windows.Forms.Button Nextbutton;
            System.Windows.Forms.Button MenuButton;
            this.NameUserLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AboutMeLabel = new System.Windows.Forms.Label();
            this.KidsCheck = new System.Windows.Forms.ComboBox();
            this.AlcogolCheck = new System.Windows.Forms.ComboBox();
            this.SmokeCheck = new System.Windows.Forms.ComboBox();
            this.ZodiacCheck = new System.Windows.Forms.ComboBox();
            this.ReligionCheck = new System.Windows.Forms.ComboBox();
            this.CharacterCheck = new System.Windows.Forms.ComboBox();
            this.RelationCheck = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            Nextbutton = new System.Windows.Forms.Button();
            MenuButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Nextbutton
            // 
            Nextbutton.BackColor = System.Drawing.Color.DarkOrchid;
            Nextbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            Nextbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            Nextbutton.ForeColor = System.Drawing.Color.White;
            Nextbutton.Location = new System.Drawing.Point(856, 495);
            Nextbutton.Name = "Nextbutton";
            Nextbutton.Size = new System.Drawing.Size(224, 67);
            Nextbutton.TabIndex = 32;
            Nextbutton.Text = "Next";
            Nextbutton.UseVisualStyleBackColor = false;
            Nextbutton.Click += new System.EventHandler(this.Nextbutton_Click);
            // 
            // MenuButton
            // 
            MenuButton.BackColor = System.Drawing.Color.DarkOrchid;
            MenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            MenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            MenuButton.ForeColor = System.Drawing.Color.White;
            MenuButton.Location = new System.Drawing.Point(545, 495);
            MenuButton.Name = "MenuButton";
            MenuButton.Size = new System.Drawing.Size(224, 67);
            MenuButton.TabIndex = 41;
            MenuButton.Text = "Menu";
            MenuButton.UseVisualStyleBackColor = false;
            MenuButton.Click += new System.EventHandler(this.Menubutton_Click);
            // 
            // NameUserLabel
            // 
            this.NameUserLabel.AutoSize = true;
            this.NameUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameUserLabel.ForeColor = System.Drawing.Color.White;
            this.NameUserLabel.Image = global::datingApp.Properties.Resources.фон;
            this.NameUserLabel.Location = new System.Drawing.Point(52, 434);
            this.NameUserLabel.Name = "NameUserLabel";
            this.NameUserLabel.Size = new System.Drawing.Size(77, 51);
            this.NameUserLabel.TabIndex = 30;
            this.NameUserLabel.Text = "UJ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::datingApp.Properties.Resources.purple_geometric_mosaic_background_1302_5845;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(516, 576);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // AboutMeLabel
            // 
            this.AboutMeLabel.AutoSize = true;
            this.AboutMeLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AboutMeLabel.Font = new System.Drawing.Font("Microsoft PhagsPa", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutMeLabel.ForeColor = System.Drawing.Color.DarkViolet;
            this.AboutMeLabel.Location = new System.Drawing.Point(796, 9);
            this.AboutMeLabel.Name = "AboutMeLabel";
            this.AboutMeLabel.Size = new System.Drawing.Size(284, 57);
            this.AboutMeLabel.TabIndex = 31;
            this.AboutMeLabel.Text = "Aboute me...";
            // 
            // KidsCheck
            // 
            this.KidsCheck.BackColor = System.Drawing.Color.Gainsboro;
            this.KidsCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.KidsCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KidsCheck.FormattingEnabled = true;
            this.KidsCheck.Items.AddRange(new object[] {
            "Want in the future",
            "Don`t want",
            "I have",
            "I haven`t answer"});
            this.KidsCheck.Location = new System.Drawing.Point(543, 123);
            this.KidsCheck.Name = "KidsCheck";
            this.KidsCheck.Size = new System.Drawing.Size(243, 37);
            this.KidsCheck.TabIndex = 33;
            this.KidsCheck.Enter += new System.EventHandler(this.KidsCheck_Enter);
            this.KidsCheck.Leave += new System.EventHandler(this.KidsCheck_Leave);
            // 
            // AlcogolCheck
            // 
            this.AlcogolCheck.BackColor = System.Drawing.Color.Gainsboro;
            this.AlcogolCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AlcogolCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AlcogolCheck.FormattingEnabled = true;
            this.AlcogolCheck.Items.AddRange(new object[] {
            "Never",
            "Sometimes",
            "Offer",
            "I haven`t answer"});
            this.AlcogolCheck.Location = new System.Drawing.Point(826, 123);
            this.AlcogolCheck.Name = "AlcogolCheck";
            this.AlcogolCheck.Size = new System.Drawing.Size(243, 37);
            this.AlcogolCheck.TabIndex = 34;
            this.AlcogolCheck.Enter += new System.EventHandler(this.AlcogolCheck_Enter);
            this.AlcogolCheck.Leave += new System.EventHandler(this.AlcogolCheck_Leave);
            // 
            // SmokeCheck
            // 
            this.SmokeCheck.BackColor = System.Drawing.Color.Gainsboro;
            this.SmokeCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SmokeCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SmokeCheck.FormattingEnabled = true;
            this.SmokeCheck.Items.AddRange(new object[] {
            "Never",
            "Sometimes",
            "Offer",
            "I haven`t answer"});
            this.SmokeCheck.Location = new System.Drawing.Point(543, 220);
            this.SmokeCheck.Name = "SmokeCheck";
            this.SmokeCheck.Size = new System.Drawing.Size(243, 37);
            this.SmokeCheck.TabIndex = 35;
            this.SmokeCheck.Enter += new System.EventHandler(this.SmokeCheck_Enter);
            this.SmokeCheck.Leave += new System.EventHandler(this.SmokeCheck_Leave);
            // 
            // ZodiacCheck
            // 
            this.ZodiacCheck.BackColor = System.Drawing.Color.Gainsboro;
            this.ZodiacCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZodiacCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ZodiacCheck.FormattingEnabled = true;
            this.ZodiacCheck.Items.AddRange(new object[] {
            "Aries",
            "Taurus",
            "Gemini",
            "Cancer",
            "Leo",
            "Virgo",
            "Libra",
            "Scorpio",
            "Sagittarius",
            "Capricorn",
            "Aquarius",
            "Pisces"});
            this.ZodiacCheck.Location = new System.Drawing.Point(826, 220);
            this.ZodiacCheck.Name = "ZodiacCheck";
            this.ZodiacCheck.Size = new System.Drawing.Size(243, 37);
            this.ZodiacCheck.TabIndex = 36;
            this.ZodiacCheck.Enter += new System.EventHandler(this.ZodiacCheck_Enter);
            this.ZodiacCheck.Leave += new System.EventHandler(this.ZodiacCheck_Leave);
            // 
            // ReligionCheck
            // 
            this.ReligionCheck.BackColor = System.Drawing.Color.Gainsboro;
            this.ReligionCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReligionCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReligionCheck.FormattingEnabled = true;
            this.ReligionCheck.Items.AddRange(new object[] {
            "Catholicism",
            "Orthodoxy",
            "Islam",
            "Buddhism"});
            this.ReligionCheck.Location = new System.Drawing.Point(543, 311);
            this.ReligionCheck.Name = "ReligionCheck";
            this.ReligionCheck.Size = new System.Drawing.Size(243, 37);
            this.ReligionCheck.TabIndex = 37;
            this.ReligionCheck.Enter += new System.EventHandler(this.ReligionCheck_Enter);
            this.ReligionCheck.Leave += new System.EventHandler(this.ReligionCheck_Leave);
            // 
            // CharacterCheck
            // 
            this.CharacterCheck.BackColor = System.Drawing.Color.Gainsboro;
            this.CharacterCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CharacterCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CharacterCheck.FormattingEnabled = true;
            this.CharacterCheck.Items.AddRange(new object[] {
            "Sanguine",
            "Choleric",
            "Melancholic",
            "Phlegmatic"});
            this.CharacterCheck.Location = new System.Drawing.Point(826, 311);
            this.CharacterCheck.Name = "CharacterCheck";
            this.CharacterCheck.Size = new System.Drawing.Size(243, 37);
            this.CharacterCheck.TabIndex = 38;
            this.CharacterCheck.Enter += new System.EventHandler(this.CharacterCheck_Enter);
            this.CharacterCheck.Leave += new System.EventHandler(this.CharacterCheck_Leave);
            // 
            // RelationCheck
            // 
            this.RelationCheck.BackColor = System.Drawing.Color.Gainsboro;
            this.RelationCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RelationCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RelationCheck.FormattingEnabled = true;
            this.RelationCheck.Items.AddRange(new object[] {
            "Single",
            "In meetship",
            "Complexity",
            "Haven`t` answer"});
            this.RelationCheck.Location = new System.Drawing.Point(695, 400);
            this.RelationCheck.Name = "RelationCheck";
            this.RelationCheck.Size = new System.Drawing.Size(243, 37);
            this.RelationCheck.TabIndex = 39;
            this.RelationCheck.Enter += new System.EventHandler(this.RealationCheck_Enter);
            this.RelationCheck.Leave += new System.EventHandler(this.RealationCheck_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(540, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 29);
            this.label1.TabIndex = 43;
            this.label1.Text = "Kids";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(821, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 29);
            this.label2.TabIndex = 44;
            this.label2.Text = "Alcogol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(540, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 29);
            this.label3.TabIndex = 45;
            this.label3.Text = "Smoke";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(821, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 29);
            this.label4.TabIndex = 46;
            this.label4.Text = "Zodiac";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(821, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 29);
            this.label5.TabIndex = 47;
            this.label5.Text = "Character";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(540, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 29);
            this.label6.TabIndex = 48;
            this.label6.Text = "Religion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(691, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 29);
            this.label7.TabIndex = 49;
            this.label7.Text = "Relation";
            // 
            // UserInfoForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 574);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(MenuButton);
            this.Controls.Add(this.RelationCheck);
            this.Controls.Add(this.CharacterCheck);
            this.Controls.Add(this.ReligionCheck);
            this.Controls.Add(this.ZodiacCheck);
            this.Controls.Add(this.SmokeCheck);
            this.Controls.Add(this.AlcogolCheck);
            this.Controls.Add(this.KidsCheck);
            this.Controls.Add(Nextbutton);
            this.Controls.Add(this.AboutMeLabel);
            this.Controls.Add(this.NameUserLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserInfoForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informaton of user";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserInfoForm2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameUserLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label AboutMeLabel;
        private System.Windows.Forms.ComboBox KidsCheck;
        private System.Windows.Forms.ComboBox AlcogolCheck;
        private System.Windows.Forms.ComboBox SmokeCheck;
        private System.Windows.Forms.ComboBox ZodiacCheck;
        private System.Windows.Forms.ComboBox ReligionCheck;
        private System.Windows.Forms.ComboBox CharacterCheck;
        private System.Windows.Forms.ComboBox RelationCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}