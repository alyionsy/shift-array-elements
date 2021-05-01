using System;

namespace ShiftArrayElements
{
    public static class Shifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (odd elements - left direction, even elements - right direction).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static int[] Shift(int[] source, int[] iterations)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            
            if (iterations is null)
            {
                throw new ArgumentNullException(nameof(iterations));
            }

            for (int i = 0; i < iterations.Length; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < iterations[i]; j++)
                    {
                        int lastElement = source[0];
                        Array.Copy(source, 1, source, 0, source.Length - 1);
                        source[^1] = lastElement;
                    }
                }
                else
                {
                    for (int j = 0; j < iterations[i]; j++)
                    {
                        int firstElement = source[^1];
                        Array.Copy(source, 0, source, 1, source.Length - 1);
                        source[0] = firstElement;
                    }
                }
                
                Console.WriteLine(string.Join(" ", source));
            }

            return source;
        }
    }
}
