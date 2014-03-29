using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.GameCore
{
    public class UserBodyCreator
    {
        private List<UserBody> _UserBodySet;
        public UserBodyCreator()
        {
            _UserBodySet = new List<UserBody>();
        }

        public void CreateUserBody(Regulus.Remoting.ISoulBinder provider)
        {
            UserBody userBody = new UserBody(provider, new PluginInstaller(provider));
            _UserBodySet.Add(userBody);

            provider.BreakEvent += () => { _UserBodySet.Remove(userBody); };
        }
    }
}
