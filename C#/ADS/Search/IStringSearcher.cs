namespace ADS.Search
{
    /// <summary>
    /// SEARCH A NEEDLE (pattern) IN THE HAYSTACK (text)
    /// </summary>
    interface IStringSearcher
    {
        int Search(string pattern, string text);
    }
}
