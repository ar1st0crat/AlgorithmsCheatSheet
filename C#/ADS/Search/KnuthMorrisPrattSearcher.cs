namespace ADS.Search
{
    /// <summary>
    /// CLASSIC KNUTH-MORRIS-PRATT ALGORITHM
    /// </summary>
    public class KnuthMorrisPrattSearcher : IStringSearcher
    {
        int[] computePrefixFunction(string s)
        {
            int m = s.Length;
            int[] pi = new int[m];
            int j = 0;
            pi[0] = 0;

            for (int i = 1; i < m; i++)
            {
                while (j > 0 && s[j] != s[i])
                {
                    j = pi[j];
                }

                if (s[j] == s[i])
                {
                    j++;
                }

                pi[i] = j;
            }
            return pi;
        }

        /// <summary>
        /// APPROACH 1 - CLASSIC KMP
        /// </summary>
        public int Search(string pattern, string text)
        {
            int n = text.Length;
            int m = pattern.Length;

            int[] prefix = computePrefixFunction(pattern);

            int q = 0;

            for (int i = 1; i <= n; i++)
            {
                while (q > 0 && pattern[q] != text[i - 1])
                {
                    q = prefix[q - 1];
                }

                if (pattern[q] == text[i - 1])
                {
                    q++;
                }

                if (q == m)
                {
                    return i - m;
                }
            }

            return -1;
        }

        /// <summary>
        /// APPROACH 2 - PREPEND TEXT WITH PREFIX TABLE
        /// (slower approach, very slow in fact :-))
        /// </summary>
        public int SlowSearch(string pattern, string text)
        {
            int[] prefix = computePrefixFunction(pattern + "|" + text);

            for (int pos = pattern.Length + 1; pos < prefix.Length; pos++)
                if (prefix[pos] == pattern.Length)
                    return pos - 2 * pattern.Length;

            return -1;
        }
    }
}
