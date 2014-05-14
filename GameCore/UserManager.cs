using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terry.Project.GameCore
{
    public class UserManager
    {
        private List<User> _UserSet;
        public UserManager()
        {
            _UserSet = new List<User>();
        }

        public void CreateUserInstance(Regulus.Remoting.ISoulBinder provider)
        {
            User user = new User(provider);

            _UserSet.Add(user);
   
            provider.BreakEvent += () => { _UserSet.Remove(user); };
        }

        public void Update()
        {
            foreach (var user in _UserSet)
            {
                user.UpdateState();
            }
        }
    }
}
