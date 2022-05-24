using ChatBots.BusinessLogic.Models;
using ChatBots.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.BusinessLogic
{
    public class ChannelLogic
    {
        private readonly IChannelStorage _channelStorage;

        public ChannelLogic(IChannelStorage channelStorage)
        {
            _channelStorage = channelStorage;
        }

        public List<ChannelModel> Read(ChannelModel model)
        {
            if (model == null)
            {
                return _channelStorage.GetFullListAsync().Result;
            }
            if (model.ChannelName.Any() && model.Type=="T")
            {
                return new List<ChannelModel> { _channelStorage.GetElementAsync(model).Result };
            }
            //ОБРАБОТКА ДЛЯ ДИСКОРДА
            return _channelStorage.GetFullListAsync().Result;
        }

        public void CreateOrUpdate(ChannelModel model)
        {
            var element = _channelStorage.GetElementAsync(new ChannelModel
            {
                ChannelName = model.ChannelName,
                Type = model.Type,
                UserName = model.UserName
            }).Result;
            if (element != null)
            {
                throw new Exception("Уже есть канал с таким названием");
            }
            if (string.IsNullOrEmpty(model.ChannelName) && (model.Type == "T"))
            {
                _channelStorage.UpdateAsync(model);
            }
            else
            {
                _channelStorage.InsertAsync(model);
            }
        }
        public void Delete(ChannelModel model)
        {
            var element = _channelStorage.GetElementAsync(new ChannelModel
            {
                ChannelName = model.ChannelName
            }).Result;
            if (element == null)
            {
                throw new Exception("Канал не найден");
            }
            _channelStorage.DeleteAsync(model);
        }
    }
}
