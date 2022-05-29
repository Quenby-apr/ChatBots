using ChatBots.BusinessLogic.BusinessLogic;
using ChatBots.BusinessLogic.Commands;
using ChatBots.BusinessLogic.TwitchCommands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Unity;

namespace ChatBots.BusinessLogic
{
    public class TwitchInit
    {
        public const string Host = "irc.twitch.tv";
        public const int Port = 6667;
    }
    public class TwitchIRCClient
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly DinoLogic dinoLogic;
        private readonly GibbetLogic gibbetLogic;
        public Tuple<string, string> gibbetWord { get; private set; }
        private TcpClient client;
        private StreamReader reader;
        public List<string> commands; //сообщения чату
        private StreamWriter writer { get; }
        public string passToken { get; private set; }
        public string BotName { get; private set; }
        public string ChannelName { get; private set; }
        private List<bool> botCheckBoxes;
        private readonly int dinoWorldIndex = 2;
        private readonly int gibbetIndex = 3;
        private readonly int cleaningIndex = 4;
        private readonly int gibbetInterval = 300000;

        public Dictionary<string, Action<string, TwitchIRCClient>> answers = new Dictionary<string, Action<string, TwitchIRCClient>>();
        public TwitchIRCClient(string ChannelName, string BotName, string token, List<bool> botFunctions,
            DinoLogic dinoLogic, GibbetLogic gibbetLogic)
        {
            botCheckBoxes = botFunctions;
            this.dinoLogic = dinoLogic;
            this.gibbetLogic = gibbetLogic;
            commands = new List<string>();
            client = new TcpClient(TwitchInit.Host, TwitchInit.Port);
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());
            InitCommands();
            this.BotName = BotName;
            this.ChannelName = ChannelName;
            passToken = token;         
        }

        public void Connect()
        {
            SendCommand("PASS", passToken);
            SendCommand("USER", string.Format("{0} 0 * {0}", BotName));
            SendCommand("NICK", BotName);
            SendCommand("JOIN", "#" + ChannelName);
            SendMessage("Бот с вами");
        }

        public void CheckCommand(string msg)
        {
            foreach (var pair in answers)
            {
                if (msg.ToLower().Contains(pair.Key))
                {
                    Task.Run(() =>
                    {
                        pair.Value.Invoke(msg, this);
                    });
                    return;
                }
            }
        }

        public async void Chat(CancellationToken cancellationToken)
        {
            try
            {
                string message;
                while ((message = await reader.ReadLineAsync()) != null && !cancellationToken.IsCancellationRequested)
                {
                    if (message != null)
                    {
                        CheckCommand(message);
                        if (message == "PING :tmi.twitch.tv\r\n")
                        {
                            SendCommand("PONG", ":tmi.twitch.tv\r\n");
                            return;
                        }
                    }
                }

            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }
        public string getUserName(string msg)
        {
            int indexOfSubstring = msg.IndexOf("!");
            return msg.Substring(1, indexOfSubstring - 1);
        }
        public void SendMessage(string message)
        {
            commands.Add("PRIVMSG " + string.Format("#{0} :{1}", ChannelName, message.ToString()));
            SendCommands();
        }
        public void SendCommands()
        {
            for (int i = commands.Count - 1; i >= 0; i--)
            {
                writer.WriteLine(commands[i]);
                commands.RemoveAt(i);
                writer.Flush();
                Thread.Sleep(1000);
            }

        }
        public void SendCommand(string cmd, string param)
        {
            writer.WriteLine(cmd + " " + param);
            writer.Flush();
        }
        private void InitCommands()
        {
            InitSimpleCommands();
            InitDinoWorld();
            InitModeration();
        }

        public void InitGibbet(CancellationToken cancellationToken)
        {
            if (botCheckBoxes[gibbetIndex])
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    gibbetWord = gibbetLogic.GenerateWord();
                    answers.Add(gibbetWord.Item1, gibbetLogic.FinishRound);
                    gibbetLogic.SendWord(this, gibbetWord, cancellationToken);
                    Thread.Sleep(gibbetInterval);
                }
            }
        }

        private void InitDinoWorld()
        {      
            if (botCheckBoxes[dinoWorldIndex])
            {
                var dinoCommands = new DinoCommands(dinoLogic);
                answers.Add("!dino new", dinoCommands.CreateDino);
                answers.Add("!dino dinner", dinoCommands.DoDinner);
                answers.Add("!dino fruits", dinoCommands.CheckFruits);
                answers.Add("!dino preys", dinoCommands.CheckPreys);
                answers.Add("!dino uplvl", dinoCommands.UpLvl);
                answers.Add("!dino lvl", dinoCommands.CheckLvl);
                answers.Add("!dino hp", dinoCommands.CheckHP);
                answers.Add("!dino bye", dinoCommands.KillDino);
            }
        }
        private void InitSimpleCommands()
        {
            SimpleCommands simpleCommands = new SimpleCommands();
            if (botCheckBoxes[0])
            {
                answers.Add("!roll", simpleCommands.DoRoll);
            }
            if (botCheckBoxes[1])
            {
                answers.Add("!flip", simpleCommands.DoFlip);
            }
        }

        private void InitModeration()
        {
            if (botCheckBoxes[cleaningIndex])
            {
                CleaningLogic cleaning = new CleaningLogic();
                foreach (var element in cleaning.banWords)
                {
                    answers.Add(element, cleaning.KickUser);
                }
            }
        }
    }
}
