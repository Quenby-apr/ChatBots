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
        public void DoRoll(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            int indexOfSubstring = msg.IndexOf("#" + client.ChannelName) + client.ChannelName.Length + 2;
            msg = msg.Substring(indexOfSubstring, msg.Length - indexOfSubstring);
            List<string> numbers = Regex.Split(msg, @"\D+").ToList();
            numbers.RemoveAll(x => x == string.Empty);
            int value;
            Random rnd = new Random();
            if (int.TryParse(numbers[0], out value) && numbers[0] != int.MaxValue.ToString())
            {
                if (numbers.Count == 1)
                {
                    value = rnd.Next(0, int.Parse(numbers[0]) + 1);
                }
                else if (numbers.Count == 2 && int.TryParse(numbers[1], out value) && numbers[1] != int.MaxValue.ToString())
                {
                    if (int.Parse(numbers[0]) > int.Parse(numbers[1]))
                    {
                        string buf = numbers[1];
                        numbers[1] = numbers[0];
                        numbers[0] = buf;
                    }
                    value = rnd.Next(int.Parse(numbers[0]), int.Parse(numbers[1]) + 1);
                }
            }
            else
            {
                value = rnd.Next(0, 101);
            }

            client.SendMessage(userName + ", ваш результат: " + value.ToString());
        }

        public void DoFlip(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            Random rnd = new Random();
            int value = rnd.Next(0, 2);
            if (value == 0)
            {
                client.SendMessage(userName + ", вам выпадает Решка");
            }
            else
            {
                client.SendMessage(userName + ", вам выпадает Орёл");
            }
        }
    }
}
