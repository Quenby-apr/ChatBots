using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.Models
{
    public class ChannelModel
    {
        public string ChannelName { get; set; }
        public string Type { get; set; }
        public string DiscordID { get; set; }
        public string UserName { get; set; }
        public bool Default { get; set; }
        public string Token { get; set; }
        public bool IsRoll { get; set; }
        public bool IsFlip { get; set; }
        public bool IsDino { get; set; }
        public bool IsGibbet { get; set; }
        public bool IsCleaning { get; set; }
        public List<CustomCommand> CustomCommands { get; set; }
        public override string ToString()
        {
            return ChannelName;
        }
    }
}
