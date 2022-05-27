using ChatBots.BusinessLogic.BusinessLogic;
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
    public class DinoWorldStorage : IDinoWorldStorage
    {
        public FireBase db = FireBase.getInstance();
        public DinoDeserialization myDes = new DinoDeserialization();

        public async Task<Dictionary<string, Dinozavr>> GetFullListAsync()
        {
            FirebaseResponse response = await db.client.GetAsync("Dinozavrs/");
            return response.ResultAs<Dictionary<string, Dinozavr>>();
        }

        public async Task<Dinozavr> GetElementAsync(Dinozavr model)
        {
            FirebaseResponse response = await db.client.GetAsync("Dinozavrs/" + model.Name);
            var resp = response.Body;
            Dinozavr dino = null;
            if (resp != null)
            {
                dino = myDes.Deserialize(resp);
                return dino;
            }
            return null;
        }

        public async Task<Dinozavr> GetElementByNameAsync(string dinoName)
        {
            FirebaseResponse response = await db.client.GetAsync("Dinozavrs/" + dinoName);
            var resp = response.Body;
            Dinozavr dino = null;
            if (resp != null)
            {
                dino = myDes.Deserialize(resp);
                return dino;
            }
            return null;
        }

        public async Task<Dinozavr> GetPrey(Dinozavr model)
        {
            FirebaseResponse response = await db.client.GetAsync("Dinozavrs");
            var resp = response.Body;
            var preyName = myDes.FindPrey(resp);
            if (preyName == model.Name)
            {
                preyName = "Prey";
            }
            return GetElementByNameAsync(preyName).Result;
        }

        public async void InsertAsync(Dinozavr model)
        {
            await db.client.SetAsync("Dinozavrs/" + model.Name, model);
        }

        public async void UpdateAsync(Dinozavr model)
        {
            await db.client.UpdateAsync("Dinozavrs/" + model.Name, model);
        }

        public async void DeleteAsync(Dinozavr model)
        {
            await db.client.DeleteAsync("Dinozavrs/" + model.Name);
        }

        public async Task<Dictionary<string, List<string>>> GetFullListOwnerAsync()
        {
            FirebaseResponse response = await db.client.GetAsync("Owners/");
            return response.ResultAs<Dictionary<string, List<string>>>();
        }

        public async Task<List<string>> GetElementOwnerAsync(Dinozavr model)
        {
            FirebaseResponse response = await db.client.GetAsync("Owners/" + model.UserName);
            return response.ResultAs<List<string>>();
        }

        public async void InsertOwnerAsync(Dinozavr model)
        {
            await db.client.SetAsync("Owners/" + model.UserName, model.Name);
        }

        public async void DeleteOwnerAsync(Dinozavr model)
        {
            await db.client.DeleteAsync("Owners/" + model.UserName +"/"+model.Name);
        }
    }
}
