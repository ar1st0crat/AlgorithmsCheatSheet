namespace ADS.Sort
{
    /// <summary>
    /// SHAKERSORT
    /// </summary>
    public class ShakerSorter : ISorter<int>
    {
        public void Sort(int[] a, int l, int r)
        {
            do
            {
                // Move "heavy elements" to the end of array
                for (int i = l; i < r; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        this.Swap(ref a[i], ref a[i + 1]);
                    }
                }

                r--;

                // Move "light elements" to the beginning of array
                for (int i = r; i > l; i--)
                {
                    if (a[i] < a[i - 1])
                    {
                        this.Swap(ref a[i], ref a[i - 1]);
                    }
                }

                l++;
            }
            while (l <= r);
        }
    }
}
