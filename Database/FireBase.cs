using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace ChatBots.Database
{
    public class FireBase
    {
        private static FireBase instance;

        public IFirebaseClient client;
        private IFirebaseConfig config;
        private FireBase()
        {
            config = new FirebaseConfig
            {
                AuthSecret = "QEko1K97XZMZtzKKhc77Eh8EmAXwGEUSxtpie53H",
                BasePath = "https://dinoworld-474aa-default-rtdb.europe-west1.firebasedatabase.app/"
            };
            client = new FirebaseClient(config);
        }
        public static FireBase getInstance()
        {
            if (instance == null)
                instance = new FireBase();
            return instance;
        }
    }
}
