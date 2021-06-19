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
    public partial class Profile : Form
    {
        int number = 0;

        public Profile()
        {
            InitializeComponent();
            //знаходимо відповідну анкету
            for (int i = Program.User.Prof; i < Program.users.count; ++i)
            {
                if (Program.User.Wishes.Ages(Program.users[i]))
                {
                    if (Program.User.Wishes.Heightes(Program.users[i]))
                    {
                        if (Program.User.Wishes.Genders(Program.users[i]))
                        {
                            if (Program.User.Wishes.Religions(Program.users[i]))
                            {
                                if (Program.User.Wishes.Relations(Program.users[i]))
                                {
                                    if (Program.User.Wishes.Kid(Program.users[i]))
                                    {
                                        if (Program.User.Wishes.Alcogols(Program.users[i]))
                                        {
                                            if (Program.User.Wishes.Smokes(Program.users[i]))
                                            {
                                                if (Program.User.Wishes.Characters(Program.users[i]))
                                                {
                                                    if (Program.User.Wishes.Zodiacs(Program.users[i]))
                                                    {
                                                        NameUserLabel.Text = Program.users[i].Name;
                                                        AgeLabel.Text = Convert.ToString(Program.users[i].Age);

                                                        if (Program.users[i].Height != 0)
                                                            HeightLabel.Text = Convert.ToString(Program.users[i].Height);
                                                        else HeightLabel.Text = "";

                                                        GenderLabel.Text = Program.users[i].Gender;
                                                        if (Program.users[i].From != null)
                                                            FromLabel.Text = Program.users[i].From;
                                                        else FromLabel.Text = "";

                                                        if (Program.users[i].Job != null)
                                                            JobLabel.Text = Program.users[i].Job;
                                                        else JobLabel.Text = "";

                                                        if (Program.users[i].Education != null)
                                                            EducationLabel.Text = Program.users[i].Education;
                                                        else EducationLabel.Text = "";

                                                        if (Program.users[i].Relation != null)
                                                            RelationLabel.Text = Program.users[i].Relation;
                                                        else RelationLabel.Text = "";

                                                        if (Program.users[i].Kids != null)
                                                            KidsLabel.Text = Program.users[i].Kids;
                                                        else KidsLabel.Text = "";

                                                        if (Program.users[i].Alcogol != null)
                                                            AlcogolLabel.Text = Program.users[i].Alcogol;
                                                        else AlcogolLabel.Text = "";

                                                        if (Program.users[i].Smoke != null)
                                                            SmokeLabel.Text = Program.users[i].Smoke;
                                                        else SmokeLabel.Text = "";

                                                        if (Program.users[i].Character != null)
                                                            CharacterLabel.Text = Program.users[i].Character;
                                                        else CharacterLabel.Text = "";

                                                        if (Program.users[i].Religion != null)
                                                            ReligionLabel.Text = Program.users[i].Religion;
                                                        else ReligionLabel.Text = "";

                                                        if (Program.users[i].Zodiac != null)
                                                            ZodiacLabel.Text = Program.users[i].Zodiac;
                                                        else ZodiacLabel.Text = "";

                                                        if (Program.users[i].Gender == "Male")
                                                            Avatar.Image = Properties.Resources.iconfinder_7_2716417;
                                                        else if (Program.users[i].Gender == "Female")
                                                            Avatar.Image = Properties.Resources._2716421_256;
                                                        else Avatar.Image = Properties.Resources._2703063_256;


                                                        number = ++i;

                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //обробка ситуації, коли немає потрібних анкет
            if (number == 0)
            {
                Avatar.Image = Properties.Resources._2703063_256;
                NameUserLabel.Text = "None";
                DialogResult dialog = MessageBox.Show(
                    "We haven`t profile to your wishes", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialog == DialogResult.OK)
                {
                    this.Hide();
                    MenuForm input = new MenuForm();
                    input.Show();
                }
            }
        }

        private void Profile_FormClosing(object sender, FormClosingEventArgs e)  //закриття программи
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

        private void MenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();                                //закрити дану форму
            MenuForm input = new MenuForm();        //створити об'єкт форми меню
            input.Show();                               //відкрити її
        }

        private void DislikeButton_Click(object sender, EventArgs e)
        {
            if (Program.users.count > Program.User.Prof)
            {
                ++Program.User.Prof;
                this.Hide();                                    //закрити форму
                Profile input = new Profile();              //створити новий об'єкт Анкета
                input.Show();                                   //відкрити її
            }
            else
            {
                MessageBox.Show(
              "List is Empty", "Information",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
                MenuButton_Click(sender, e);
            }
        }

        private void LikeButton_Click(object sender, EventArgs e)
        {
            Program.User.Add(Program.users[number - 1]);

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

            //задаємо дії далі
            if (Program.users.count - 1 > Program.User.Prof)
            {
                ++Program.User.Prof;
                this.Hide();                                    //закрити форму
                Profile input = new Profile();              //створити новий об'єкт Анкета
                input.Show();                                   //відкрити її
            }
            else
            {
                MessageBox.Show(
              "List is Empty", "Information",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
                MenuButton_Click(sender, e);
            } 
        }
    }
}