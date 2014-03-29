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


            application.UserSpawnEvent += (user) => 
            {
                
                
                _RegisterCommand(user, application.Command , view);
            };
            
            while(exit == false)
            {
                updater.Update();
            }
            updater.Shutdown();

        }

        private static void _RegisterCommand(Terry.Project.User.IUser user, Regulus.Utility.Command command, Regulus.Utility.Console.IViewer view)
        {
            user.IntoGameProvider.Supply += (gpi) => _IntoGameProvider_Supply(gpi,command , view);
        }

        private static void _IntoGameProvider_Supply(Terry.Project.GameCore.IIntoGame gpi, Regulus.Utility.Command command, Regulus.Utility.Console.IViewer view)
        {
            command.Register("say" , gpi.SayHello );
            command.RemotingRegister<int, int, int>("Add", gpi.Add, (sum) => { view.WriteLine("=" + sum.ToString() ); });
        }
    }
}
