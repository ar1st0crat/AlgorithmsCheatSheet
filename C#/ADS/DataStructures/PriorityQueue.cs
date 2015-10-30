namespace ADS.DataStructures
{
    public class PriorityQueue
    {
        private int[] a = new int [1000001];
        int N = 0;

        
        private void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }


        private void FixUp()
        {
            int i = N;
            while ( i > 1 && a[i/2] < a[i] )
            {
                Swap(ref a[i/2], ref a[i]);
                i /= 2;
            }
        }


        private void FixDown()
        {
            int i = 1;

            while (2*i <= N-1)
            {
                int j = 2*i;

                if ( j<N-1 && a[j] < a[j + 1])
                    j++;
            
                if (a[i] >= a[j])
                    break;
                
                Swap( ref a[i], ref a[j] );
                i = j;
            }
        }


        public void Insert(int elem)
        {
            a[++N] = elem;
            FixUp();
        }

        public int GetMax()
        {
            Swap( ref a[1], ref a[N] );
            FixDown();
            return a[N--];
        }

        public bool IsEmpty()
        {
            return N == 0;
        }
    }
}
