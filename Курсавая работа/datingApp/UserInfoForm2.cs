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
    public partial class UserInfoForm2 : Form
    {
        public UserInfoForm2()
        {
            InitializeComponent();

            NameUserLabel.Text = Program.User.Name;        //задаємо значення NameUserLabel

            //у наступних рядках задамо початкового значення та кольору для всіх полів форми
            if (Program.User.Kids == null) KidsCheck.Text = "What about kids?";
            else KidsCheck.Text = Program.User.Kids;
            KidsCheck.ForeColor = Color.Gray;

            if (Program.User.Smoke == null) SmokeCheck.Text = "What about smoke?";
            else SmokeCheck.Text = Program.User.Smoke;
            SmokeCheck.ForeColor = Color.Gray;

            if (Program.User.Religion == null) ReligionCheck.Text = "What about religion?";
            else ReligionCheck.Text = Program.User.Religion;
            ReligionCheck.ForeColor = Color.Gray;

            if (Program.User.Religion == null) RelationCheck.Text = "What about relation?";
            else RelationCheck.Text = Program.User.Religion;
            RelationCheck.ForeColor = Color.Gray;

            if (Program.User.Alcogol == null) AlcogolCheck.Text = "What about alcogol?";
            else AlcogolCheck.Text = Program.User.Alcogol;
            AlcogolCheck.ForeColor = Color.Gray;

            if (Program.User.Zodiac == null) ZodiacCheck.Text = "What is your zodiac?";
            else ZodiacCheck.Text = Program.User.Zodiac;
            ZodiacCheck.ForeColor = Color.Gray;

            if (Program.User.Character == null) CharacterCheck.Text = "What is your character?";
            else CharacterCheck.Text = Program.User.Character;
            CharacterCheck.ForeColor = Color.Gray;
        }

        private void UserInfoForm2_FormClosing(object sender, FormClosingEventArgs e)   //закриття программи
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

        private void addData()
        {
            //в наступних рядках йде перевірка данних та додавання їх до елемента
            if (KidsCheck.Text != "What about kids?")
                Program.User.Kids = KidsCheck.Text;

            if (RelationCheck.Text != "What about relation?")
                Program.User.Relation = RelationCheck.Text;

            if (ReligionCheck.Text != "What about religion?")
                Program.User.Religion = ReligionCheck.Text;

            if (ZodiacCheck.Text != "What is your zodiac?")
                Program.User.Zodiac = ZodiacCheck.Text;

            if (SmokeCheck.SelectedIndex != -1)
                Program.User.Smoke = (string)SmokeCheck.SelectedItem;

            if (CharacterCheck.Text != "What is your character?")
                Program.User.Character = CharacterCheck.Text;

            if (AlcogolCheck.SelectedIndex != -1)
                Program.User.Alcogol = (string)AlcogolCheck.SelectedItem;

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

        private void Nextbutton_Click(object sender, EventArgs e)//перехід до наступної сторінки
        {
            addData();                                               //додати нові дані

            this.Hide();                                            //закрити дану форму
            WishesUser input = new WishesUser();                //створення об'єкта форми Побажання
            input.Show();                                           //відкрити її

        }

        private void Menubutton_Click(object sender, EventArgs e)
        {
            //перевірка, що це не перший вхід в систему
            if (Program.User.Wishes.Age != 0)
            {
                addData();                                              //додати нові дані

                this.Hide();                                            //закрити дану форму
                MenuForm input = new MenuForm();                    //створення об'єкта форми Меню
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

        //наступні 7 методи задають значення текстбоксам на формі при вході в них, зміна на актуальний режим
        private void KidsCheck_Enter(object sender, EventArgs e)
        {
            if (KidsCheck.Text == "What about kids?")
            {
                KidsCheck.Text = "";
                KidsCheck.ForeColor = Color.Black;
            }
        }

        private void SmokeCheck_Enter(object sender, EventArgs e)
        {
            if (SmokeCheck.Text == "What about smoke?")
            {
                SmokeCheck.Text = "";
                SmokeCheck.ForeColor = Color.Black;
            }
        }

        private void ReligionCheck_Enter(object sender, EventArgs e)
        {
            if (ReligionCheck.Text == "What about religion?")
            {
                ReligionCheck.Text = "";
                ReligionCheck.ForeColor = Color.Black;
            }
        }

        private void RealationCheck_Enter(object sender, EventArgs e)
        {
            if (RelationCheck.Text == "What about relation?")
            {
                RelationCheck.Text = "";
                RelationCheck.ForeColor = Color.Black;
            }
        }

        private void AlcogolCheck_Enter(object sender, EventArgs e)
        {
            if (AlcogolCheck.Text == "What about alcogol?")
            {
                AlcogolCheck.Text = "";
                AlcogolCheck.ForeColor = Color.Black;
            }
        }

        private void ZodiacCheck_Enter(object sender, EventArgs e)
        {
            if (ZodiacCheck.Text == "What is your zodiac?")
            {
                ZodiacCheck.Text = "";
                ZodiacCheck.ForeColor = Color.Black;
            }
        }

        private void CharacterCheck_Enter(object sender, EventArgs e)
        {
            if (CharacterCheck.Text == "What is your character?")
            {
                CharacterCheck.Text = "";
                CharacterCheck.ForeColor = Color.Black;
            }
        }

        //наступні 7 методи задають значення текстбоксам при виході з них 
        private void KidsCheck_Leave(object sender, EventArgs e)
        {
            if (KidsCheck.Text == "")
            {
                KidsCheck.Text = "What about kids?";
                KidsCheck.ForeColor = Color.Gray;
            }
        }

        private void SmokeCheck_Leave(object sender, EventArgs e)
        {
            if (SmokeCheck.Text == "")
            {
                SmokeCheck.Text = "What about smoke?";
                SmokeCheck.ForeColor = Color.Gray;
            }
        }

        private void ReligionCheck_Leave(object sender, EventArgs e)
        {
            if (ReligionCheck.Text == "")
            {
                ReligionCheck.Text = "What about religion?";
                ReligionCheck.ForeColor = Color.Gray;
            }
        }

        private void RealationCheck_Leave(object sender, EventArgs e)
        {
            if (RelationCheck.Text == "")
            {
                RelationCheck.Text = "What about relation?";
                RelationCheck.ForeColor = Color.Gray;
            }
        }

        private void AlcogolCheck_Leave(object sender, EventArgs e)
        {
            if (AlcogolCheck.Text == "")
            {
                AlcogolCheck.Text = "What about alcogol?";
                AlcogolCheck.ForeColor = Color.Gray;
            }
        }

        private void ZodiacCheck_Leave(object sender, EventArgs e)
        {
            if (ZodiacCheck.Text == "")
            {
                ZodiacCheck.Text = "What is your zodiac?";
                ZodiacCheck.ForeColor = Color.Gray;
            }
        }

        private void CharacterCheck_Leave(object sender, EventArgs e)
        {
            if (CharacterCheck.Text == "")
            {
                CharacterCheck.Text = "What is your character?";
                CharacterCheck.ForeColor = Color.Gray;
            }
        }
    }
}
