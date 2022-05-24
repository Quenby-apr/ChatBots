using ChatBots.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.Database.Interfaces
{
    public interface IUserStorage
    {
        Task<List<UserModel>> GetFullListAsync();
        Task<UserModel> GetElementAsync(UserModel model);
        void InsertAsync(UserModel model);
        void UpdateAsync(UserModel model);
    }
}
