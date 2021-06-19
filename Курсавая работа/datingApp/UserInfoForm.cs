using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace datingApp
{
    public partial class UserInfoForm : Form
    {

        public UserInfoForm()
        {
            InitializeComponent();

            NameUserLabel.Text = Program.User.Name;       //задамо значення NameUserLabel

            //у наступних рядках задамо початкового значення та кольору для всіх полів форми
            if(Program.User.From == null)FromTextbox.Text = "Where are you from?";
            else FromTextbox.Text = Program.User.From;
            FromTextbox.ForeColor = Color.Gray;

            if (Program.User.Education == null) EducationTextbox.Text = "Where did you study?";
            else EducationTextbox.Text = Program.User.Education;
            EducationTextbox.ForeColor = Color.Gray;

            if (Program.User.Job == null) JobTextbox.Text = "Where did you work?";
            else JobTextbox.Text = Program.User.Job;
            JobTextbox.ForeColor = Color.Gray;

            if (Program.User.Phone == null) PhoneTextbox.Text = "Input your phone number";
            else PhoneTextbox.Text = Program.User.Phone;
            PhoneTextbox.ForeColor = Color.Gray;

            if (Program.User.Height == 0) HeightTextbox.Text = "What is your height?";
            else HeightTextbox.Text = Convert.ToString(Program.User.Height);
            HeightTextbox.ForeColor = Color.Gray;
                        
            //задамо розміри полів
            this.PhoneTextbox.AutoSize = false;
            this.PhoneTextbox.Size = new Size(this.PhoneTextbox.Size.Width, 45);

            this.FromTextbox.AutoSize = false;
            this.FromTextbox.Size = new Size(this.FromTextbox.Size.Width, 45);

            this.JobTextbox.AutoSize = false;
            this.JobTextbox.Size = new Size(this.JobTextbox.Size.Width, 45);

            this.EducationTextbox.AutoSize = false;
            this.EducationTextbox.Size = new Size(this.EducationTextbox.Size.Width, 45);

            this.HeightTextbox.AutoSize = false;
            this.HeightTextbox.Size = new Size(this.HeightTextbox.Size.Width, 45);
        }

        private void UserInfoForm_FormClosing(object sender, FormClosingEventArgs e)  //закриття программи
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

        private void addData()  //додавання данних з текстбокс
        {   
            //в наступних рядках йде перевірка данних та додавання їх до елемента
            if (FromTextbox.Text != "Where are you from?")
                Program.User.From = FromTextbox.Text;

            if (EducationTextbox.Text != "Where did you study?")
                Program.User.Education = EducationTextbox.Text;

            if (JobTextbox.Text != "Where did you work?")
                Program.User.Job = JobTextbox.Text;

            if (PhoneTextbox.Text != "Input your phone number")
                Program.User.Phone = PhoneTextbox.Text;

            if (HeightTextbox.Text != "What is your height?")
                Program.User.Height = Convert.ToInt32(HeightTextbox.Text);

            //обновлення елементу
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

        private void Nextbutton_Click(object sender, EventArgs e)   //перехід до наступної сторінки
        {
            addData();                                               //додати нові дані
            
            this.Hide();                                            //закрити дану форму
            UserInfoForm2 input = new UserInfoForm2();              //створення об'єкта форми Продовження інформацїї про юзера
            input.Show();                                           //відкрити її
              
        }

        private void Menubutton_Click(object sender, EventArgs e)   //перехід у Меню
        {
            //перевірка, що це не перший вхід в систему
            if (Program.User.Kids != null)
            {
                addData();                                              //додати нові дані

                this.Hide();                                            //закрити дану форму
                MenuForm input = new MenuForm();                        //створення об'єкта форми Меню
                input.Show();                                           //відкрити її
            }
            else
            {
                MessageBox.Show(
                "Please, this your sign up in system, go on your registration", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //наступні 4 методи задають значення текстбоксам
        private void FromTextbox_Leave(object sender, EventArgs e)
        {
            //проверка на написание 
            if (FromTextbox.Text != "")
            {
                foreach (var s in FromTextbox.Text)
                {
                    if (!Char.IsLetter(s) /*|| Convert.ToChar(s)!='-' */&& Convert.ToChar(s) != ' ')
                    {
                        MessageBox.Show( "Please, to correct name of your country", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        FromTextbox.Text = "";
                        break;
                    }
                }
            }

            if (FromTextbox.Text == "") //повернення до початкового значення
            {
                FromTextbox.Text = "Where are you from?";
                FromTextbox.ForeColor = Color.Gray;
            }
        }

        private void EducationTextbox_Leave(object sender, EventArgs e)
        {
            if (EducationTextbox.Text != "")
            {
                foreach (var s in EducationTextbox.Text)
                {
                    if (!Char.IsLetter(s) /*|| Convert.ToChar(s)!='-' */&& Convert.ToChar(s) != ' ')
                    {
                        MessageBox.Show("Please, to correct name of your university", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        EducationTextbox.Text = "";
                        break;
                    }
                }
            }

            if (EducationTextbox.Text == "")
            {
                EducationTextbox.Text = "Where did you study?";
                EducationTextbox.ForeColor = Color.Gray;
            }
        }

        private void JobTextbox_Leave(object sender, EventArgs e)
        {
            //проверка на написание
            if (JobTextbox.Text != "")
            {
                foreach (var s in JobTextbox.Text)
                {
                    if (!Char.IsLetter(s) /*|| Convert.ToChar(s)!='-' */&& Convert.ToChar(s) != ' ')
                    {
                        MessageBox.Show("Please, to correct name of your job", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        JobTextbox.Text = "";
                        break;
                    }
                }
            }
            if (JobTextbox.Text == "")
            {
                JobTextbox.Text = "Where did you work?";
                JobTextbox.ForeColor = Color.Gray;
            }
        }

        private void PhoneTextbox_Leave(object sender, EventArgs e)
        {
            //проверка на написание номера
            if (PhoneTextbox.Text != "")
            {
                foreach (var s in PhoneTextbox.Text)
                {   if (Convert.ToChar(s) == '+') continue;
                    else if (!Char.IsDigit(s) /*|| Convert.ToChar(s)!='-' */&& Convert.ToChar(s) != ' ')
                    {
                        MessageBox.Show("Please, to correct your phone", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PhoneTextbox.Text = "";
                        break;
                    }
                }
            }
            if (PhoneTextbox.Text == "")
            {
                PhoneTextbox.Text = "Input your phone number";
                PhoneTextbox.ForeColor = Color.Gray;
            }
        }

        private void HeightTextbox_Leave(object sender, EventArgs e)
        {
            //проверка написания чисел
            if (HeightTextbox.Text != "")
            {
                foreach (var s in HeightTextbox.Text)
                {
                    if (!Char.IsDigit(s) && Convert.ToChar(s) != ' ')
                    {
                        MessageBox.Show("Please, to correct Height", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        FromTextbox.Text = "";
                        break;
                    }
                }

                if (Convert.ToInt32(HeightTextbox.Text) > 220 || Convert.ToInt32(HeightTextbox.Text) < 100)
                {
                    MessageBox.Show("Please, to correct Height", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    HeightTextbox.Text = "";
                }
            }
            if (HeightTextbox.Text == "")
            {
                HeightTextbox.Text = "What is your height?";
                HeightTextbox.ForeColor = Color.Gray;
            }
        }

        //наступні 4 методи задають значення текстбоксам на формі при вході в них
        private void FromTextbox_Enter(object sender, EventArgs e)
        {
            if (FromTextbox.Text == "Where are you from?")
            {
                FromTextbox.Text = "";
                FromTextbox.ForeColor = Color.Black;
            }
        }

        private void EducationTextbox_Enter(object sender, EventArgs e)
        {
            if (EducationTextbox.Text == "Where did you study?")
            {
                EducationTextbox.Text = "";
                EducationTextbox.ForeColor = Color.Black;
            }
        }

        private void JobTextbox_Enter(object sender, EventArgs e)
        {
            if (JobTextbox.Text == "Where did you work?")
            {
                JobTextbox.Text = "";
                JobTextbox.ForeColor = Color.Black;
            }
        }

        private void PhoneTextbox_Enter(object sender, EventArgs e)
        {
            if (PhoneTextbox.Text == "Input your phone number")
            {
                PhoneTextbox.Text = "";
                PhoneTextbox.ForeColor = Color.Black;
            }
        }

        private void HeightTextbox_Enter(object sender, EventArgs e)
        {
            if (HeightTextbox.Text == "What is your height?")
            {
                HeightTextbox.Text = "";
                HeightTextbox.ForeColor = Color.Black;
            }
        }
    }
}
