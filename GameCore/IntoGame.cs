using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.GameCore 
{
   class IntoGame : IIntoGame
   {
       void IIntoGame.SayHello()
       {
           System.Diagnostics.Debug.WriteLine("hello");
       }


       Regulus.Remoting.Value<int> IIntoGame.Add(int x, int y)
       {
           return x + y;
       }
   }
}
