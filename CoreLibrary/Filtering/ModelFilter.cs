namespace CoreLibrary.Filtering;

public class ModelFilter<T> : IFilter<T> where T : class
{
    public IEnumerable<T> Filter(IEnumerable<T> models, ISpecification<T> specification)
    {
        foreach (var model in models)
        {
            if (specification.IsSatisfied(model))
                yield return model;
        }
    }
}