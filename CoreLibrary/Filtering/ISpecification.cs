namespace CoreLibrary.Filtering;

public interface ISpecification<T> where T : class
{
    bool IsSatisfied(T model);
}