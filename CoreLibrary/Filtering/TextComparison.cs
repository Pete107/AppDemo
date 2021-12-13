namespace CoreLibrary.Filtering;

public readonly struct TextComparison
{
    private readonly bool _ignorecase, _fullMatch;
    private readonly string _textToCompare;
    
    public TextComparison(string textToCompare, bool fullMatch = true, bool ignorecase = true)
    {
        _ignorecase = ignorecase;
        _textToCompare = textToCompare;
        _fullMatch = fullMatch;
    }

    public bool IsMatch(string source)
    {
        if (_fullMatch)
            return string.Equals(source, _textToCompare,
                _ignorecase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture);
        return source.Contains(_textToCompare, _ignorecase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture);
    }
}