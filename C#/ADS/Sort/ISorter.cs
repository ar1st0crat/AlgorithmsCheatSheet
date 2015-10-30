namespace ADS.Sort
{
    /// <summary>
    /// Sorting Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ISorter<T>
    {
        /// <summary>
        /// Main sorting function
        /// </summary>
        /// <param name="a">Array of elements</param>
        /// <param name="l">Left boundary</param>
        /// <param name="r">Right boundary</param>
        void Sort( T[] a, int l, int r );
    }

    /// <summary>
    /// Just a class providing extension method for swapping two elements
    /// </summary>
    static class Swapper
    {
        public static void Swap<T>(this ISorter<T> s, ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }
    }
}
