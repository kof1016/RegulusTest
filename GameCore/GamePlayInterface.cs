using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.GameCore
{
    public interface IIntoGame
    {
        void SayHello();
        Regulus.Remoting.Value<int> Add(int x, int y);
    }
}
