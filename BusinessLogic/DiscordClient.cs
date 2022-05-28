using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic
{
    public class DiscordClient
    {
        private DiscordSocketClient client;
        private CommandService commands;
        private IServiceProvider services;

        public async Task RunBotAsync()
        {
            client = new DiscordSocketClient();
            commands = new CommandService();

            services = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(commands)
                .BuildServiceProvider();

            string token = "OTU2MTczNTEyOTE2MjA1NTk4.GSlcYg.tqmQ2ewL-JCY2sTRVNyp-dEG_gAq2QDOfPuWi8";

            client.Log += clientLog;

            client.MessageReceived += HandleCommandAsync;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), services);
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(client, message);
            if (message.Author.IsBot)
                return;

            int argPos = 0;
            if (message.HasStringPrefix("!", ref argPos))
            {
                var result = await commands.ExecuteAsync(context, argPos, services);
                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);
                if (result.Error.Equals(CommandError.UnmetPrecondition))
                    await message.Channel.SendMessageAsync(result.ErrorReason);
            }
        }

        private Task clientLog(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }
    }
}
