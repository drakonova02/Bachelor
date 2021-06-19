using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace datingApp
{
    [Serializable]
    public class User
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Email { get;set; }
        public string Password { get; set; }
        public int Age { set; get; }
        public string Gender { set; get; }
        public string From { set; get; }
        public string Education { set; get; }
        public string Job { set; get; }
        public string Phone { set; get; }
        public int Height { set; get; }
        public string Kids { set; get; }
        public string Relation { set; get; }
        public string Religion { set; get; }
        public string Zodiac { set; get; }
        public string Smoke { set; get; }
        public string Character { set; get; }
        public string Alcogol { set; get; }
        public int Prof { set; get; }
        public User[] Like;
        public Wish Wishes;

        //конструктор класса Пользователь
        public User(string name, string email, string password, int age, string gender)
        {
            if (Program.users.count == 0) Number = 1;
            else Number = Program.users[Program.users.count - 1].Number + 1;
            Name = name;
            Email = email;
            Password = password;
            Age = age;
            Gender = gender;
            From = null;
            Education = null;
            Job = null;
            Phone = null;
            Height = 0;
            Kids = null;
            Relation = null;
            Religion = null;
            Zodiac = null;
            Smoke = null;
            Character = null;
            Alcogol = null;
            Like = null;
            Wishes = new Wish();
            Prof = 0;
        }

        //конструктор класса Пользователь
        public User()
        {
            Number = 0;
            Name = null;
            Email = null;
            Password = null;
            Age = 0;
            Gender = null;
            From = null;
            Phone = null;
            Education = null;
            Job = null;
            Height = 0;
            Kids = null;
            Relation = null;
            Religion = null;
            Zodiac = null;
            Smoke = null;
            Character = null;
            Alcogol = null;
            Like = null;
            Prof = 0;
            Wishes = null;
        }

        public void Add(User u)
        {
            User[] LikeNew;
            if (Like == null)
            {
                LikeNew = new User[1];
                LikeNew[0] = u;
                Like = LikeNew;
            }
            else
            {
                LikeNew = new User[Like.Length + 1];
                for (int i = 0; i < Like.Length; i++)
                {
                    LikeNew[i] = Like[i];
                }
                LikeNew[LikeNew.Length - 1] = u;
                Like = LikeNew;
            }
        }

        // Проверка на наличие такого пользователя в списке пользователей
        public int UserInd(string email)
        {
            for (int i = 0; i < Program.users.count; i++)
            {
                if (Program.users[i].Email == email)
                    return i;
            }
            return -1;
        }

        public void DelLike(int indexLike)
        {
            User[] userNew = new User[Program.users[Program.IndexUser].Like.Length - 1];

            for (int i = 0, j = 0; i < Program.users[Program.IndexUser].Like.Length - 1; i++, j++)
            {
                if (i == indexLike)
                {
                    userNew[i] = Program.users[Program.IndexUser].Like[++j];
                }
                else
                    userNew[i] = Program.users[Program.IndexUser].Like[j];
            }
            Program.users[Program.IndexUser].Like = userNew;

        }
    }
}
