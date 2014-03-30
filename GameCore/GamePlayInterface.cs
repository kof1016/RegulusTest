using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.GameCore
{
    public interface IIntoGame
    {
        Regulus.Remoting.Value<int> Add(int x, int y);

        Regulus.Remoting.Value<String> Welcome();
    }

    public interface ILogin
    {
        Regulus.Remoting.Value<bool> Login(string id, string pw);
    }
}
