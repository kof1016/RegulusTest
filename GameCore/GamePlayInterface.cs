using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.GameCore
{
    public interface IConnect
    {
        Regulus.Remoting.Value<bool> Connect(string ip, int port);
    }

    public interface ILogin
    {
        Regulus.Remoting.Value<bool> Login(string id, string pw);
    }

    public interface IInGame
    {
        Regulus.Remoting.Value<int> Add(int x, int y);

        Regulus.Remoting.Value<String> Welcome();

        void BackLoginState();
    }

    


}
