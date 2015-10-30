namespace ADS.Sort
{
    /// <summary>
    /// QUICKSORT
    /// </summary>
    public class QuickSorter : ISorter<int>
    {
        private int Partition(int[] a, int l, int r)
        {
            int pivot = a[r];

            int i = l - 1, j = r;

            while (i < j)
            {
                while (a[++i] < pivot) ;
                while (a[--j] > pivot)
                    if (j == l)
                        break;

                if (i < j)
                    this.Swap(ref a[i], ref a[j]);
                else
                    break;
            }

            this.Swap(ref a[i], ref a[r]);

            return i;
        }

        public void Sort(int[] a, int l, int r)
        {
            if (r <= l)
                return;

            int p = Partition(a, l, r);
            Sort(a, l, p - 1);
            Sort(a, p + 1, r);
        }
    }
}
