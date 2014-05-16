using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Test
    {
        private int _i1;
        public int GetI() { return 0; }
        public void SetI(int value) { i = value; }

        int _i;
        public int i
        {
            get
            {
                return 90;
            }
            set
            {
                _i = value;
            }
        }

        public int Money { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
