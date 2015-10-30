namespace ADS.Search
{
    /// <summary>
    /// INTERPOLATION SEARCH : O(log log N) in average
    /// </summary>
    public class InterpolationSearcher : ISearcher<int>
    {
        public int Search(int elem, int[] a, int N)
        {
            int l = 0, r = N - 1;

            while (a[r] != a[l] && elem >= a[l] && elem <= a[r])
            {
                int mid = l + (elem - a[l]) * ((r - l) / (a[r] - a[l]));

                if (a[mid] < elem)
                    l = mid + 1;
                else if (elem < a[mid])
                    r = mid - 1;
                else
                    return mid;
            }

            if (elem == a[l])
                return l;
            else
                return -1;


            // or slightly different, like this:
            //
            //int l = 0, r = N - 1;

            //while (r >= l)
            //{
            //    int mid = l + (r - l) * (elem - a[l]) / (a[r] - a[l]);

            //    if (mid > r)
            //        return -1;

            //    if (elem < a[mid])
            //        r = mid - 1;
            //    else if (elem > a[mid])
            //        l = mid + 1;
            //    else return mid;
            //}
            //return -1;
        }
    }
}
