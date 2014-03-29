using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.Server
{
    class Main : Regulus.Game.ICore
    {
        Terry.Project.GameCore.UserBodyCreator _UserBodyCreator;

        public Main()
        {
            _UserBodyCreator = new GameCore.UserBodyCreator();
        }

        void Regulus.Game.ICore.ObtainController(Regulus.Remoting.ISoulBinder binder)
        {
            _UserBodyCreator.CreateUserBody(binder);
        }

        bool Regulus.Utility.IUpdatable.Update()
        {
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
