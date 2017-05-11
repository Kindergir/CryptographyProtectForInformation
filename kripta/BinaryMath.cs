namespace PrimalityTestsDemo
{
    public static class BinaryMath
    {
        public static long PowByModulo(long baseT, long step, long modulo)
        {
            long result = 1;
            while (step > 0)
            {
                if (step % 2 == 1)
                    result = (result * 1L * baseT) % modulo;
                step = step / 2;
                baseT = (baseT * 1L * baseT) % modulo;
            }
            return result;
        }

        public static long Pow(long baseT, long step)
        {
            long result = 1;
            while (step > 0)
            {
                if (step % 2 == 1)
                    result = (result * 1L * baseT);
                step = step / 2;
                baseT = (baseT * 1L * baseT);
            }
            return result;
        }

        public static long Gcd(long a, long b)
        {
            if (b == 0)
                return a;
            else
                return Gcd(b, a % b);
        }
    }
}
