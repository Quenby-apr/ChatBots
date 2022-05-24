using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.Models
{
    public class UserViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string[] TwitchChannelNames { get; set; }
        public string[] DiscordChannelNames { get; set; }

    }
}
