namespace ADS.Search
{
    /// <summary>
    /// BOYER-MOORE-HORSPOOL ALGORITHM
    /// (BM WITHOUT "GOOD SUFFIXES" TABLE AND SLIGHTLY DIFFERENT APPROACH WITH "BAD CHARACTERS")
    /// </summary>
    public class BoyerMooreHorspoolSearcher : IStringSearcher
    {
        int[] BadCharactersTable(string pattern)
        {
            int m = pattern.Length;

            int[] badShift = new int[256];

            for (int i = 0; i < 256; i++)
            {
                badShift[i] = m;
            }

            for (int i = 0; i < m - 1; i++)
            {
                badShift[(int)pattern[i]] = m - 1 - i;
            }

            return badShift;
        }

        public int Search(string pattern, string text)
        {
            int n = text.Length;
            int m = pattern.Length;

            if (m > n)
            {
                return -1;
            }

            int[] badShift = BadCharactersTable(pattern);

            int offset = 0;

            while (offset <= n - m)
            {
                int i;
                for (i = m - 1; i >= 0 && pattern[i] == text[i + offset]; i--) ;

                if (i < 0)
                    return offset;

                offset += badShift[(int)text[offset + m - 1]];
            }

            return -1;
        }
    }
}
