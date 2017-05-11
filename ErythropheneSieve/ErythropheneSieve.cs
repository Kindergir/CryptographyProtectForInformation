namespace ErythropheneSieveDemo
{
    public static class ErythropheneSieve
    {
        public static int[] GetFor(long n)
        {
            int[] numbers = new int[n + 2];

            for (int i = 2; i < numbers.Length; ++i)
            {
                if (numbers[i] == 1)
                    continue;

                for (int j = i + i; j < numbers.Length; j += i)
                    numbers[j] = 1;
            }
            return numbers;
        }
    }
}
