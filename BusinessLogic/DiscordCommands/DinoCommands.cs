using ChatBots.BusinessLogic.BusinessLogic;
using ChatBots.BusinessLogic.Models;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ChatBots.BusinessLogic.DiscordCommands
{
    public class DinoCommands
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private DinoLogic _dinoLogic;

        public DinoCommands(DinoLogic dinoLogic)
        {
            _dinoLogic = dinoLogic;
        }
        public void CreateDino(SocketCommandContext context)
        {
            string userName = context.User.Username;
            string dinoName = null;
            var words = context.Message.Content.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "!dino" && (i + 2 < words.Length))
                {
                    dinoName = words[i + 2];
                    Console.WriteLine("имя диза " + dinoName);
                }
                if (words[i] == "!dino" && (i + 3 < words.Length))
                {
                    userName = words[i + 3];
                    Console.WriteLine("имя хоза " + userName);
                }
            }
            if (string.IsNullOrEmpty(dinoName))
            {
                dinoName = userName;
            }
            string  answer = _dinoLogic.CreateDino(new Herbivore(userName, dinoName)
            {
                DiscordID = context.User.Id.ToString()
            });
            context.Message.Channel.SendMessageAsync(userName + ", "+CleanMessage(answer));
        }

        public void DoDinner(SocketCommandContext context)
        {
            string userName = context.User.Username;
            string answer = string.Empty;
            Dinozavr dino;
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                DiscordID = context.User.Id.ToString()
            });
            if (dinos.Count() == 0)
            {
                NeedNewDino(context);
                return;
            }
            else
            {
                dino = dinos[0];
            }
            if (dino.Busy)
            {
                context.Message.Channel.SendMessageAsync(userName + ", " + dino.Name + " ещё не вернулся, необходимо подождать");
                return;
            }
            else
            {
                if (dino is Herbivore)
                {
                    context.Message.Channel.SendMessageAsync(userName + ", " + dino.Name + " ушёл за фруктами");
                }
                if (dino is Predator)
                {
                    context.Message.Channel.SendMessageAsync(userName + ", " + dino.Name + " ушёл на охоту");
                }
                try
                {
                    answer = _dinoLogic.DoDinner(dino);
                }
                catch { }
            }
            context.Message.Channel.SendMessageAsync(userName + ", " + CleanMessage(answer));
        }

        public void CheckFruits(SocketCommandContext context)
        {
            string userName = context.User.Username;
            Dinozavr dino;
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                DiscordID = context.User.Id.ToString()
            });
            if (dinos.Count() == 0)
            {
                NeedNewDino(context);
                return;
            }
            else
            {
                dino = dinos[0];
            }
            if (dino is Herbivore)
            {
                var param = (Herbivore)dino;
                context.Message.Channel.SendMessageAsync(userName + ", за всё время " + dino.Name + " нашёл " + param.Fruits + " фруктов");
            }
            else
            {
                context.Message.Channel.SendMessageAsync(userName + ", у вас не травоядный динозавр");
            }
        }

        public void CheckPreys(SocketCommandContext context)
        {
            string userName = context.User.Username;
            Dinozavr dino;
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                DiscordID = context.User.Id.ToString()
            });
            if (dinos.Count() == 0)
            {
                NeedNewDino(context);
                return;
            }
            else
            {
                dino = dinos[0];
            }
            if (dino is Predator)
            {
                var param = (Predator)dino;
                context.Message.Channel.SendMessageAsync(userName + ", за всё время " + dino.Name + " поймал " + param.Preys + " других динозавров");
            }
            else
            {
                context.Message.Channel.SendMessageAsync(userName + ", у вас не хищный динозавр");
            }
        }

        public void UpLvl(SocketCommandContext context)
        {
            string userName = context.User.Username;
            Dinozavr dino;
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                DiscordID = context.User.Id.ToString()
            });
            if (dinos.Count() == 0)
            {
                NeedNewDino(context);
                return;
            }
            else
            {
                dino = dinos[0];
            }
            context.Message.Channel.SendMessageAsync(userName + ", " + CleanMessage(_dinoLogic.UpLvl(dino)));
        }

        public void CheckLvl(SocketCommandContext context)
        {
            string userName = context.User.Username;
            Dinozavr dino;
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                DiscordID = context.User.Id.ToString()
            });
            if (dinos.Count() == 0)
            {
                NeedNewDino(context);
                return;
            }
            else
            {
                dino = dinos[0];
            }
            context.Message.Channel.SendMessageAsync(userName + ", " + CleanMessage(_dinoLogic.GetLvl(dino)));
        }

        public void CheckHP(SocketCommandContext context)
        {
            string userName = context.User.Username;
            Dinozavr dino;
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                DiscordID = context.User.Id.ToString()
            });
            if (dinos.Count() == 0)
            {
                NeedNewDino(context);
                return;
            }
            else
            {
                dino = dinos[0];
            }
            context.Message.Channel.SendMessageAsync(userName + ", у " + dino.Name + " сейчас " + dino.HP + " здоровья");
        }

        public void KillDino(SocketCommandContext context)
        {
            string userName = context.User.Username;
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                DiscordID = context.User.Id.ToString()
            });
            if (dinos.Count() == 0)
            {
                context.Message.Channel.SendMessageAsync(userName + ", у вас и так нет ни единого динозавра");
                return;
            }
            else
            {
                context.Message.Channel.SendMessageAsync(userName + ", " + CleanMessage(_dinoLogic.KillDino(dinos[0])));
            }
        }

        private void NeedNewDino(SocketCommandContext context)
        {
            context.Message.Channel.SendMessageAsync(context.User.Username + ", вам нужен свой личный динозавр!");
        }

        private string CleanMessage(string text)
        {
            var toClip = Emotion.emotions;
            foreach (var str in toClip)
            {
                text = text.Replace(str.Value, "");
            }
            return text;
        }
    }
}
