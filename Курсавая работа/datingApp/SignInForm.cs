using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace datingApp
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();

            PasswordSignInTextbox.Text = "Input your password";         //задамо початкового значення полю пароль
            PasswordSignInTextbox.ForeColor = Color.Gray;               //задамо початкового кольору
            PasswordSignInTextbox.UseSystemPasswordChar = false;        //вимкнемо скриття тексту пароля

            EmailSignInTextbox.Text = "Input your email";               //однорідні дії як з паролем
            EmailSignInTextbox.ForeColor = Color.Gray;

            this.EmailSignInTextbox.AutoSize = false;                   //задамо нового розміру полям 
            this.EmailSignInTextbox.Size = new Size(this.EmailSignInTextbox.Size.Width, 45);

            this.PasswordSignInTextbox.AutoSize = false;
            this.PasswordSignInTextbox.Size = new Size(this.PasswordSignInTextbox.Size.Width, 45);
        }

        private void SignInForm_FormClosing(object sender, FormClosingEventArgs e)  //закриття программи
        {
            //підтвердження про закриття за допомогою діалогового вікна

            DialogResult dialog = MessageBox.Show(
             "Do you want go out?", "Exit",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                Environment.Exit(0);        // вихід з програми
            }
            else
            {
                e.Cancel = true;            //продовжити сесію
            }
        }

        private void SignInbutton_Click(object sender, EventArgs e) //Вхід в систему
        {
            //перевірка полей на заповнення 

            if (EmailSignInTextbox.Text == "Input your email" && PasswordSignInTextbox.Text == "Input your password")
            {
                MessageBox.Show("Please, to correct your answers", "Error");
                return;
            }

            if (Program.users.IsPerson(EmailSignInTextbox.Text, PasswordSignInTextbox.Text))
            {
                Program.User = Program.users[Program.User.UserInd(EmailSignInTextbox.Text)];
                Program.IndexUser = Program.User.UserInd(EmailSignInTextbox.Text);
                this.Hide();                                     //закриття даної форми
                MenuForm input = new MenuForm();          //створення об'єкта форми меню
                input.Show();                                    // та відкриваємо її
            }
            else MessageBox.Show("To correct your answer", "Error");
        }

        private void SingUpLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)    //перехід до форми регістрації
        {
            this.Hide();                        //закриття даної форми
            JoinIn input = new JoinIn();        //створення об'єкта форми регістрації
            input.Show();                       //та відкриття її
        }

        //наступні 2 методи задають значення текстбоксам на формі при вході в них
        private void EmailSignInTextbox_Enter(object sender, EventArgs e)
        {
            //перевірка текста, якщо він є початковим
            if (EmailSignInTextbox.Text == "Input your email")
            {
                EmailSignInTextbox.Text = "";                   //зміна на пустий текстбокс
                EmailSignInTextbox.ForeColor = Color.Black;     //зміна кольору на більш насищенний
            }
        }

        private void PasswordSignInTextbox_Enter(object sender, EventArgs e)
        {
            if (PasswordSignInTextbox.Text == "Input your password")
            {
                PasswordSignInTextbox.Text = "";
                PasswordSignInTextbox.ForeColor = Color.Black;
                PasswordSignInTextbox.UseSystemPasswordChar = true;
            }
        }

        //наступні 2 методи задають значення текстбоксам на формі при виході з них
        private void PasswordSignInTextbox_Leave(object sender, EventArgs e)
        {
            //перевірка чи заповнений
            if (PasswordSignInTextbox.Text == "")                       //якщо пустий
            {                                                           //то встановлюємо початкове значення
                PasswordSignInTextbox.Text = "Input your password";
                PasswordSignInTextbox.ForeColor = Color.Gray;
                PasswordSignInTextbox.UseSystemPasswordChar = false;
            }
        }

        private void EmailSignInTextbox_Leave(object sender, EventArgs e)
        {
            if (EmailSignInTextbox.Text == "")
            {
                EmailSignInTextbox.Text = "Input your email";
                EmailSignInTextbox.ForeColor = Color.Gray;

            }
        }
    }
}
