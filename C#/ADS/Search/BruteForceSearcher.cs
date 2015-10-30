namespace ADS.Search
{
    /// <summary>
    /// SIMPLE BRUTE FORCE ALGORITHM FOR STRING MATCHING
    /// </summary>
    public class SimpleStringMatcher : IStringSearcher
    {
        public int Search(string pattern, string text)
        {
            int n = text.Length;
            int m = pattern.Length;

            for (int i = 0; i < n; i++)
            {
                int j = 0;

                for (; j < m; j++)
                    if (pattern[j] != text[i + j]) break;

                if (j == m) return i;
            }

            return -1;
        }
    }
}
