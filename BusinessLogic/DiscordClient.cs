using ChatBots.BusinessLogic.BusinessLogic;
using ChatBots.BusinessLogic.DiscordCommands;
using ChatBots.Properties;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;

namespace ChatBots.BusinessLogic
{
    public class DiscordClient
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private DiscordSocketClient client;
        private readonly DinoLogic dinoLogic;
        CleaningLogic cleaning;
        public Dictionary<string, Action<SocketCommandContext>> answers = new Dictionary<string, Action<SocketCommandContext>>();

        public DiscordClient(DinoLogic dinoLogic)
        {
            this.dinoLogic = dinoLogic;
            cleaning = new CleaningLogic();
        }

        public async Task RunBotAsync(CancellationToken cancellationToken)
        {
            client = new DiscordSocketClient();
            string token = Settings.DiscordBotToken;
            client.MessageReceived += HandleCommandAsync;
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            InitCommands();
        }

        private Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(client, message); 
            if (message.Author.IsBot)
                return Task.CompletedTask;
            foreach (var pair in answers)
            {
                if (message.Content.ToLower().Contains(pair.Key))
                {
                    Task.Run(() =>
                    {
                        pair.Value.Invoke(context);
                    });
                    if (pair.Value == cleaning.KickUser)
                    {
                        context.User.SendMessageAsync("Нехороший вы человек");
                    }
                }
            }
            return Task.CompletedTask;
        }

        private void InitCommands()
        {
            InitDinoWorld();
            InitSimpleCommands();
            InitModeration();
        }

        private void InitDinoWorld()
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
        private void InitSimpleCommands()
        {
            var simpleCommands = new SimpleCommands();
            answers.Add("!roll", simpleCommands.DoRoll);
            answers.Add("!flip", simpleCommands.DoFlip);
        }

        private void InitModeration()
        {  
            foreach (var element in cleaning.banWords)
            {
                answers.Add(element, cleaning.KickUser);
            }
        }
    }
}
