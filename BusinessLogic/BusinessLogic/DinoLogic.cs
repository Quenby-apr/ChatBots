using ChatBots.BusinessLogic.Models;
using ChatBots.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.BusinessLogic
{
    public class DinoLogic
    {
        private readonly IDinoWorldStorage _dinoWorldStorage;

        public DinoLogic(IDinoWorldStorage dinoWorldStorage)
        {
            _dinoWorldStorage = dinoWorldStorage;
        }
        public List<Dinozavr> Read(Dinozavr model)
        {
            var dinos = new List<Dinozavr>();

            if (model == null)
            {
                var dinoList = Task.Run(() => _dinoWorldStorage.GetFullListAsync()).Result;
                foreach (var element in dinoList)
                {
                    dinos.Add(element.Value);
                };
                return dinos;
            }

            if (!string.IsNullOrEmpty(model.UserName))
            {
                List<string> dinoNames = Task.Run(() => _dinoWorldStorage.GetElementOwnerAsync(model)).Result;
                foreach (var element in dinoNames)
                {
                    dinos.Add(Task.Run(() => _dinoWorldStorage.GetElementByNameAsync(element)).Result);
                };
                return dinos;
            }
            return dinos;
        }
        public string CreateDino(Dinozavr model)
        {
            List<string> dinoNames = Task.Run(() => _dinoWorldStorage.GetElementOwnerAsync(model)).Result;
            if (dinoNames.Count > 0)
                throw new Exception("У вас уже есть динозавр"); //на 1 человека 1 динозавр, в будущем можно будет убрать
            var element = Task.Run(() => _dinoWorldStorage.GetElementByNameAsync(model.Name)).Result;
            if (element != null)
            {
                throw new Exception("Динозавр с таким именем уже существует");
            }
            else
            {
                Random rand = new Random();
                int value = rand.Next(0, 4);
                if (value < 3)
                {
                    Herbivore herbivore = new Herbivore()
                    {
                        UserName = model.UserName,
                        Name = model.Name,
                        DiscordID = model.DiscordID
                    };
                    _dinoWorldStorage.InsertAsync(herbivore);
                    _dinoWorldStorage.InsertOwnerAsync(herbivore);
                    return model.UserName + ", Новый динозавр добавлен, и он травоядный " + Emotion.emotions["joy"]; //дино добавлен   
                }
                else if (value == 3)
                {
                    Predator predator = new Predator()
                    {
                        UserName = model.UserName,
                        Name = model.Name,
                        DiscordID = model.DiscordID
                    };
                    _dinoWorldStorage.InsertAsync(predator);
                    _dinoWorldStorage.InsertOwnerAsync(predator);
                    return model.UserName + ", Новый динозавр добавлен, и он хищный! " + Emotion.emotions["predator"];
                }
            }
            return "Ошибка";
        }

        public string KillDino(Dinozavr model)
        {

            Task.Run(() => _dinoWorldStorage.DeleteAsync(model));
            Task.Run(() => _dinoWorldStorage.DeleteOwnerAsync(model));
            return "Динозавра " + model.Name + " больше нет с нами";
            
        }

        public string DoDinner(Dinozavr model)
        {
            if (model is Herbivore)
            {
                return DoDinnerHerbivore(model);
            }

            if (model is Predator)
            {
                return DoDinnerPredator(model);
            }
            return "что-то пошло не так";
        }
        
        public string GetLvl(Dinozavr model)
        {
            for (int i = 0; i < Dinozavr.levels.Count(); i++)
            {
                if (Dinozavr.levels[i] > model.XP)
                {
                    if (i > model.Level)
                    {
                        return model.UserName + ", у вашего динозавра сейчас " + model.Level + " уровень и заработано " + model.XP + " опыта, вы уже можете поднять свой уровень!";
                    }
                    else
                    {
                        return model.UserName + ", у вашего динозавра сейчас " + model.Level + " уровень и заработано " + model.XP + " опыта, до следующего уровня не хватает " + (Dinozavr.levels[i] - model.XP) + " опыта";
                    }
                }
            }
            return "Ошибка логики уровня";
        }

        public string UpLvl(Dinozavr model)
        {
            for (int i = 0; i < Dinozavr.levels.Count(); i++)
            {
                if (Dinozavr.levels[i] > model.XP)
                {
                    if (i > model.Level)
                    {
                        model.Level++;
                        _dinoWorldStorage.UpdateAsync(model);
                        return model.UserName + ", поздравляю, ваш динозавр стал " + model.Level + " уровня " + Emotion.emotions["joy"];
                    }
                    else
                    {
                        return model.UserName + ", к сожалению, вы ещё не можете поднять уровень своего динозавра " + Emotion.emotions["dropping"];
                    }
                }
            }
            return "Ошибка логики поднятия уровня";
        }

        private string DoDinnerHerbivore(Dinozavr model)
        {
            if (!model.Busy)
            {
                model.Busy = true;
                Task.Run(() => _dinoWorldStorage.UpdateAsync(model));
                Random rnd = new Random();
                int value = rnd.Next(0, 10);
                Thread.Sleep(5000);
                Random rnd2 = new Random();
                int xp = rnd2.Next(4, 10);
                model.XP += xp;
                if (value >= 8)
                {
                    model.Fruits++;
                    model.Busy = false;
                    if (model.HP <= model.MaxHP - 10)
                    {
                        model.HP += 10 - 1;
                    }
                    else
                    {
                        model.HP = model.MaxHP;
                    }
                    Task.Run(() => _dinoWorldStorage.UpdateAsync(model));
                    return model.UserName + ", ваш динозавр смог найти замечательный фрукт, поэтому восполнил себе здоровье! А также получил " + xp + " опыта " + Emotion.emotions["joy"];
                }
                else
                {
                    model.Busy = false;
                    model.HP--;
                    Task.Run(() => _dinoWorldStorage.UpdateAsync(model));
                    if (model.HP <= 0)
                    {
                        Task.Run(() => _dinoWorldStorage.DeleteAsync(model));
                        Task.Run(() => _dinoWorldStorage.DeleteOwnerAsync(model));
                        return "Динозавра " + model.Name + "больше нет с нами " + Emotion.emotions["sadness"];
                    }
                    return model.UserName + ", в этот раз фрукты найти не удалось, но мы смогли получить " + xp + " опыта " + Emotion.emotions["dropping"];

                }
            }
            return "что-то пошло не так";
        }

        private string DoDinnerPredator(Dinozavr model)
        {
            var prey = Task.Run(() => _dinoWorldStorage.GetPrey(model)).Result;
            if (!model.Busy)
            {
                model.Busy = true;
                Task.Run(() => _dinoWorldStorage.UpdateAsync(model));
                Random rnd = new Random();
                int huntValue = rnd.Next(0, 70) + model.Level;
                int preyValue = rnd.Next(0, 90) + prey.Level;
                Thread.Sleep(5000);
                Random rnd2 = new Random();
                int xp = rnd2.Next(14, 28);
                model.XP += xp;
                if (huntValue >= preyValue)
                {
                    model.Preys++;
                    if (model.HP <= model.MaxHP - 5)
                    {
                        model.HP += 5 - 1;
                    }
                    else
                    {
                        model.HP += model.MaxHP;
                    }
                    prey.HP -= 5;
                    model.Busy = false;
                    Task.Run(() => _dinoWorldStorage.UpdateAsync(model));
                    Task.Run(() => _dinoWorldStorage.UpdateAsync(prey));
                    if (prey.HP < 0)
                    {
                        Task.Run(() => _dinoWorldStorage.DeleteAsync(prey));
                        Task.Run(() => _dinoWorldStorage.DeleteOwnerAsync(prey));
                        return "Динозавра " + prey.Name + "больше нет с нами " + Emotion.emotions["sadness"];
                    }
                    return model.UserName + ", ваш динозавр смог съесть динозавра " + prey.Name + "! Он восполнил себе немножко здоровья и получил " + xp + " опыта " + Emotion.emotions["predator"];
                }
                else
                {
                    model.HP--;
                    if (model.HP < 0)
                    {
                        Task.Run(() => _dinoWorldStorage.DeleteAsync(model));
                        Task.Run(() => _dinoWorldStorage.DeleteOwnerAsync(model));
                        return "Динозавра " + model.Name + "больше нет с нами " + Emotion.emotions["sadness"];
                    }
                    model.Busy = false;
                    Task.Run(() => _dinoWorldStorage.UpdateAsync(model));
                    return model.UserName + ", ваш динозавр не смог поймать динозавра " + prey.Name + "! Но получил " + xp + " опыта " + Emotion.emotions["dropping"];
                }
            }
            return "что-то пошло не так";
        }
    }
}
