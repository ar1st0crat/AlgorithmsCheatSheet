namespace ADS.Sort
{
    /// <summary>
    /// COUNTING SORT
    /// </summary>
    public class CountingSorter : ISorter<int>
    {
        public void Sort(int[] a, int l, int r)
        {
            int[] buckets = new int[r - l + 1];

            for (int i = l; i <= r; i++)
                buckets[a[i]]++;

            for (int i = l, j = l; i <= r; i++)
                while (buckets[i]-- > 0)
                    a[j++] = i;
        }
    }


    /// <summary>
    /// SLIGHTLY MORE EFFECTIVE COUNTING SORT
    /// (number of buckets depends on particular data)
    /// </summary>
    public class AdvancedCountingSorter : ISorter<int>
    {
        public void Sort(int[] a, int l, int r)
        {
            int min = 0, max = 0;

            for (int i = l; i <= r; i++)
            {
                if (a[i] < min) min = a[i];
                else if (a[i] > max) max = a[i];
            }

            int bn = max - min + 1;

            int[] buckets = new int[bn];

            for (int i = l; i <= r; i++)
                buckets[a[i] - min]++;

            int idx = 0;
            for (int i = min; i <= max; i++)
                for (int j = 0; j < buckets[i - min]; j++)
                    a[idx++] = i;
        }
    }
}
