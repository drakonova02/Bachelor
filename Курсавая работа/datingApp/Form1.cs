using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace datingApp
{
    public partial class MeetShipForm : Form
    {
        //стандартний конструктор
        public MeetShipForm()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // підтвердження про закриття за допомогою діалогового вікна

            DialogResult dialog = MessageBox.Show(
             "Do you want go out?", "Exit",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                Environment.Exit(0);        // вихід з програми
            }
            else
            {
                e.Cancel = true;            //продовжити сесію, зупинити дію закривання
            }
        }

        private void buttonSignIn_Click(object sender, EventArgs e) //відкриття форми Вхід
        {
            this.Hide();                                //закриття даної форми
            SignInForm input = new SignInForm();        //створення об'єкта форми Вхід
            input.Show();                               //відкриття її
        }

        private void buttonSignUp_Click(object sender, EventArgs e) //відкриття форми Регістрація
        {
            this.Hide();                                //закриття даної форми
            JoinIn input = new JoinIn();                //створення об'єкта форми Регістація
            input.Show();                               //відкриття її
        }
    }
}
