using System;

namespace ShiftArrayElements
{
    public static class EnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static int[] Shift(int[] source, Direction[] directions)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            
            if (directions is null)
            {
                throw new ArgumentNullException(nameof(directions));
            }

            for (int i = 0; i < directions.Length; i++)
            {
                Direction currentDirection = directions[i];
                switch (currentDirection)
                {
                    case Direction.Left:
                    {
                        for (int j = 0; j < source.Length - 1; j++)
                        {
                            source[j] += source[j + 1];
                            source[j + 1] = source[j] - source[j + 1];
                            source[j] -= source[j + 1];
                        }
                        
                        break;
                    }

                    case Direction.Right:
                    {
                        for (int j = source.Length - 1; j > 0; j--)
                        {
                            source[j] += source[j - 1];
                            source[j - 1] = source[j] - source[j - 1];
                            source[j] -= source[j - 1];
                        }
                        
                        break;
                    }

                    default:
                        throw new InvalidOperationException($"Incorrect {currentDirection} enum value.");
                }
            }

            return source;
        }
    }
}
