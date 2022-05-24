using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.Models
{
    public class UserModel
    {
        public string Login { get;  set; }
        public byte[] Password { get; set; }
        public string[] TwitchChannelNames { get; set; }
        public string[] DiscordChannelNames { get; set; }

    }
}
