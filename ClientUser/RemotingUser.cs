using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.User
{
    class RemotingUser : IUser
    {
        private Regulus.Remoting.Ghost.Native.Agent _Complex;
        private Regulus.Remoting.IAgent _Agent { get { return _Complex; } }
        private Regulus.Utility.Updater _Updater;

        public RemotingUser()
        { 
            _Complex = new Regulus.Remoting.Ghost.Native.Agent();
            _Updater = new Regulus.Utility.Updater();
        }

    

        Regulus.Remoting.Ghost.IProviderNotice<GameCore.IIntoGame> IUser.IntoGameProvider
        {
            get { return _Agent.QueryProvider<GameCore.IIntoGame>(); }
        }
        Regulus.Remoting.Ghost.IProviderNotice<GameCore.ILogin> IUser.LoginProvider
        {
            get { return _Agent.QueryProvider<GameCore.ILogin>(); }
        }
        bool Regulus.Utility.IUpdatable.Update()
        {
            _Updater.Update();
            return true;
        }

        void Regulus.Framework.ILaunched.Launch()
        {
            var val = _Complex.Connect("127.0.0.1" , 12345);
            val.OnValue += (result) => 
            {
                if(result == false)
                {
                    _Complex.Connect("127.0.0.1" , 12345);
                }
            }; 
            _Updater.Add(_Complex);
        }

        void Regulus.Framework.ILaunched.Shutdown()
        {
            _Updater.Shutdown();
        }
    }
}
