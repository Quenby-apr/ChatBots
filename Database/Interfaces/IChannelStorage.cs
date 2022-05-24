using ChatBots.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.Database.Interfaces
{
    public interface IChannelStorage
    {
        Task<Dictionary<string, ChannelModel>> GetFullListAsync();
        Task<ChannelModel> GetElementAsync(ChannelModel model);
        void InsertAsync(ChannelModel model);
        void UpdateAsync(ChannelModel model);
        void DeleteAsync(ChannelModel model);
    }
}
