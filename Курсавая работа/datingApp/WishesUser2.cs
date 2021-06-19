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
    public partial class WishesUser2 : Form
    {
        public WishesUser2()
        {
            InitializeComponent();

            NameUserLabel.Text = Program.User.Name;       //задамо значення NameUserLabel

            //у наступних рядках задамо початкового значення та кольору для всіх полів форми
            if (Program.User.Wishes.Height == 0) HeightTextbox.Text = "From";
            else HeightTextbox.Text = Convert.ToString(Program.User.Wishes.Height);
            HeightTextbox.ForeColor = Color.Gray;

            if(Program.User.Wishes.Height2 == 0) Height2Textbox.Text = "To";
            else Height2Textbox.Text = Convert.ToString(Program.User.Wishes.Height2);
            Height2Textbox.ForeColor = Color.Gray;

            if (Program.User.Wishes.Age == 0) AgeTextbox.Text = "From";
            else AgeTextbox.Text = Convert.ToString(Program.User.Wishes.Age);
            AgeTextbox.ForeColor = Color.Gray;

            if (Program.User.Wishes.Age2 == 0)  Age2Textbox.Text = "To";
            else Age2Textbox.Text = Convert.ToString(Program.User.Wishes.Age2);
            Age2Textbox.ForeColor = Color.Gray;

            //задамо розміри полів
            this.HeightTextbox.AutoSize = false;
            this.HeightTextbox.Size = new Size(this.HeightTextbox.Size.Width, 45);

            this.Height2Textbox.AutoSize = false;
            this.Height2Textbox.Size = new Size(this.Height2Textbox.Size.Width, 45);

            this.AgeTextbox.AutoSize = false;
            this.AgeTextbox.Size = new Size(this.AgeTextbox.Size.Width, 45);

            this.Age2Textbox.AutoSize = false;
            this.Age2Textbox.Size = new Size(this.Age2Textbox.Size.Width, 45);
        }

        private void WishesUser2_FormClosing(object sender, FormClosingEventArgs e)  //закриття программи
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

        private void Menubutton_Click(object sender, EventArgs e)
        {
            //додавання данних
            if (HeightTextbox.Text != "From")
                Program.User.Wishes.Height = Convert.ToInt32(HeightTextbox.Text);

            if (Height2Textbox.Text != "To")
                Program.User.Wishes.Height2 = Convert.ToInt32(Height2Textbox.Text);

            if (AgeTextbox.Text != "From")
                Program.User.Wishes.Age = Convert.ToInt32(AgeTextbox.Text);

            if (Age2Textbox.Text != "To")
                Program.User.Wishes.Age2 = Convert.ToInt32(Age2Textbox.Text);

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

            this.Hide();                                 //закриваемо дану форму
            MenuForm input = new MenuForm();         //сворюємо об'єкт форми Меню
            input.Show();                                //відкриваемо її           
        }

        //наступні 4 методи задають значення текстбоксам на формі при вході в них, зміна на актуальний режим
        private void HeightTextbox_Enter(object sender, EventArgs e)
        {
            if (HeightTextbox.Text == "From")
            {
                HeightTextbox.Text = "";
                HeightTextbox.ForeColor = Color.Black;
            }
        }

        private void Height2Textbox_Enter(object sender, EventArgs e)
        {
            if (Height2Textbox.Text == "To")
            {
                Height2Textbox.Text = "";
                Height2Textbox.ForeColor = Color.Black;
            }
        }

        private void AgeTextbox_Enter(object sender, EventArgs e)
        {
            if (AgeTextbox.Text == "From")
            {
                AgeTextbox.Text = "";
                AgeTextbox.ForeColor = Color.Black;
            }
        }

        private void Age2Textbox_Enter(object sender, EventArgs e)
        {
            if (Age2Textbox.Text == "To")
            {
                Age2Textbox.Text = "";
                Age2Textbox.ForeColor = Color.Black;
            }
        }

        //наступні 4 методи задають значення текстбоксам
        private void HeightTextbox_Leave(object sender, EventArgs e)
        {
            if (HeightTextbox.Text != "")
            {
                foreach (var s in HeightTextbox.Text)
                {
                    if (!Char.IsDigit(s))
                    {
                        MessageBox.Show("Please, to correct number height 'From'", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        HeightTextbox.Text = "";
                        break;
                    }
                }
            }
            if (HeightTextbox.Text == "")
            {
                HeightTextbox.Text = "From";
                HeightTextbox.ForeColor = Color.Gray;
            }
        }

        private void Height2Textbox_Leave(object sender, EventArgs e)
        {
            if (Height2Textbox.Text != "")
            {
                foreach (var s in Height2Textbox.Text)
                {
                    if (!Char.IsDigit(s))
                    {
                        MessageBox.Show("Please, to correct number Height 'To'", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Height2Textbox.Text = "";
                        break;
                    }
                }
            }
            if (Height2Textbox.Text == "")
            {
                Height2Textbox.Text = "To";
                Height2Textbox.ForeColor = Color.Gray;
            }
        }

        private void AgeTextbox_Leave(object sender, EventArgs e)
        {
            if (AgeTextbox.Text != "")
            {
                foreach (var s in AgeTextbox.Text)
                {
                    if (!Char.IsDigit(s))
                    {
                        MessageBox.Show("Please, to correct number Age 'From'", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AgeTextbox.Text = "";
                        break;
                    }
                }
            }
            if (AgeTextbox.Text == "")
            {
                AgeTextbox.Text = "From";
                AgeTextbox.ForeColor = Color.Gray;
            }
        }

        private void Age2Textbox_Leave(object sender, EventArgs e)
        {
            if (Age2Textbox.Text != "")
            {
                foreach (var s in Age2Textbox.Text)
                {
                    if (!Char.IsDigit(s))
                    {
                        MessageBox.Show("Please, to correct number Age 'To'", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Age2Textbox.Text = "";
                        break;
                    }
                }
            }
            if (Age2Textbox.Text == "")
            {
                Age2Textbox.Text = "To";
                Age2Textbox.ForeColor = Color.Gray;
            }
        }
    }
}
