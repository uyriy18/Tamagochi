using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi
{
    class Pet
    {
        int Health = 100;
        int Fullness = 100;
        int Happyess = 100;
        Random rand = new Random();

        public int feed()
        {
            return Fullness += 10;
        }
        public int play()
        {
            return Happyess += 10;
        }
        public int treat()
        {
            return Health += 10;
        }
        public void resurect()
        {
            Health = 100;
            Happyess = 100;
            Fullness = 100;
        }
        public string checkState()
        {
            switch (rand.Next(0, 4))
            {
                case (1):
                    Health -= 10;
                    break;
                case (2):
                    Fullness -= 10;
                    break;
                case (3):
                    Happyess -= 10;
                    break;
                default:
                    break;
            }
            if(Fullness == 0 || Happyess == 0 || Health == 0)
            {
                return "Kim is Dead";
            }
            if(Fullness < 50)
            {
                return "Kim is Hungry";
            }
            if(Happyess < 50)
            {
                return "Kim is Sad";
            }
            if(Health < 50)
            {
                return "Kim is Ill";
            }
            return "Kim is Healthy";
        }
        public int pHealth()
        {
            return Health;
        }
        public int pHappyness()
        {
            return Happyess;
        }
        public int pFullness()
        {
            return Fullness;
        }
    }
}
