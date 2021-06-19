using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace datingApp
{
    [Serializable]
    [XmlRoot("UserArray")]
    public class UserArray
    {
        [XmlElement("User")]
        public User[] allUsers;

        public int count = 0;

        public void Add(User N)
        {
            ++count;
            User[] allUsersNew;
            if (allUsers == null)
            {
                allUsersNew = new User[1];
                allUsersNew[0] = N;
                allUsers = allUsersNew;
            }
            else
            {
                allUsersNew = new User[Program.users.allUsers.Length + 1];
                for (int i = 0; i < allUsers.Length; i++)
                {
                    allUsersNew[i] = allUsers[i];
                }
                allUsersNew[allUsersNew.Length - 1] = N;
                allUsers = allUsersNew;
            }
        }

        // Проверка на наличие такого пользователя в списке пользователей
        public bool IsPerson(string email, string password)
        {
            for (int i = 0; i < Program.users.allUsers.Length; i++)
            {
                if (Program.users[i].Email == email && Program.users[i].Password == password)
                    return true;
            }
            return false;
        }

        public void Delete() 
        {
            --count;
            User[] allUsersNew = new User[Program.users.allUsers.Length - 1];

            for (int i = 0, j = 0; i < Program.users.allUsers.Length - 1; i++, j++)
            {
                if (i == Program.IndexUser)
                {
                    allUsersNew[i] = Program.users.allUsers[++j];
                }
                else
                    allUsersNew[i] = Program.users.allUsers[j];
            }
            Program.users.allUsers = allUsersNew;
        }

        // Индексатор
        public User this[int index]
        {
            get
            {
                return allUsers[index];
            }
            set
            {
                allUsers[index] = value;
            }
        }
    }
}
