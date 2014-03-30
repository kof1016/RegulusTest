using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.GameCore
{
    class PluginInstaller
    {
        private IntoGame _Intogame;
        Regulus.Remoting.ISoulBinder _Provider;

        public PluginInstaller(Regulus.Remoting.ISoulBinder provider)
        {
            _Provider = provider;
            _Intogame = new IntoGame();
        }
        public void StartInstall()
        {
            _Provider.Bind<IIntoGame>(_Intogame);
        }
        public void Uninstall()
        {
            _Provider.Unbind<IIntoGame>(_Intogame);
        }
    }


    

    


}
