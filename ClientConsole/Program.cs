using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Regulus.Extension;
namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Reflection.Assembly.LoadFrom("GameCore.dll");
            var view = new Regulus.Utility.ConsoleViewer() as Regulus.Utility.Console.IViewer;
            var input = new Regulus.Utility.ConsoleInput(view);
            var application = new Terry.Project.User.ClientUserFramework(view, input);            

            Regulus.Utility.Updater updater = new Regulus.Utility.Updater();
            updater.Add(application);
            updater.Add(input);
            
            bool exit = false;
            application.Command.Register("quit", () => { exit = true; });
            application.Command.Register("sp", () => { application.Command.Run("spawncontroller" , new string[]{"1"}); });
            application.Command.Register("sl", () => { application.Command.Run("selectcontroller", new string[] { "1" }); });
            
            while(exit == false)
            {
                updater.Update();
            }
            updater.Shutdown();
        }
    }
}
