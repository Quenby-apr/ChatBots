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
        public Predator() { }
        public Predator(string userName, string name) : base(userName, name)
        {
            MaxHP = 15;
            Preys = 0;
        }
    }
}
