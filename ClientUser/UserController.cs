using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Regulus.Extension;

namespace Terry.Project.User
{
    class UserController : ClientUserFramework.IController
    {
        IUser _RemotingUser;
        private Regulus.Utility.Console.IViewer _Viewer;
        private Regulus.Utility.Command _Command;
        private String _Name;
        event Regulus.Game.ConsoleFramework<IUser>.OnSpawnUser _UserSpawnEvent;
        private Regulus.Utility.Updater _Updater;
        

        public UserController(IUser user)
        {
            _RemotingUser = user;
            _Updater = new Regulus.Utility.Updater();
        }

        public UserController(Regulus.Utility.Console.IViewer viewer, Regulus.Utility.Command command, IUser remotingUser) :this(remotingUser)
        {
            // TODO: Complete member initialization
            this._Viewer = viewer;
            this._Command = command;


            
            //_Command.RemotingRegister<int, int, int>("Add", gpi.Add, (sum) => { view.WriteLine("=" + sum.ToString()); });

        }
        
        void Regulus.Game.ConsoleFramework<IUser>.IController.Look()
        {
            _RemotingUser.IntoGameProvider.Supply += (gpi) => 
            { 
                _Command.Register("say", gpi.SayHello);
                _Command.RemotingRegister<int, int, int>("Add", gpi.Add, (sum) => { _Viewer.WriteLine("=" + sum.ToString()); });
            };
        }
        

        string Regulus.Game.ConsoleFramework<IUser>.IController.Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        void Regulus.Game.ConsoleFramework<IUser>.IController.NotLook()
        {
            
        }

        event Regulus.Game.ConsoleFramework<IUser>.OnSpawnUser Regulus.Game.ConsoleFramework<IUser>.IController.UserSpawnEvent
        {
            add { _UserSpawnEvent += value; }
            remove { _UserSpawnEvent -= value; }
        }

        event Regulus.Game.ConsoleFramework<IUser>.OnSpawnUserFail Regulus.Game.ConsoleFramework<IUser>.IController.UserSpawnFailEvent
        {
            add {  }
            remove { }
        }

        event Regulus.Game.ConsoleFramework<IUser>.OnUnspawnUser Regulus.Game.ConsoleFramework<IUser>.IController.UserUnpawnEvent
        {
            add { }
            remove { }
        }

        bool Regulus.Utility.IUpdatable.Update()
        {
            _Updater.Update();
            return true;
        }

        void Regulus.Framework.ILaunched.Launch()
        {
            _Updater.Add(_RemotingUser);
            _UserSpawnEvent.Invoke(_RemotingUser);
        }

        void Regulus.Framework.ILaunched.Shutdown()
        {
            _Updater.Shutdown();
        }
    }
}
