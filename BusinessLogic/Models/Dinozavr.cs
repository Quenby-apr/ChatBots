using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.Models
{
    public abstract class Dinozavr
    {
        //добавить твич/дискорд для динозавра
        public string UserName { get; set; }
        public string DiscordID { get; set; }
        public string Name { get; set; }
        public int XP { get; set; } //опыт

        public readonly static int[] levels = new int[]
        {
            5,20,40,65,90,130,170,215,260,340,500,720,960,1200,1470,1800,2230,2700,3250,3900,4700,6200,8700,12000,16500,23700,29500,35000,42000,50000,60000,70000,80000,90000,100000,120000,140000,160000,180000,200000
        };
        public int Level { get; set; }
        public int HP { get; set; } //очки здоровья
        public bool Busy { get; set; }
        public int MaxHP { get; set; }
        public int Fruits { get; set; }
        public int Preys { get; set; }
        public Dinozavr() { }
        public Dinozavr(string userName, string name)
        {
            XP = 1;
            Level = 0;
            HP = 10;
            UserName = userName;
            Name = name;
            Busy = false;
        }
    }
}
