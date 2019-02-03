using System;

namespace Math
{
    public static class Prime
    {
        private const int _maxPrime = 2146435069;

        /// <summary>
        /// Checks if number is a prime number
        /// </summary>
        /// <param name="num">input</param>
        public static bool IsPrime(int num)
        {
            if ((num & 1) != 0)
            {
                for (int i = 2; i < num; i++)
                {
                    if (num % i == 0)
                        return false;
                }
                return true;
            }
            return (num == 2);
        }

        /// <summary>
        /// Return the next prime number after the input
        /// </summary>
        /// <param name="num">seed</param>
        public static int NextPrime(int num)
        {
            do
            {
                if (IsPrime(++num))
                    return num;
            } while (num < _maxPrime);
            return num;
        }

        /// <summary>
        /// Return the first prime number that came before the input
        /// </summary>
        /// <param name="num">seed</param>
        public static int PreviousPrime(int num)
        {
            do
            {
                if (IsPrime(--num))
                    return num;
            } while (num > int.MinValue);
            return num;
        }
    }
}
