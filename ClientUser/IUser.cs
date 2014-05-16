using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.User
{
    public interface IUser : Regulus.Utility.IUpdatable
    {
        Regulus.Remoting.Ghost.IProviderNotice<Terry.Project.GameCore.IConnect> ConnectProvider { get; }
        Regulus.Remoting.Ghost.IProviderNotice<Terry.Project.GameCore.ILogin> LoginProvider { get; }
        Regulus.Remoting.Ghost.IProviderNotice<Terry.Project.GameCore.IInGame> IntoGameProvider { get; }
    }
}
