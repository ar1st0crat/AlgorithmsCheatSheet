namespace ADS.Sort
{
    /// <summary>
    /// SHELLSORT
    /// h = { 701, 301, 132, 57, 23, 10, 4, 1 }
    /// </summary>
    public class ShellSorter : ISorter<int>
    {
        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="a">Array of elements to sort</param>
        /// <param name="l">Left boundary</param>
        /// <param name="r">Right boundary</param>
        public void Sort(int[] a, int l, int r)
        {
            int[] H = { 57, 23, 10, 4, 1 };
            int HN = H.Length;

            foreach (int step in H)
            {
                for (int i = l + step; i <= r; i++)
                {
                    int j = i;
                    int tmp = a[i];

                    while (j >= l + step && tmp < a[j - step])
                    {
                        a[j] = a[j - step];
                        j -= step;
                    }
                    a[j] = tmp;
                }
            }
        }
    }
}
