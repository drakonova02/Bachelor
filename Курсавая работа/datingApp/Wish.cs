using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingApp
{
    [Serializable]
    public class Wish
    {
        public string Kids { set; get; }
        public string Relation { set; get; }
        public string Religion { set; get; }
        public string Zodiac { set; get; }
        public string Smoke { set; get; }
        public string Character { set; get; }
        public string Alcogol { set; get; }
        public int Height { set; get; }
        public int Height2{ set; get; }
        public int Age { set; get; }
        public int Age2 { set; get; }

        public Wish() 
        {
            Kids = null;
            Relation = null;
            Religion = null;
            Zodiac = null;
            Smoke = null;
            Character = null;
            Alcogol = null;
            Height = 0;
            Height2 = 0;
            Age = 0;
            Age2 = 0;
        }

        public bool Ages(User user)
        {
            if ((Age == 0 || Age <= user.Age) && (Age2 == 0 || Age2 >= user.Age))
                return true;
            return false;
        }

        public bool Heightes(User user)
        {
            if ((Height == 0 || (user.Height != 0 && Height <= user.Height)) &&
                (Height2 == 0 || (Height != 0 && Height2 >= user.Height)))
                return true;
            return false;
        }

        public bool Genders(User user)
        {
            if ((Program.User.Gender == "Male" && user.Gender == "Female") ||
                (Program.User.Gender == "Female" && user.Gender == "Male") ||
                (Program.User.Gender == "Agender" && user.Gender == "Agender") ||
                 Program.User.Gender == "Androgynous" || Program.User.Gender == "Androgyne" ||
                 Program.User.Gender == "FTM" || Program.User.Gender == "MTF")
                return true;
            return false;
        }

        public bool Religions(User user)
        {
            if (Religion == null || Religion == user.Religion) return true;
            return false;
        }

        public bool Relations(User user)
        {
            if (Relation == null || Relation == user.Relation) return true;
            return false;
        }

        public bool Kid(User user)
        {
            if (Kids == null || Kids == user.Kids) return true;
            return false;
        }

        public bool Alcogols(User user)
        {
            if (Alcogol == null || Alcogol == user.Alcogol) return true;
            return false;
        }

        public bool Smokes(User user)
        {
            if (Smoke == null || Smoke == user.Smoke) return true;
            return false;
        }

        public bool Characters(User user)
        {
            if (Character == null || Character == user.Character) return true;
            return false;
        }

        public bool Zodiacs(User user)
        {
            if (Zodiac == null || Zodiac == user.Zodiac) return true;
            return false;
        }
    }
}
