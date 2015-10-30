namespace ADS.Sort
{
    /// <summary>
    /// MERGESORT
    /// </summary>
    public class MergeSorter : ISorter<int>
    {
        private void Merge(int[] a, int l, int mid, int r)
        {
            int[] temp = new int[r - l + 1];

            int i = l, j = mid + 1;
            int k = 0;

            for (k = 0; k < temp.Length; k++)
            {
                if (i > mid)
                {
                    temp[k] = a[j++];
                }
                else if (j > r)
                {
                    temp[k] = a[i++];
                }
                else
                {
                    temp[k] = (a[i] < a[j]) ? a[i++] : a[j++];
                }
            }

            // Copy temp array to original array
            k = 0;
            i = l;
            while (k < temp.Length && i <= r)
            {
                a[i++] = temp[k++];
            }
        }

        public void Sort(int[] a, int l, int r)
        {
            if (r <= l)
                return;

            int mid = (l + r) / 2;
            Sort(a, l, mid);
            Sort(a, mid + 1, r);
            Merge(a, l, mid, r);
        }
    }
}
