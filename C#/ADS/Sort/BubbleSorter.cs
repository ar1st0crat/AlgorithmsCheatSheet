namespace ADS.Sort
{
    /// <summary>
    /// BUBBLESORT
    /// </summary>
    public class BubbleSorter : ISorter<int>
    {
        public void Sort(int[] a, int l, int r)
        {
            for (int i = l; i < r; i++)
                for (int j = r; j > i; j--)
                    if (a[j - 1] > a[j])
                        this.Swap(ref a[j - 1], ref a[j]);
        }
    }
}
