using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.GameCore
{
    class User
    {
        public Regulus.Game.StageMachine StageMachine { get; private set; } 

        public User(Regulus.Remoting.ISoulBinder provider)
        {
            StageMachine = new Regulus.Game.StageMachine();
            //_ToConnectState(provider);
            _ToLoginState(provider);
        }

        //private void _ToConnectState(Regulus.Remoting.ISoulBinder provider)
        //{
            //ConnectStates connectState = new ConnectStates(provider);
            //StageMachine.Push(connectState);

            //connectState.OnDoneEvent += () => { _ToLoginState(provider); };
        //}


        private void _ToLoginState(Regulus.Remoting.ISoulBinder provider)
        {
            LoginStates loginState = new LoginStates(provider);
            StageMachine.Push(loginState);

            loginState.OnDoneEvent += () => { _ToInGameState(provider); };
        }

        private void _ToInGameState(Regulus.Remoting.ISoulBinder provider)
        {
            InGameState inGameState = new InGameState(provider);
            StageMachine.Push(inGameState);

            inGameState.OnBackLoginEvent += () => { _ToLoginState(provider); };
        }


        internal void UpdateState()
        {
            StageMachine.Update();
        }
    }

   
}
