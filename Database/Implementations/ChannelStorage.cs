using ChatBots.BusinessLogic.Models;
using ChatBots.Database.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.Database.Implementations
{
    public class ChannelStorage : IChannelStorage
    {
        public FireBase db = FireBase.getInstance();
        public async Task<Dictionary<string,ChannelModel>> GetFullListAsync()
        {
            FirebaseResponse response = await db.client.GetAsync("Channels/");
            return response.ResultAs<Dictionary<string,ChannelModel>>();
        }

        public async Task<ChannelModel> GetElementAsync(ChannelModel model)
        {
            FirebaseResponse response = await db.client.GetAsync("Channels/" + model.ChannelName + model.Type + model.DiscordID);
            return response.ResultAs<ChannelModel>();
        }

        public async void InsertAsync(ChannelModel model)
        {
            await db.client.SetAsync("Channels/" + model.ChannelName + model.Type + model.DiscordID, model);
        }

        public async void UpdateAsync(ChannelModel model)
        {
            await db.client.UpdateAsync("Channels/" + model.ChannelName + model.Type + model.DiscordID, model);
        }

        public async void DeleteAsync(ChannelModel model)
        {
            await db.client.DeleteAsync("Channels/" + model.ChannelName + model.Type + model.DiscordID);
        }
    }
}
