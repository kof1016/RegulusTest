using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.User
{
    class RemotingUser : IUser
    {
        Regulus.Remoting.Ghost.Native.Agent _Complex;
        Regulus.Remoting.IAgent _Agent { get { return _Complex; } }
        Regulus.Utility.Updater _Updater;
        Terry.Project.ClientUser.Connect _Connect;

        public RemotingUser()
        {
            _Complex = new Regulus.Remoting.Ghost.Native.Agent();
            _Updater = new Regulus.Utility.Updater();

            _Connect = new ClientUser.Connect(_Complex);
        }

        
        
        Regulus.Remoting.Ghost.IProviderNotice<GameCore.IConnect> IUser.ConnectProvider
        {
            //get { return _Agent.QueryProvider<GameCore.IConnect>(); }
            get { return _Connect; }
        }
        Regulus.Remoting.Ghost.IProviderNotice<GameCore.ILogin> IUser.LoginProvider
        {
            get { return _Agent.QueryProvider<GameCore.ILogin>(); }
        }
        Regulus.Remoting.Ghost.IProviderNotice<GameCore.IInGame> IUser.IntoGameProvider
        {
            get { return _Agent.QueryProvider<GameCore.IInGame>(); }
        }
        
        bool Regulus.Utility.IUpdatable.Update()
        {
            _Updater.Update();
            return true;
        }

        void Launch()
        {
            //var val = _Complex.Connect("127.0.0.1", 12345);
            //val.OnValue += _Result;

           
        }

        //private void _Result(bool result)
        //{
        //    if (result == false)
        //    {
        //        var val = _Complex.Connect("127.0.0.1", 12345);
        //        val.OnValue += _Result;
        //        System.Diagnostics.Debug.WriteLine("link FAIL!");
        //    }
        //    else
        //    {
        //        System.Diagnostics.Debug.WriteLine("link success!");
        //    }
        //}

        void Regulus.Framework.ILaunched.Launch()
        {
            //Launch();
            _Updater.Add(_Complex);
            
        }

        void Regulus.Framework.ILaunched.Shutdown()
        {
            _Updater.Shutdown();
        }
    }
}
