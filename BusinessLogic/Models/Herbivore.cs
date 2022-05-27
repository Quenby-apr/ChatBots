using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.Models
{
    public class Herbivore : Dinozavr
    {
        public int Fruits { get; set; }
        public Herbivore() { }
        public Herbivore(string userName, string name) : base(userName, name)
        {
            MaxHP = 300;
            Fruits = 0;
        }

        public override string dinner()
        {
            if (!Busy)
            {
                Busy = true;
                UpdateDinoInDB(this);
                Random rnd = new Random();
                int value = rnd.Next(0, 10);
                Thread.Sleep(5000);
                Random rnd2 = new Random();
                int xp = rnd2.Next(4, 10);
                XP += xp;
                if (value >= 8)
                {
                    Fruits++;
                    Busy = false;
                    if (HP <= MaxHP - 10)
                    {
                        HP += 10 - 1;
                    }
                    else
                    {
                        HP = MaxHP;
                    }
                    UpdateDinoInDB(this);
                    return UserName + ", ваш динозавр смог найти замечательный фрукт, поэтому восполнил себе здоровье! А также получил " + xp + " опыта " + Emotion.emotions["joy"];
                }
                else
                {
                    Busy = false;
                    HP--;
                    UpdateDinoInDB(this);
                    if (HP <= 0)
                    {
                        DeleteDinoFromDB(Name);
                        return "Динозавра " + Name + "больше нет с нами " + Emotion.emotions["sadness"];
                    }
                    return UserName + ", в этот раз фрукты найти не удалось, но мы смогли получить " + xp + " опыта " + Emotion.emotions["dropping"];

                }
            }
            if (Busy)
            {
                return UserName + ", ваш динозавр ещё не вернулся, необходимо подождать";
            }
            return "что-то пошло не так";
        }

        public override string dinner(Dinozavr prey)
        {
            throw new NotImplementedException();
        }
    }
}
