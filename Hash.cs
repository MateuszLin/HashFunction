using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haszownie
{
    public class Hash
    {
        static int moduloInt = 113;
        
        public static int HashFunction(string s)
        {
            int total = 0;
            var charrArray = s.ToCharArray();

            for (int i = 0; i < charrArray.Length; i++)
            {
                total += (int)charrArray[i] * i + 1;
            }

            return total % moduloInt;
        }

    }
}
