using ChatBots.BusinessLogic.Models;
using ChatBots.Database;
using ChatBots.Database.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.BusinessLogic
{
    public class UserLogic
    {
        private readonly IUserStorage _userStorage;

        public UserLogic(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public List<UserViewModel> Read(UserViewModel model)
        {
            Encoder encoder = new Encoder();
            var userViewList = new List<UserViewModel>();

            if (model == null)
            {
                var userList = Task.Run(() => _userStorage.GetFullListAsync()).Result;
                foreach (var element in userList)
                {
                    userViewList.Add(new UserViewModel()
                    {
                        Login = element.Value.Login,
                        Password = encoder.Decrypt(element.Value.Password),
                        TwitchChannelNames = element.Value.TwitchChannelNames,
                        DiscordChannelNames = element.Value.DiscordChannelNames
                    });
                };
                return userViewList;
            }

            if (model.Login.Any())
            {
                byte[] password = encoder.Encrypt(model.Password);
                UserModel user = new UserModel()
                {
                    Login = model.Login,
                    Password = password,
                    TwitchChannelNames = model.TwitchChannelNames,
                    DiscordChannelNames = model.DiscordChannelNames
                };
                var userList = new List<UserModel> { Task.Run(() => _userStorage.GetElementAsync(user)).Result};

                foreach (var element in userList)
                {
                    userViewList.Add(new UserViewModel()
                    {
                        Login = element.Login,
                        Password = encoder.Decrypt(element.Password),
                        TwitchChannelNames = element.TwitchChannelNames,
                        DiscordChannelNames = element.DiscordChannelNames
                    });
                };
            }
            return userViewList;
        }

        public void CreateOrUpdate(UserViewModel model)
        {
            Encoder encoder = new Encoder();
            byte[] password = encoder.Encrypt(model.Password);
            var element = Task.Run(() => _userStorage.GetElementAsync(new UserModel
            {
                Login = model.Login
            })).Result;
            UserModel user = new UserModel()
            {
                Login = model.Login,
                Password = password,
                TwitchChannelNames = model.TwitchChannelNames,
                DiscordChannelNames = model.DiscordChannelNames
            };
            if (element != null)
            {
                throw new Exception("Такой пользователь уже существует");
            }
            if (string.IsNullOrEmpty(model.Login))
            {
                _userStorage.UpdateAsync(user);
            }
            else
            {
                _userStorage.InsertAsync(user);
            }
        }
    }
}
