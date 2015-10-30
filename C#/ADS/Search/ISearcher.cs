namespace ADS.Search
{
    /// <summary>
    /// SEARCH elem ELEMENT IN ARRAY a OF SIZE N
    /// </summary>
    interface ISearcher<T>
    {
        int Search( T elem, T[] a, int N );
    }
}
