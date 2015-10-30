namespace ADS.Search
{
    /// <summary>
    /// SIMPLE LINEAR SEARCH IN AN ARRAY
    /// </summary>
    public class LinearSearcher<T> : ISearcher<T>
    {
        public int Search(T elem, T[] a, int N)
        {
            for (int i = 0; i < N; i++)
                if (a[i].Equals(elem))
                    return i;

            return -1;
        }
    }
}
