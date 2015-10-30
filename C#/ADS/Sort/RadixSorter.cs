namespace ADS.Sort
{
    /// <summary>
    /// RADIXSORT
    /// (Least Signifincant Digit version)
    /// </summary>
    public class LSDRadixSorter : ISorter<int>
    {
        public const int BASE = 10;

        public void Sort(int[] a, int l, int r)
        {
            int[] bucket = new int[a.Length];

            int maxVal = 0;

            for (int i = l; i <= r; i++)
            {
                if (a[i] > maxVal)
                    maxVal = a[i];
            }

            int digitPosition = 1;

            /* maxVal: this variable decides the while-loop count: if maxVal is 3 digits, then we loop through 3 times */
            while (maxVal / digitPosition > 0)
            {
                /* обнуляем счетчик */
                int[] digitCount = new int[BASE];

                /* считаем элементы с одинаковыми соотв. разрядами */
                for (int i = l; i <= r; i++)
                    digitCount[a[i] / digitPosition % BASE]++;

                /* накапливаем счетчики */
                for (int i = 1; i < BASE; i++)
                    digitCount[i] += digitCount[i - 1];

                /* Чтобы сохранить порядок, начинаем с конца */
                for (int i = r; i >= l; i--)
                    bucket[--digitCount[a[i] / digitPosition % BASE]] = a[i];

                /* перестраиваем изначальный массив, используя элементы в корзине */
                for (int i = l; i <= r; i++)
                    a[i] = bucket[i];

                /* переходим на разряд выше */
                digitPosition *= BASE;
            }
        }
    }
}
