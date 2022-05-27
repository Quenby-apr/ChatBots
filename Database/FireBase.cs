using ChatBots.Properties;
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
                AuthSecret = Settings.AuthSecretFirebase,
                BasePath = Settings.FirebasePath
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
