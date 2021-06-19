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
    partial class InvitationForm : Form
    {
        private int number;
        private User[] arr;

        public InvitationForm(User[] array,int m)
        {
            InitializeComponent();

            arr = array;
            number = m;

            NameUserLabel.Text = arr[number].Name;
            if (arr[number].Phone != null)
                Phone.Text = arr[number].Phone;
            else Phone.Text = "";

            Write.Text = arr[number].Email;
        }

        private void InvitationForm_FormClosing(object sender, FormClosingEventArgs e)  //закриття программи
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

        private void NextButton_Click(object sender, EventArgs e)
        {
            //перевірка якщо остання анкета
            if (number + 1 != arr.Length)
            {
                this.Hide();
                InvitationForm input = new InvitationForm(arr ,number + 1);
                input.Show();
            }
            else MessageBox.Show(
               "It is the last profile, can`t go next", "Error",
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
