﻿using System;

namespace PrimalityTestsDemo
{
    public static class SymbolLegendre
    {
        public static long Calculate(long a, long p)
        {
            if (a % p == 0)
                return 0;

            for (int i = 1; i < Math.Sqrt(p); ++i)
                if (((i * i) % p) == (a % p))
                    return 1;

            return -1;
        }
    }
}
