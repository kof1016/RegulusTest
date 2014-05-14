using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.Server
{
    class Main : Regulus.Game.ICore
    {
        Terry.Project.GameCore.UserManager _UserManager;
        //Regulus.Utility.Updater _Updater;

        public Main()
        {
            _UserManager = new GameCore.UserManager();
        }

        void Regulus.Game.ICore.ObtainController(Regulus.Remoting.ISoulBinder binder)
        {
            _UserManager.CreateUserInstance(binder);
        }

        bool Regulus.Utility.IUpdatable.Update()
        {
            _UserManager.Update();
            return true;
        }

        void Regulus.Framework.ILaunched.Launch()
        {
        }

        void Regulus.Framework.ILaunched.Shutdown()
        {
        }
    }
}
