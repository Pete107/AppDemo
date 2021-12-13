using System.Collections.Generic;
using CoreLibrary.Data;
using CoreLibrary.Filtering;

namespace CoreLibrary.Tests.RepositoryTesting;

public class ModelFilter<T> : IFilter<T> where T : BaseModel
{
    public IEnumerable<T> Filter(IEnumerable<T> models, ISpecification<T> specification)
    {
        foreach (var baseModel in models)
        {
            if (specification.IsSatisfied(baseModel))
                yield return baseModel;
        }
    }
}