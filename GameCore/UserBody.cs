using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.GameCore
{
    class UserBody
    {
        private Regulus.Remoting.ISoulBinder _Provider;
        public UserBody(Regulus.Remoting.ISoulBinder provider, PluginInstaller pluginInstaller)
        {
            this._Provider = provider;
            pluginInstaller.StartInstall();
        }
    }

   
}
