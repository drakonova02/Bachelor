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
    public partial class LikesForm : Form
    {
        private int i;            //счетчик для перечислення єлементів

        public LikesForm(int m)
        {
            InitializeComponent();
            
            i = m;

            //заповнення анкет, які лайкнули
            NameUserLabel.Text = Program.User.Like[i].Name;
            AgeLabel.Text = Convert.ToString(Program.User.Like[i].Age);

            if (Program.User.Like[i].Height != 0)
                HeightLabel.Text = Convert.ToString(Program.User.Like[i].Height);
            else HeightLabel.Text = "";

            GenderLabel.Text = Program.User.Like[i].Gender;
            if (Program.User.Like[i].From != null)
                FromLabel.Text = Program.User.Like[i].From;
            else FromLabel.Text = "";

            if (Program.User.Like[i].Job != null)
                JobLabel.Text = Program.User.Like[i].Job;
            else JobLabel.Text = "";

            if (Program.User.Like[i].Education != null)
                EducationLabel.Text = Program.User.Like[i].Education;
            else EducationLabel.Text = "";

            if (Program.User.Like[i].Relation != null)
                RelationLabel.Text = Program.User.Like[i].Relation;
            else RelationLabel.Text = "";

            if (Program.User.Like[i].Kids != null)
                KidsLabel.Text = Program.User.Like[i].Kids;
            else KidsLabel.Text = "";

            if (Program.User.Like[i].Alcogol != null)
                AlcogolLabel.Text = Program.User.Like[i].Alcogol;
            else AlcogolLabel.Text = "";

            if (Program.User.Like[i].Smoke != null)
                SmokeLabel.Text = Program.User.Like[i].Smoke;
            else SmokeLabel.Text = "";

            if (Program.User.Like[i].Character != null)
                CharacterLabel.Text = Program.User.Like[i].Character;
            else CharacterLabel.Text = "";

            if (Program.User.Like[i].Religion != null)
                ReligionLabel.Text = Program.User.Like[i].Religion;
            else ReligionLabel.Text = "";

            if (Program.User.Like[i].Zodiac != null)
                ZodiacLabel.Text = Program.User.Like[i].Zodiac;
            else ZodiacLabel.Text = "";
        }

        private void LikesForm_FormClosing(object sender, FormClosingEventArgs e)  //закриття программи
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

        private void Delete_Click(object sender, EventArgs e)
        {
            //уточняем: уверен ли пользователь
            DialogResult dialog = MessageBox.Show(
               "Do you want delete this profile?", "Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                Program.User.DelLike(i);

                if (File.Exists("DataOfUser.xml"))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(UserArray));

                    // получаем поток, куда будем записывать сериализованный объект
                    using (FileStream fs = new FileStream("DataOfUser.xml", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, Program.users);
                    }
                }

                if (i == Program.User.Like.Length && i == 0) MenuButton_Click(sender, e);
                else if (i != Program.User.Like.Length) NextButton_Click(sender, e);
                else PreviousButton_Click(sender, e);
            }
        }

        private void NextButton_Click(object sender, EventArgs e)  
        {
            //перевірка якщо остання анкета
            if (i + 1 != Program.User.Like.Length)
            {
                this.Hide();
                LikesForm input = new LikesForm(i + 1);
                input.Show();
            }
            else MessageBox.Show(
               "It is the last profile, can`t go next", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            //перевірка якщо це перша анкета 
            if (i != 0)
            {
                this.Hide();
                LikesForm input = new LikesForm(i - 1);
                input.Show();
            }
            else MessageBox.Show(
               "It is the first profile, can`t go previous", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();                                //закрити дану форму
            MenuForm input = new MenuForm();        //створити об'єкт форми меню
            input.Show();                               //відкрити її
        }
    }
}
