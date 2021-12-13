namespace CoreLibrary.Filtering;

public interface IFilter<T> where T : class
{
    IEnumerable<T> Filter(IEnumerable<T> models, ISpecification<T> specification);
}