using ChatBots.BusinessLogic.BusinessLogic;
using Discord.Commands;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.DiscordCommands
{
    public class SimpleCommands
    {
        private SimpleCommandLogic logic = new SimpleCommandLogic();

        public void DoRoll(SocketCommandContext context)
        {
            var user = context.User;
            var message = context.Message.Content;
            context.Message.Channel.SendMessageAsync(logic.DoRoll(message, user.Username));
        }

        public void DoFlip(SocketCommandContext context)
        {
            var user = context.User;
            context.Message.Channel.SendMessageAsync(logic.DoFlip(user.Username));
        }
    }
}
