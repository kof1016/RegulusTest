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
        

        public UserController(IUser user)
        {
            _RemotingUser = user;
            _Updater = new Regulus.Utility.Updater();
        }

        public UserController(Regulus.Utility.Console.IViewer viewer, Regulus.Utility.Command command, IUser remotingUser) 
            :this(remotingUser)
        {
            this._Viewer = viewer;
            this._Command = command;
        }
        
        void Regulus.Game.ConsoleFramework<IUser>.IController.Look()
        {
            try
            {
                _RemotingUser.IntoGameProvider.Supply += (gpi) =>
                {
                    _Command.RemotingRegister<int, int, int>("Add", gpi.Add, (sum) => { _Viewer.WriteLine("=" + sum.ToString()); });
                    _Command.RemotingRegister<String>("IntoServer", gpi.Welcome, (messgae) => { _Viewer.WriteLine(messgae); });
                    
                };

                _RemotingUser.LoginProvider.Supply += (gpi) =>
                {
                    _Command.RemotingRegister<string, string, bool>("Login", gpi.Login, (var) => { if (var) _Viewer.WriteLine("登錄成功"); });
                };
            }
            catch(SystemException se)
            {

            }
            
        }
        
        void Regulus.Game.ConsoleFramework<IUser>.IController.NotLook()
        {
            _Viewer.WriteLine("切換user" + _Name);
            //移除所有命令
            //_UserCommand.Unregister(_User);
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
