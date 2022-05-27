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
        public Herbivore() { }
        public Herbivore(string userName, string name) : base(userName, name)
        {
            MaxHP = 300;
            Fruits = 0;
        }
    }
}
