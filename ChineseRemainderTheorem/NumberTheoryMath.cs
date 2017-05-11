using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseRemainderTheorem
{
    public class NumberTheoryMath
    {
        public int InverseElementInRingModulo(int a, int m)
        {
            int x = 0, y = 0;
            int g = GcdEx(a, m, ref x, ref y);
            if (g != 1)
                throw new ArgumentException("No solytion");
            else
            {
                x = (x % m + m) % m;
                return x;
            }
        }

        private int GcdEx(int a, int m, ref int x, ref int y)
        {
            if (a == 0)
            {
                x = 0; y = 1;
                return m;
            }
            int x1 = 0, y1 = 0;
            int d = GcdEx(m % a, a, ref x1, ref y1);
            x = y1 - (m / a) * x1;
            y = x1;
            return d;
        }
    }
}
