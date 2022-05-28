using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.BusinessLogic
{
    public class CleaningLogic
    {
        private int banSeconds = 30;
        public List<string> banWords = new List<string> { "бот" };

        public void KickUser(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            client.SendMessage(string.Format("/timeout {0} {1}", userName, banSeconds));
        }
    }
}
