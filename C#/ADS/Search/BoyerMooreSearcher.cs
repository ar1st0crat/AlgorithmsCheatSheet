using System;

namespace ADS.Search
{
    /// <summary>
    /// CLASSIC BOYER-MOORE ALGORITHM
    /// </summary>
    public class BoyerMooreSearcher : IStringSearcher
    {
        /// <summary>
        /// Heuristics 1: Bad characters table
        /// </summary>
        int[] BadCharactersTable(string pattern)
        {
            int m = pattern.Length;

            int[] badShift = new int[256];

            for (int i = 0; i < 256; i++)
            {
                badShift[i] = -1;
            }

            for (int i = 0; i < m - 1; i++)
            {
                badShift[(int)pattern[i]] = i;
            }

            return badShift;
        }

        /// <summary>
        /// Heuristics 2: Good suffixes table
        /// </summary>
        int[] Suffixes(string pattern)
        {
            int m = pattern.Length;
            int[] suffixes = new int[m];
            suffixes[m - 1] = m;

            int g = m - 1, f = 0;

            for (int i = m - 2; i >= 0; --i)
            {
                if (i > g && suffixes[i + m - 1 - f] < i - g)
                {
                    suffixes[i] = suffixes[i + m - 1 - f];
                }
                else
                {
                    if (i < g)
                    {
                        g = i;
                    }

                    f = i;

                    while (g >= 0 && pattern[g] == pattern[g + m - 1 - f])
                    {
                        g--;
                    }
                    suffixes[i] = f - g;
                }
            }

            return suffixes;
        }

        int[] GoodSuffixTable(string pattern)
        {
            int m = pattern.Length;
            int[] suffixes = Suffixes(pattern);
            int[] goodSuffixes = new int[m];

            for (int i = 0; i < m; i++)
            {
                goodSuffixes[i] = m;
            }

            for (int i = m - 1; i >= 0; i--)
            {
                if (suffixes[i] == i + 1)
                {
                    for (int j = 0; j < m - i - 1; j++)
                    {
                        if (goodSuffixes[j] == m)
                        {
                            goodSuffixes[j] = m - i - 1;
                        }
                    }
                }
            }

            for (int i = 0; i < m - 2; i++)
            {
                goodSuffixes[m - 1 - suffixes[i]] = m - i - 1;
            }

            return goodSuffixes;
        }

        /// <summary>
        /// Main search function
        /// </summary>
        public int Search(string pattern, string text)
        {
            int n = text.Length;
            int m = pattern.Length;

            if (m > n)
            {
                return -1;
            }

            int[] badShift = BadCharactersTable(pattern);
            int[] goodSuffix = GoodSuffixTable(pattern);

            int offset = 0;

            while (offset <= n - m)
            {
                int i;
                for (i = m - 1; i >= 0 && pattern[i] == text[i + offset]; i--) ;

                if (i < 0)
                    return offset;

                offset += Math.Max(i - badShift[(int)text[offset + i]], goodSuffix[i]);
            }

            return -1;
        }
    }
}
