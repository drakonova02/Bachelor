using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace datingApp
{
    public partial class JoinIn : Form
    {
        public JoinIn()
        {
            InitializeComponent();

            //у наступних рядках задамо початкового значення та кольору для всіх полів форми
            NameTextbox.Text = "Input your full name";
            NameTextbox.ForeColor = Color.Gray;

            EmailTextbox.Text = "Input your email address";
            EmailTextbox.ForeColor = Color.Gray;

            PasswordTextbox.Text = "Input your password";
            PasswordTextbox.ForeColor = Color.Gray;

            AgeTextbox.Text = "Input your real age";
            AgeTextbox.ForeColor = Color.Gray;

            //задамо розміри полів
            this.NameTextbox.AutoSize = false;
            this.NameTextbox.Size = new Size(this.NameTextbox.Size.Width, 45);

            this.EmailTextbox.AutoSize = false;
            this.EmailTextbox.Size = new Size(this.EmailTextbox.Size.Width, 45);

            this.PasswordTextbox.AutoSize = false;
            this.PasswordTextbox.Size = new Size(this.PasswordTextbox.Size.Width, 45);

            this.AgeTextbox.AutoSize = false;
            this.AgeTextbox.Size = new Size(this.AgeTextbox.Size.Width, 45);

            //створюємо масив з можливим списком вибору для GenderlistBox
            string[] gender = { "Male", "Female", "Agender", "Androgynous", "Androgyne", "FTM ", "MTF"};
            GenderlistBox.Items.AddRange(gender);
        }

        private void JoinIn_FormClosing(object sender, FormClosingEventArgs e)  //закриття программи
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

        private void SingUpLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)    //перехід до Входу
        {
            this.Hide();                                      //закрити дану форму
            SignInForm input = new SignInForm();             //створити об'єкт для форми Вхід
            input.Show();                                    //відкрити її
        }

        private void SignUpbutton_Click(object sender, EventArgs e)
        {
            //перевірка: чи введені дані
            if (NameTextbox.Text == "Input your full name" || 
                AgeTextbox.Text == "Input your real age" || 
                GenderlistBox.SelectedIndex == -1 ||
                EmailTextbox.Text == "Input your email address" || 
                PasswordTextbox.Text == "Input your password")
            {
                MessageBox.Show("Please, input all boxes", "Error");
                return;
            }

            Program.User = new User(NameTextbox.Text, EmailTextbox.Text, PasswordTextbox.Text, Convert.ToInt32(AgeTextbox.Text), GenderlistBox.Text);

            if(Program.User.UserInd(EmailTextbox.Text) == -1) 
            {
                Program.users.Add(Program.User);

                if (File.Exists("DataOfUser.xml"))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(UserArray));

                    // получаем поток, куда будем записывать сериализованный объект
                    using (FileStream fs = new FileStream("DataOfUser.xml", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, Program.users);
                    }
                }
            }
            else
            {
                MessageBox.Show("This email is had in the app. Try again", "Error");
                return;
            }

            this.Hide();                                            //закриття форми
            UserInfoForm input = new UserInfoForm();        //створення об'єкту форми Інформаці
            input.Show();                                           //відкриття її
        }

        //наступні 4 методи задають значення текстбоксам на формі при вході в них
        private void NameTextbox_Enter(object sender, EventArgs e)
        {
            if (NameTextbox.Text == "Input your full name")
            {
                NameTextbox.Text = "";
                NameTextbox.ForeColor = Color.Black;
            }
        }

        private void EmailTextbox_Enter(object sender, EventArgs e)
        {
            if (EmailTextbox.Text == "Input your email address")
            {
                EmailTextbox.Text = "";
                EmailTextbox.ForeColor = Color.Black;
            }
        }

        private void PasswordTextbox_Enter(object sender, EventArgs e)
        {
            if (PasswordTextbox.Text == "Input your password")
            {
                PasswordTextbox.Text = "";
                PasswordTextbox.ForeColor = Color.Black;
            }
        }

        private void AgeTextbox_Enter(object sender, EventArgs e)
        {
            if (AgeTextbox.Text == "Input your real age")
            {
                AgeTextbox.Text = "";
                AgeTextbox.ForeColor = Color.Black;
            }
        }


        //наступні 4 методи задають значення текстбоксам
        private void NameTextbox_Leave(object sender, EventArgs e)
        {
            // проверка на написание
            if (NameTextbox.Text != "")
            {
                foreach (var s in NameTextbox.Text)
                {
                    //якщо символ не є літерою або пробілом попередження
                    if (!Char.IsLetter(s) && Convert.ToChar(s) != ' ')
                    {
                        MessageBox.Show("Please, to correct Name", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NameTextbox.Text = "";
                        break;
                    }
                }
            }
            if (NameTextbox.Text == "")
            {
                NameTextbox.Text = "Input your full name";
                NameTextbox.ForeColor = Color.Gray;
            }
        }

        private void EmailTextbox_Leave(object sender, EventArgs e)
        {
            if (EmailTextbox.Text != "")
            {
                //якщо у текстбоксі не має такого виразів, то попередження
                if (!Regex.IsMatch(EmailTextbox.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$")) 
                {
                    MessageBox.Show("Please, to correct email", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmailTextbox.Text = "";
                }
            }
            if (EmailTextbox.Text == "")
            {
                EmailTextbox.Text = "Input your email address";
                EmailTextbox.ForeColor = Color.Gray;
            }
        }

        private void PasswordTextbox_Leave(object sender, EventArgs e)
        {
            if (PasswordTextbox.Text == "")
            {
                PasswordTextbox.Text = "Input your password";
                PasswordTextbox.ForeColor = Color.Gray;
            }
        }

        private void AgeTextbox_Leave(object sender, EventArgs e)
        {
            // проверка на написание
            if (AgeTextbox.Text != "")
            {
                //перевірка на інші символи
                foreach (var s in AgeTextbox.Text)
                {
                    if (!Char.IsDigit(s))
                    {
                        MessageBox.Show("Please, to correct Age", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AgeTextbox.Text = "";
                        break;
                    }
                }

                //перевірка на реальність данних 
                if (Convert.ToInt32(AgeTextbox.Text) < 18)
                {
                    MessageBox.Show("You are younge for this app", "Error");
                    AgeTextbox.Text = "";
                }
                else if (Convert.ToInt32(AgeTextbox.Text) > 105)
                {
                    MessageBox.Show("You are old for this app", "Error");
                    AgeTextbox.Text = "";
                }

            }
            if (AgeTextbox.Text == "")
            {
                AgeTextbox.Text = "Input your real age";
                AgeTextbox.ForeColor = Color.Gray;
            }
        }
    }   
}
