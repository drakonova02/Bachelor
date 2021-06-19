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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();

            NameUserLabel.Text = Program.User.Name;                               //задамо значення NameUserLabel

            //задамо значення Avatar
            if (Program.User.Gender == "Male")
                Avatar.Image = Properties.Resources.iconfinder_7_2716417;
            else if (Program.User.Gender == "Female")
                Avatar.Image = Properties.Resources._2716421_256;
            else Avatar.Image = Properties.Resources._2703063_256;
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)  //закриття программи
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

        private void Infobutton_Click(object sender, EventArgs e)   //перейти до інформації про юзера
        {
            this.Hide();                                        //закрити дану форму
            UserInfoForm input = new UserInfoForm();            //створити об'єкт форми Інформація
            input.Show();                                       //відкрити її
        }

        private void Wishesbutton_Click(object sender, EventArgs e)    //перейти до Побажань юзера
        {
            this.Hide();                                        //закрити дану форму
            WishesUser input = new WishesUser();                //створити об'єкт форми Побажання
            input.Show();                                       //відкрити її
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //виводимо вікно переконання у побажанні юзера
            DialogResult dialog = MessageBox.Show(
               "Do you want delete your account?", "Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                //видалення елементу
                Program.users.Delete();

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

                this.Hide();                                    //закрити дану форму
                MeetShipForm input = new MeetShipForm();        //створити об'єкт форми Заставки
                input.Show();                                   //відкрити її
            }
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            bool a = true;

            //перевірити наявність необроблених анкет
            for (int i = 0; i < Program.users.allUsers.Length; ++i)
            {
                if (Program.users[i].Number - 1 >= Program.User.Prof && Program.User != Program.users[i])
                {
                    if (Program.User.Like != null && Program.User.Like.Length != 0)
                        for (int j = 0; j < Program.User.Like.Length; ++j)
                        {
                            if (Program.User.Like[j].Number != Program.users[i].Number)
                            {
                                Program.User.Prof = Program.users[i].Number - 1;
                                this.Hide();                                                   //закрити дану форму 
                                Profile input = new Profile();                                 //створити об'єкт форми Анкети
                                input.Show();                                                 //відкрити її
                                a = false;
                                break;
                            }
                        }
                    else {
                        Program.User.Prof = Program.users[i].Number - 1;
                        this.Hide();                                                   //закрити дану форму 
                        Profile input = new Profile();                                 //створити об'єкт форми Анкети
                        input.Show();                                                 //відкрити її
                        a = false;
                        break;
                    }
                    if (!a) break;
                }
            }

            //вивести повідомлення, що немає необроблених анкет
            if (a)
            {
                MessageBox.Show(
                "List of profile is empty. Come in later.", "Info",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void LikeButton_Click(object sender, EventArgs e)
        {
            if (Program.User.Like != null && Program.User.Like.Length != 0)
                for (int i = 0; i < Program.User.Like.Length; ++i)
                    if (Program.User.Like[i] == null) Program.User.DelLike(i--);

            //якщо не існує елементу Like та Human
            if (Program.User.Like != null && Program.User.Like.Length != 0)
            {
                this.Hide();                                //закрити дану форму 
                LikesForm input = new LikesForm(0);          //створити об'єкт форми Лайк
                input.Show();                               //відкрити її
            }
            else
            {
                MessageBox.Show(
                      "List of your likes is empty. Give your like smb.", "Info",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InvitationButton_Click(object sender, EventArgs e)
        {
            if (Program.User.Like != null && Program.User.Like.Length != 0)
                for (int i = 0; i < Program.User.Like.Length; ++i)
                    if (Program.User.Like[i] == null) Program.User.DelLike(i--);

            if (Program.User.Like != null && Program.User.Like.Length != 0)
            {
                User[] arr = new User[Program.User.Like.Length];
                int n = 0;

                //знайти взаімний лайк
                for (int i = 0; i < Program.User.Like.Length; ++i)
                {
                    if (Program.users[Program.User.UserInd(Program.User.Like[i].Email)].Like != null && Program.users[Program.User.UserInd(Program.User.Like[i].Email)].Like.Length != 0)
                        for (int j = 0; j < Program.users[Program.User.UserInd(Program.User.Like[i].Email)].Like.Length; ++j)
                            if (Program.users[Program.User.UserInd(Program.User.Like[i].Email)].Like[j].Number == Program.User.Number)
                                arr[n++] = Program.User.Like[i];
                }
                if (arr.Length == 0) MessageBox.Show(
                      "List of profile is empty. Come in later.", "Info",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    this.Hide();                                                //закрити форму
                    InvitationForm input = new InvitationForm(arr, 0);          //створити об'єкт форми Запрошення
                    input.Show();
                }
            }
            else {
                MessageBox.Show(
                "List of your likes is empty. Give your like smb.", "Info",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Program.User.Prof = 0;
            MessageBox.Show(
                      "Done.", "Info",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
    }
}
