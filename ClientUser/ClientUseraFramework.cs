using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.User
{
    public class ClientUserFramework : Regulus.Game.ConsoleFramework<IUser>
    {
        public ClientUserFramework(Regulus.Utility.Console.IViewer view, Regulus.Utility.Console.IInput input)
            : base(view, input)
        {
            //_Game = new Projects.SamebestKeys.Standalong.Game();
        }

        protected override Regulus.Game.ConsoleFramework<IUser>.ControllerProvider[] _ControllerProvider()
        {
            return new ControllerProvider[] 
            {                
                new ControllerProvider { Command = "remoting" , Spawn = _BuildRemoting},
                new ControllerProvider { Command = "standalong" , Spawn = _Standalong}
            };
        }

        private IController _Standalong()
        {
            return null;
            //return new UserController(_Viewer, Command, new Regulus.Projects.SamebestKeys.Standalong.StandalongUser(_Game));
            
        }

        private IController _BuildRemoting()
        {
            return new UserController(_Viewer, Command, new Terry.Project.User.RemotingUser());
        }
    }


}
