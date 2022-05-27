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
            var channelList = new List<ChannelModel>();
            if (model == null)
            {
                var channelDict = Task.Run(() => _channelStorage.GetFullListAsync()).Result;
                
                foreach (var element in channelDict)
                {
                    if (Program.User.Login == element.Value.UserName)
                    {
                        channelList.Add(element.Value);
                    }
                };
                return channelList;
            }
            if (!string.IsNullOrEmpty(model.ChannelName) && model.Type == "Twitch")
            {
                List<ChannelModel> result = new List<ChannelModel>();
                ChannelModel channel = Task.Run(() => _channelStorage.GetElementAsync(model)).Result;
                if (Program.User.Login == channel.UserName)
                {
                    result.Add(channel);
                }
                return result;
            }
            if (model.Type == "Twitch")
            {
                var channelDict = Task.Run(() => _channelStorage.GetFullListAsync()).Result;
                if (channelDict != null) {
                    foreach (var element in channelDict)
                    {
                        if (Program.User.Login == element.Value.UserName && element.Value.Type == "Twitch")
                        {
                            channelList.Add(element.Value);
                        }
                    };
                }
                return channelList;
            }
            if (model.Type == "Discord")
            {
                var channelDict = Task.Run(() => _channelStorage.GetFullListAsync()).Result;
                if (channelDict != null)
                {
                    foreach (var element in channelDict)
                    {
                        if (Program.User.Login == element.Value.UserName && element.Value.Type == "Discord")
                        {
                            channelList.Add(element.Value);
                        }
                    };
                }
                return channelList;
            }
           
            //ОБРАБОТКА ДЛЯ ДИСКОРДА
            return channelList;
        }

        public void CreateOrUpdate(ChannelModel model)
        {
            var element = Task.Run(() => _channelStorage.GetElementAsync(model)).Result;
            if (element != null && element.UserName != model.UserName)
            {
                throw new Exception("На данном канале бот уже установлен");
            }
            if (element != null && string.IsNullOrEmpty(model.ChannelName) && (model.Type == "Twitch"))
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
            var element = Task.Run(() => _channelStorage.GetElementAsync(new ChannelModel
            {
                ChannelName = model.ChannelName,
                Type = model.Type,
                DiscordID = model.DiscordID
            })).Result;
            if (element == null)
            {
                throw new Exception("Канал не найден");
            }
            _channelStorage.DeleteAsync(model);
        }
    }
}
