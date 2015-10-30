namespace ADS.Search
{
    /// <summary>
    /// BINARY SEARCH
    /// </summary>
    public class BinarySearcher : ISearcher<int>
    {
        /// <summary>
        /// Recursive version
        /// for recursive implementation simply call the BinarySearch() function:
        ///                 return BinarySearch( elem, a, 0, N-1 );
        /// </summary>
        int BinarySearch(int elem, int[] a, int l, int r)
        {
            if (l > r)
                return -1;

            int mid = (l + r) / 2;

            if (a[mid] == elem)
                return mid;

            if (l == r) return -1;

            if (a[mid] > elem)
                return BinarySearch(elem, a, l, mid - 1);
            else
                return BinarySearch(elem, a, mid + 1, r);
        }

        // iterative version
        public int Search(int elem, int[] a, int N)
        {
            int l = 0, r = N - 1;
            while (r >= l)
            {
                int mid = (l + r) / 2;
                if (a[mid] == elem) return mid;

                if (a[mid] > elem)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return -1;
        }
    }
}
