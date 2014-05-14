using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Terry.Project.GameCore
{
    class LoginStates : Regulus.Game.IStage , ILogin 
    {
        public delegate void DoneEvent();
        public event DoneEvent OnDoneEvent;

        Regulus.Remoting.ISoulBinder _Provider;
        
        public LoginStates(Regulus.Remoting.ISoulBinder provider)
        {
            _Provider = provider;
        }

        void Regulus.Game.IStage.Enter()
        {
            _Provider.Bind<ILogin>(this);
        }

        void Regulus.Game.IStage.Leave()
        {
            _Provider.Unbind<ILogin>(this);
        }

        void Regulus.Game.IStage.Update()
        {
        }

       Regulus.Remoting.Value<bool> ILogin.Login(string id, string pw)
       {
           //測試，打什麼都直接通過
           //return "Connect complete, Welcome to terry test game Server";
           OnDoneEvent();
           return true;
       }
    }
    
    class InGameState :  Regulus.Game.IStage, IInGame
    {
        Regulus.Remoting.ISoulBinder _Provider;

        public delegate void DoneEvent();
        public event DoneEvent OnBackLoginEvent;


        public InGameState(Regulus.Remoting.ISoulBinder provider)
        {
            _Provider = provider;
        }

        void Regulus.Game.IStage.Enter()
        {
            _Provider.Bind<IInGame>(this);
        }

        void Regulus.Game.IStage.Leave()
        {
            _Provider.Unbind<IInGame>(this);
        }

        void Regulus.Game.IStage.Update()
        {
        }

        Regulus.Remoting.Value<int> IInGame.Add(int x, int y)
        {
            return x + y;
        }

        Regulus.Remoting.Value<string> IInGame.Welcome()
        {
            return "Connect complete, Welcome to terry test game Server";
        }


        void IInGame.BackLoginState()
        {
            OnBackLoginEvent();
        }
    }

}
