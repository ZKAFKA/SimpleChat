using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Tap
    {
        public static string GenerateTap()
        {
            string tap = string.Empty;
            Random r = new Random();
            for(int i = 0; i < 6; ++i)
            {
                int n = r.Next(10);
                tap += n;
            }

            return tap;
        }

    }
}
