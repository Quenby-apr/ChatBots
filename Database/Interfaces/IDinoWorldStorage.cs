using ChatBots.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBots.Database.Interfaces
{
    public interface IDinoWorldStorage
    {
        Task<Dictionary<string, Dinozavr>> GetFullListAsync();
        Task<Dinozavr> GetElementAsync(Dinozavr model);
        Task<Dinozavr> GetElementByNameAsync(string dinoName);
        Task<Dinozavr> GetPrey(Dinozavr model);
        void InsertAsync(Dinozavr model);
        void UpdateAsync(Dinozavr model);
        void DeleteAsync(Dinozavr model);

        Task<Dictionary<string, List<string>>> GetFullListOwnerAsync();
        Task<string> GetElementOwnerAsync(Dinozavr model);
        void InsertOwnerAsync(Dinozavr model);
        void DeleteOwnerAsync(Dinozavr model);
    }
}
