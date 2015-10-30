namespace ADS.Sort
{
    /// <summary>
    /// SELECTION SORT
    /// </summary>
    public class SelectionSorter : ISorter<int>
    {
        public void Sort(int[] a, int l, int r)
        {
            for (int i = l; i < r; i++)
            {
                int min = i;
                for (int j = i + 1; j <= r; j++)
                    if (a[j] < a[min])
                        min = j;

                this.Swap(ref a[i], ref a[min]);
            }
        }
    }
}
