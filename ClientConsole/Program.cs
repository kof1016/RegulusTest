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
            var view = new Regulus.Utility.ConsoleViewer() as Regulus.Utility.Console.IViewer;
            var input = new Regulus.Utility.ConsoleInput(view);
            var application = new Terry.Project.User.ClientUserFramework(view, input);

            Regulus.Utility.Updater updater = new Regulus.Utility.Updater();
            updater.Add(application);
            updater.Add(input);
            
            bool exit = false;
            application.Command.Register("quit", () => { exit = true; });
            
            while(exit == false)
            {
                updater.Update();
            }
            updater.Shutdown();
        }
    }
}
