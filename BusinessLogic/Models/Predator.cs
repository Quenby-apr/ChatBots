using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.Models
{
    public class Predator : Dinozavr
    {
        public int Preys { get; set; }
        public Predator() { }
        public Predator(string userName, string name) : base(userName, name)
        {
            MaxHP = 15;
            Preys = 0;
        }

        public override string dinner(Dinozavr prey)
        {
            if (!Busy)
            {
                Busy = true;
                UpdateDinoInDB(this);
                Random rnd = new Random();
                int huntValue = rnd.Next(0, 70) + Level;
                int preyValue = rnd.Next(0, 90) + prey.Level;
                Thread.Sleep(5000);
                Random rnd2 = new Random();
                int xp = rnd2.Next(14, 28);
                XP += xp;
                UpdateDinoInDB(this);
                if (huntValue >= preyValue)
                {
                    Preys++;
                    if (HP <= MaxHP - 5)
                    {
                        HP += 5 - 1;
                    }
                    else
                    {
                        HP += MaxHP;
                    }
                    prey.HP -= 5;
                    Busy = false;
                    UpdateDinoInDB(this);
                    UpdateDinoInDB(prey);
                    if (prey.HP < 0)
                    {
                        DeleteDinoFromDB(prey.Name);
                        return "Динозавра " + prey.Name + "больше нет с нами " + Emotion.emotions["sadness"];
                    }
                    return UserName + ", ваш динозавр смог съесть динозавра " + prey.Name + "! Он восполнил себе немножко здоровья и получил " + xp + " опыта " + Emotion.emotions["predator"];
                }
                else
                {
                    HP--;
                    Busy = false;
                    UpdateDinoInDB(this);
                    if (HP < 0)
                    {
                        DeleteDinoFromDB(Name);
                        return "Динозавра " + Name + "больше нет с нами " + Emotion.emotions["sadness"];
                    }
                    Busy = false;
                    UpdateDinoInDB(this);
                    return UserName + ", ваш динозавр не смог поймать динозавра " + prey.Name + "! Но получил " + xp + " опыта " + Emotion.emotions["dropping"];
                }
            }
            if (Busy)
            {
                return UserName + ", ваш динозавр ещё не вернулся, необходимо подождать";
            }
            return "что-то пошло не так";
        }

        public override string dinner()
        {
            throw new NotImplementedException();
        }
    }
}
