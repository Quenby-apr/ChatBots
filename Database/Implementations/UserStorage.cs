using ChatBots.BusinessLogic.Models;
using ChatBots.Database.Interfaces;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.Database.Implementations
{
    public class UserStorage : IUserStorage
    {
        public FireBase db = FireBase.getInstance();

        public async Task<Dictionary<string, UserModel>> GetFullListAsync()
        {
            FirebaseResponse response = await db.client.GetAsync("Users/");
            return response.ResultAs<Dictionary<string,UserModel>>();
        }

        public async Task<UserModel> GetElementAsync(UserModel model)
        {
            FirebaseResponse response = await db.client.GetAsync("Users/" + model.Login);
            return response.ResultAs<UserModel>();
        }

        public async void InsertAsync(UserModel model)
        {
            await db.client.SetAsync("Users/" + model.Login, model);
        }

        public async void UpdateAsync(UserModel model)
        {
            await db.client.UpdateAsync("Users/" + model.Login, model);
        }
    }
}
