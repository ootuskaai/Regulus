﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaUserBot
{
    class Program
    {
        private static string IPAddress;
        private static int Port;
        static void Main(string[] args)
        {
            var clientHandler = new ClientHandler(IPAddress, Port , 1);
            var view = new Regulus.Utility.ConsoleViewer();
            var input = new Regulus.Utility.ConsoleInput(view);
            var client = new VGame.Project.FishHunter.Formula.Client(view, input);
            client.ModeSelectorEvent += clientHandler.Begin;


            var updater = new Regulus.Utility.Updater();
            updater.Add(client);            

            while (client.Enable)
            {
                input.Update();
                updater.Update();
            }

            updater.Shutdown();
            clientHandler.End();
        }

        private static void _OnSelector(Regulus.Framework.GameModeSelector<VGame.Project.FishHunter.Formula.IUser> selector)
        {
            
            selector.AddFactoty("remoting", new VGame.Project.FishHunter.Formula.RemotingUserFactory());
            _OnProvider(selector.CreateUserProvider("remoting"));
            
        }

        private static void _OnProvider(Regulus.Framework.UserProvider<VGame.Project.FishHunter.Formula.IUser> userProvider)
        {
            _OnUser(userProvider.Spawn("this"));
            userProvider.Select("this");
            
        }

        private static void _OnUser(VGame.Project.FishHunter.Formula.IUser user)
        {
            user.Remoting.ConnectProvider.Supply += _Connect;
        }

        static void _Connect(Regulus.Utility.IConnect obj)
        {
            obj.Connect(IPAddress, Port);
        }

        
    }
}
