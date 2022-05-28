using ChatBots.BusinessLogic.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.TwitchCommands
{
    public class SimpleCommands
    {
        private SimpleCommandLogic logic = new SimpleCommandLogic();
        public void DoRoll(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            int indexOfSubstring = msg.IndexOf("#" + client.ChannelName) + client.ChannelName.Length + 2;
            msg = msg.Substring(indexOfSubstring, msg.Length - indexOfSubstring);
            client.SendMessage(logic.DoRoll(msg, userName));
        }

        public void DoFlip(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            client.SendMessage(logic.DoFlip(userName));

        }
    }
}
