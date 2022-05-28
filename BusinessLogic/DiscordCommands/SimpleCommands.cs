using ChatBots.BusinessLogic.BusinessLogic;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.DiscordCommands
{
    public class SimpleCommands : ModuleBase<SocketCommandContext>
    {
        private SimpleCommandLogic logic = new SimpleCommandLogic();

        [Command("roll")]
        public async Task DoRoll()
        {
            var user = Context.User;
            var message = Context.Message;
            await ReplyAsync(logic.DoRoll(message.ToString(), user.Username));
        }

        [Command("flip")]
        public async Task DoFlip()
        {
            var user = Context.User;
            await ReplyAsync(logic.DoFlip(user.Username));
        }
    }
}
