using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.ClientUser
{
    

       //Regulus.Remoting.Ghost.IProviderNotice<GameCore.IConnect> IUser.ConnectProvider
       // {
       //     get { return _Agent.QueryProvider<GameCore.IConnect>(); }
       // }


    class Connect : Regulus.Remoting.Ghost.IProviderNotice<Terry.Project.GameCore.IConnect>, Terry.Project.GameCore.IConnect
    {
        Regulus.Remoting.Ghost.Native.Agent _Complex;
        public Connect(Regulus.Remoting.Ghost.Native.Agent complex)
        {
            _Complex = complex;
        }
        
        GameCore.IConnect[] Regulus.Remoting.Ghost.IProviderNotice<GameCore.IConnect>.Ghosts
        {
            get { return new GameCore.IConnect[] { this }; }        
        }

        event Action<GameCore.IConnect> Regulus.Remoting.Ghost.IProviderNotice<GameCore.IConnect>.Supply
        {
            add { value(this); }
            remove {}
        }

        event Action<GameCore.IConnect> Regulus.Remoting.Ghost.IProviderNotice<GameCore.IConnect>.Unsupply
        {
            add { value(this); }
            remove {}
        }

        Regulus.Remoting.Value<bool> GameCore.IConnect.Connect(string ip, int port)
        {
            return _Complex.Connect("127.0.1.1", 12345);
            //throw new NotImplementedException();
        }
    }
}
