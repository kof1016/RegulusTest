using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.GameCore 
{
   class IntoGame : IIntoGame
   {
       Regulus.Remoting.Value<int> IIntoGame.Add(int x, int y)
       {
           return x + y;
       }
       
       Regulus.Remoting.Value<string> IIntoGame.Welcome()
       {
           return "Connect complete, Welcome to terry test game Server";
       }
   }

   class Login : ILogin
   {
       Regulus.Remoting.Value<bool> ILogin.Login(string id, string pw)
       {
           //測試，打什麼都直接通過
           return true;
       }
   }
}
