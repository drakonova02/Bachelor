using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace datingApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        // Создаём экземпляр класса NumismatistsArray, который будет хранить данные пользователей. 
        public static UserArray users;

        // Создаём экземпляр класса Numismatist, который будет хранить данные авторизовавшегося пользователя. 
        public static User User = new User();

        public static int IndexUser;

        [STAThread]
        static void Main()
        {
            if (File.Exists("DataOfUser.xml"))
            {
                users = null;
                XmlSerializer serializer = new XmlSerializer(typeof(UserArray));
                using (FileStream fs = new FileStream("DataOfUser.xml", FileMode.OpenOrCreate))
                {
                    users = (UserArray)serializer.Deserialize(fs);
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MeetShipForm());
        }
    }
}
