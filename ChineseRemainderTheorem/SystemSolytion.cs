using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseRemainderTheorem
{
    public class SystemSolytion
    {
        private NumberTheoryMath ntm;

        public SystemSolytion()
        {
            ntm = new NumberTheoryMath();
        }

        public long Solve(List<int> R, List<int> A)
        {
            long multi = A.Aggregate(1, (i, j) => i * j);

            long[] m = new long[A.Count];
            for (int i = 0; i < A.Count; ++i)
                m[i] = multi/A[i];

            long[] m1 = new long[A.Count];
            for (int i = 0; i < A.Count; ++i)
                m1[i] = ntm.InverseElementInRingModulo((int)m[i], A[i]);

            long X = 0;
            for (int i = 0; i < A.Count; ++i)
                X += R[i] * m[i] * m1[i] % multi;
            return X;
        }
    }
}
