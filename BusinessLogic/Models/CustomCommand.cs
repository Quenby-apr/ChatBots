using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.Models
{
    public class CustomCommand
    {
        public string CommandName { get; set; }
        public string CommandAnswer { get; set; }

        public override string ToString()
        {
            return CommandName;
        }
    }
}
