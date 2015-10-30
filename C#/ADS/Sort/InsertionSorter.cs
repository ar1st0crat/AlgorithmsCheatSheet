namespace ADS.Sort
{
    /// <summary>
    /// INSERTION SORT
    /// </summary>
    public class InsertionSorter : ISorter<int>
    {
        /// <summary>
        /// Slow version (included here just for comparison)
        /// </summary>
        public void SlowSort(int[] a, int l, int r)
        {
            for (int i = l + 1; i <= r; i++)
                for (int j = i; j > l; j--)
                    if (a[j - 1] > a[j])
                        this.Swap(ref a[j - 1], ref a[j]);
        }

        /// <summary>
        /// Basic version
        /// </summary>
        public void Sort(int[] a, int l, int r)
        {
            for (int i = l + 1; i <= r; i++)
            {
                int j = i;
                int tmp = a[i];

                while (j > l && tmp < a[j - 1])
                {
                    a[j] = a[j - 1];
                    j--;
                }

                a[j] = tmp;
            }
        }
    }
}
