using System;
using System.Collections.Generic;

namespace ZhegalkinPolynomialDemo
{
    public static class ZhegalkinPolynomial
    {
        public static string ConstructPolynomial(List<int> valuesVector)
        {
            double varCount = Math.Log(valuesVector.Count, 2);
            if (Math.Abs(Math.Round(varCount) - varCount) > 0)
                throw new ArgumentException();

            int zeroCount = valuesVector.FindAll(x => x == 0).Count;
            if (zeroCount == valuesVector.Count)
                return "0";
            if (zeroCount == 0)
                return "1";

            var table = FillTruthTable((int)varCount);
            var triangle = FillPascalTriangle(valuesVector);
            string result = "";
            for (int i = 0; i < table.Count; ++i)
            {
                if (triangle[i][0] == 1)
                {
                    for (int j = 0; j < table[i].Count; ++j)
                        if (table[i][j] == 1)
                            result += "x" + (j + 1);
                    result += " +";
                }
            }
            result = AdjustPolynomial(result);
            return result;
        }

        private static string AdjustPolynomial(string polynomial)
        {
            if (polynomial[polynomial.Length - 1] == '+')
                polynomial = polynomial.Substring(0, polynomial.Length - 1);
            if (polynomial[0] == '+')
                polynomial = polynomial.Substring(1, polynomial.Length);
            if (polynomial[1] == '+')
                polynomial = polynomial.Substring(2, polynomial.Length - 1);
            return polynomial;
        }

        private static List<List<int>> FillPascalTriangle(List<int> valuesVector)
        {
            var triangle = new List<List<int>>();
            triangle.Add(valuesVector);

            for (int i = valuesVector.Count - 1, k = 1; i > 0; --i, ++k)
            {
                triangle.Add(new List<int>());
                for (int j = 0; j < i; ++j)
                    triangle[k].Add((triangle[k - 1][j] + triangle[k - 1][j + 1]) % 2);
            }
            return triangle;
        }

        private static List<List<int>> FillTruthTable(int varCount)
        {
            List<List<int>> table = new List<List<int>>();
            Int64 linesCount = (Int64)Math.Pow(2, varCount);
            for (int i = 0; i < linesCount; ++i)
            {
                table.Add(new List<int>());
                var line = NumberInBinarySystem(i);

                for (int j = 0; j < varCount - line.Count; ++j)
                    table[i].Add(0);

                for (int j = 0; j < line.Count; ++j)
                    table[i].Add(line[j]);
            }
            return table;
        }

        private static List<int> NumberInBinarySystem(int n)
        {
            List<int> digits = new List<int>();
            while (n > 0)
            {
                digits.Add(n % 2);
                n /= 2;
            }
            digits.Reverse();
            return digits;
        }
    }
}
