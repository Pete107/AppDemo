namespace CoreLibrary.Filtering;

public class FuncSpecification<T> : ISpecification<T> where T : class
{
    private readonly Func<T, bool> _predicate;
    
    public FuncSpecification(Func<T, bool> predicate)
    {
        _predicate = predicate;
    }
    public bool IsSatisfied(T model)
    {
        return _predicate(model);
    }
}