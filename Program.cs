using ChatBots.BusinessLogic.BusinessLogic;
using ChatBots.BusinessLogic.Models;
using ChatBots.Database.Implementations;
using ChatBots.Database.Interfaces;
using ChatBots.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace ChatBots
{
    public static class Program
    {
        public static UserViewModel User { get; set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<SignInForm>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IChannelStorage, ChannelStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IUserStorage, UserStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDinoWorldStorage, DinoWorldStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ChannelLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<DinoLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<UserLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<Encoder>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
