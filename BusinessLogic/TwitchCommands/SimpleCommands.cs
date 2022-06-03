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
        public Dictionary<string, string> Commands { get; set; }

        private SimpleCommandLogic logic;
        public SimpleCommands()
        {
            Commands = new Dictionary<string, string>();
            logic = new SimpleCommandLogic();
        }
        
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

        public void ExecuteCustomCommand(string msg, TwitchIRCClient client)
        {
            string answer;
            foreach(var comm in Commands)
            {
                if (msg.Contains(comm.Key)) {
                    answer = Commands[comm.Key];
                    client.SendMessage(answer);
                    return;
                }
            }
            
        }
    }
}
