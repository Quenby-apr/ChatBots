using ChatBots.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.BusinessLogic
{
    public class DinoDeserialization
    {
        public Dinozavr Deserialize(string JSDino)
        {
            string[] _dinoParams = JSDino.Split(',');
            List<string> dinoParams = new List<string>();
            string discordID = null;
            foreach (var param in _dinoParams)
            {
                if (!param.Contains("DiscordID"))
                {
                    dinoParams.Add(param);
                }
                else
                {
                    discordID = param;
                }
            }
            
            if (JSDino.Contains("\"MaxHP\":300"))
            {
                Herbivore dino = new Herbivore();
                dino.Busy = Convert.ToBoolean(dinoParams[0].Substring(8));
                dino.Fruits = Convert.ToInt32(dinoParams[1].Substring(9));
                dino.HP = Convert.ToInt32(dinoParams[2].Substring(5));
                dino.Level = Convert.ToInt32(dinoParams[3].Substring(8));
                dino.MaxHP = Convert.ToInt32(dinoParams[4].Substring(8));
                dino.Name = dinoParams[5].Substring(8, dinoParams[5].Length - 8 - 1);
                dino.UserName = dinoParams[7].Substring(12, dinoParams[7].Length - 12 - 1);
                dino.XP = Convert.ToInt32(dinoParams[8].Substring(5, dinoParams[8].Length - 6));
                if (!string.IsNullOrEmpty(discordID))
                {
                    dino.DiscordID = discordID.Substring(13, discordID.Length - 9 - 5);
                }
                return dino;
            }
            else if (JSDino.Contains("\"MaxHP\":15"))
            {   
                Predator dino = new Predator();
                dino.Busy = Convert.ToBoolean(dinoParams[0].Substring(8));
                dino.HP = Convert.ToInt32(dinoParams[2].Substring(5));
                dino.Level = Convert.ToInt32(dinoParams[3].Substring(8));
                dino.MaxHP = Convert.ToInt32(dinoParams[4].Substring(8));
                dino.Name = dinoParams[5].Substring(8, dinoParams[5].Length - 8 - 1);
                dino.Preys = Convert.ToInt32(dinoParams[6].Substring(8));
                dino.UserName = dinoParams[7].Substring(12, dinoParams[7].Length - 12 - 1);
                dino.XP = Convert.ToInt32(dinoParams[8].Substring(5, dinoParams[8].Length - 6));
                if (!string.IsNullOrEmpty(discordID))
                {
                    dino.DiscordID = discordID.Substring(13, discordID.Length - 9 - 5);
                }
                return dino;
            }
            else
            {
                return null;
            }
        }
        public string FindPrey(string JSDinos)
        {
            string substring = "Name";
            var indices = new List<int>();

            int index = JSDinos.IndexOf(substring, 0);
            while (index > -1)
            {
                indices.Add(index);
                index = JSDinos.IndexOf(substring, index + substring.Length);
            }
            Random rnd = new Random();
            int value = rnd.Next(0, indices.Count());
            int val = JSDinos.IndexOf(",", indices[value]);
            return JSDinos.Substring(indices[value] + 7, val - indices[value] - 8);
        }
    }
}
