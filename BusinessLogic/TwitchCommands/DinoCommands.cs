﻿using ChatBots.BusinessLogic.BusinessLogic;
using ChatBots.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ChatBots.BusinessLogic.Commands
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
        public void CreateDino(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            string dinoName = null;
            var words = msg.Split(' ');
            for (int i =0; i < words.Length; i++)
            {
                if (words[i] == "!dino" && (i+2 < words.Length))
                {
                    dinoName = words[i+2];
                }
            }
            if (string.IsNullOrEmpty(dinoName))
            {
                dinoName = userName;
            }
            client.SendMessage(_dinoLogic.CreateDino(new Herbivore(userName, dinoName)));
        }

        public void DoDinner(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            string answer = string.Empty;
            Dinozavr dino;
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                UserName = userName
            });
            if (dinos.Count() == 0)
            {
                needNewDino(userName, client);
                return;
            }
            else
            {
                dino = dinos[0];
            }
            if (dino.Busy)
            {
                client.SendMessage(userName + ", ваш динозавр ещё не вернулся, необходимо подождать");
                return;
            }
            else
            {
                if (dino is Herbivore)
                {
                    client.SendMessage(userName + ", ваш динозавр ушёл за фруктами");
                }
                if (dino is Predator)
                {
                    client.SendMessage(userName + ", ваш динозавр ушёл на охоту");
                }
                try
                {
                    answer = _dinoLogic.DoDinner(dino);
                }
                catch { }
            }
            client.SendMessage(answer);
        }

        public void CheckFruits(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            Dinozavr dino;
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                UserName = userName
            });
            if (dinos.Count() == 0)
            {
                needNewDino(userName, client);
                return;
            }
            else
            {
                dino = dinos[0];
            }
            if (dino is Herbivore)
            {
                var param = (Herbivore)dino;
                client.SendMessage(userName + ", за всё время ваш динозавр нашёл " + param.Fruits + " фруктов");
            }
            else
            {
                client.SendMessage(userName + ", у вас не травоядный динозавр");
            }
        }

        public void CheckPreys(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            Dinozavr dino;
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                UserName = userName
            });
            if (dinos.Count() == 0)
            {
                needNewDino(userName, client);
                return;
            }
            else
            {
                dino = dinos[0];
            }
            if (dino is Predator)
            {
                var param = (Predator)dino;
                client.SendMessage(userName + ", за всё время ваш динозавр поймал " + param.Preys + " других динозавров");
            }
            else
            {
                client.SendMessage(userName + ", у вас не хищный динозавр");
            }
        }

        public void UpLvl(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            Dinozavr dino;
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                UserName = userName
            });
            if (dinos.Count() == 0)
            {
                needNewDino(userName, client);
                return;
            }
            else
            {
                dino = dinos[0];
            }
            client.SendMessage(_dinoLogic.UpLvl(dino));
        }

        public void CheckLvl(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            Dinozavr dino;
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                UserName = userName
            });
            if (dinos.Count() == 0)
            {
                needNewDino(userName, client);
                return;
            }
            else
            {
                dino = dinos[0];
            }
            client.SendMessage(_dinoLogic.GetLvl(dino));
        }

        public void CheckHP(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            Dinozavr dino;
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                UserName = userName
            });
            if (dinos.Count() == 0)
            {
                needNewDino(userName, client);
                return;
            }
            else
            {
                dino = dinos[0];
            }
            client.SendMessage(userName + ", у вашего динозавра сейчас " + dino.HP + " здоровья");
        }

        public void KillDino(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            var dinos = _dinoLogic.Read(new Herbivore()
            {
                UserName = userName
            });
            if (dinos.Count() == 0)
            {
                client.SendMessage(userName + ", у вас и так нет ни единого динозавра " + Emotion.emotions["sadness"]);
                return;
            }
            else
            {
                client.SendMessage(_dinoLogic.KillDino(dinos[0]));
            }
        }

        private void needNewDino(string userName, TwitchIRCClient client)
        {
            client.SendMessage(userName + ", вам нужен свой личный динозавр! " + Emotion.emotions["dinoStandart"]);
        }
    }
}
