using System;

namespace PrimalityTestsDemo
{
    public class PrimalityTest
    {
        public bool Fermat(Int64 n, Int64 accuracy = 100)
        {
            if (n < 1)
                throw new ArgumentException("The number must be natural");

            if (n == 1 || n == 2)
                return true;

            Random rnd = new Random();
            bool isPrime = true;
            for (Int64 i = 0; i < accuracy; ++i)
            {
                Int64 a = rnd.Next(2, (int)n);
                if ((BinaryMath.Gcd(n, a) != 1 && !(BinaryMath.Gcd(n, a) == n)) 
                    || BinaryMath.PowByModulo(a, n - 1, n) != 1)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }

        public bool SolovayStrassen(Int64 n, Int64 accuracy = 1)
        {
            if (n < 1)
                throw new ArgumentException("The number must be natural");

            if (n == 1 || n == 2)
                return true;
            
            Random rnd = new Random();
            bool isPrime = true;
            for (Int64 i = 1; i <= accuracy; ++i)
            {
                Int64 a = rnd.Next(2, (int)n + 1);
                long lez = SymbolLegendre.Calculate(a, n);
                if (lez == -1)
                    lez += n;

                if (BinaryMath.Gcd(a, n) > 1 || BinaryMath.PowByModulo(a, (n - 1) / 2, n) % n != lez)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }

        public bool MillerRabin(Int64 n, Int64 accuracy = 100)
        {
            if (n < 1)
                throw new ArgumentException("The number must be natural");

            if (n == 1 || n == 2)
                return true;

            if (n % 2 == 0)
                return false;

            Tuple<Int64, Int64> tAnds = FindT(n);

            Random rnd = new Random();
            for (Int64 i = 1; i <= accuracy; ++i)
            {
                Int64 a = rnd.Next(2, (int)n - 2);
                Int64 x = BinaryMath.PowByModulo(a, tAnds.Item1, n);

                if (x == 1 || x == n - 1)
                    continue;

                bool isCont = false;
                for (Int64 j = 0; j < tAnds.Item2 - 1; ++j)
                {
                    x = (x * x) % n;
                    if (x == 1)
                        return false;

                    if (x == n - 1)
                        isCont = true;
                }
                if (isCont)
                    continue;
                return false;
            }
            return true;
        }

        private Tuple<Int64, Int64> FindT(Int64 n)
        {
            Tuple<Int64, Int64> res;
            for (Int64 i = 60; i >= 1; --i)
                if ((n - 1) % BinaryMath.Pow(2, i) == 0)
                    return new Tuple<Int64, Int64>((n - 1) / BinaryMath.Pow(2, i), i);
            return null;
        }
    }
}
