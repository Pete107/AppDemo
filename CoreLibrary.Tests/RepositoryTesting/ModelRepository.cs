using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLibrary.Data;
using CoreLibrary.Filtering;

namespace CoreLibrary.Tests.RepositoryTesting;

public class ModelRepository<T> : IRepository<T> where T : BaseModel
{
    private readonly List<T> _models;
    private readonly IFilter<T> _filter;

    public ModelRepository(List<T> models)
    {
        _models = models;
        _filter = new ModelFilter<T>();
    }
    public void Add(T entity)
    {
        _models.Add(entity);
    }

    public void Add(params T[] entities)
    {
        _models.AddRange(entities);
    }

    public Task AddAsync(T entity)
    {
        _models.Add(entity);
        return Task.CompletedTask;
    }

    public Task AddAsync(params T[] entities)
    {
        _models.AddRange(entities);
        return Task.CompletedTask;
    }

    public T? Get(string id)
    {
        return _models.FirstOrDefault(a => a.Id == id);
    }

    public T? Find(ISpecification<T> specification)
    {
        return _filter.Filter(_models, specification).FirstOrDefault();
    }

    public Task<T?> GetAsync(string id)
    {
        return Task.FromResult(_models.FirstOrDefault(a => a.Id == id));
    }

    public Task<T?> FindAsync(ISpecification<T> specification)
    {
        return Task.FromResult(_filter.Filter(_models, specification).FirstOrDefault());
    }

    public IEnumerable<T> GetAll()
    {
        return _models;
    }

    public IEnumerable<T> FindAll(ISpecification<T> specification)
    {
        return _filter.Filter(_models, specification);
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<T>>(_models);
    }

    public Task<IEnumerable<T>> FindAllAsync(ISpecification<T> specification)
    {
        return Task.FromResult(_filter.Filter(_models, specification));
    }

    public void Update(T entity)
    {
        var existingModel = _models.FirstOrDefault(a => a.Id == entity.Id);
        existingModel?.Update(entity);
    }

    public void Update(params T[] entities)
    {
        foreach (var baseModel in entities)
        {
            var existingModel = _models.FirstOrDefault(a => a.Id == baseModel.Id);
            existingModel?.Update(baseModel);
        }
    }

    public Task UpdateAsync(T entity)
    {
        var existingModel = _models.FirstOrDefault(a => a.Id == entity.Id);
        existingModel?.Update(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(params T[] entities)
    {
        foreach (var baseModel in entities)
        {
            var existingModel = _models.FirstOrDefault(a => a.Id == baseModel.Id);
            existingModel?.Update(baseModel);
        }
        return Task.CompletedTask;
    }

    public void Delete(string id)
    {
        var idx = _models.FindIndex(a => a.Id == id);
        if (idx == -1) return;
        _models.RemoveAt(idx);
    }

    public void Delete(T entity)
    {
        var idx = _models.IndexOf(entity);
        if (idx == -1) return;
        _models.RemoveAt(idx);
    }

    public void Delete(params string[] ids)
    {
        foreach (var id in ids)
        {
            var idx = _models.FindIndex(a => a.Id == id);
            if (idx == -1) continue;
            _models.RemoveAt(idx);
        }
    }

    public void Delete(params T[] entities)
    {
        foreach (var baseModel in entities)
        {
            var idx = _models.IndexOf(baseModel);
            if (idx == -1) continue;
            _models.RemoveAt(idx);
        }
    }

    public Task DeleteAsync(string id)
    {
        var idx = _models.FindIndex(a => a.Id == id);
        if (idx == -1) return Task.CompletedTask;
        _models.RemoveAt(idx);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        var idx = _models.IndexOf(entity);
        if (idx == -1) return Task.CompletedTask;
        _models.RemoveAt(idx);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(params string[] ids)
    {
        foreach (var id in ids)
        {
            var idx = _models.FindIndex(a => a.Id == id);
            if (idx == -1) continue;
            _models.RemoveAt(idx);
        }

        return Task.CompletedTask;
    }

    public Task DeleteAsync(params T[] entities)
    {
        foreach (var baseModel in entities)
        {
            var idx = _models.IndexOf(baseModel);
            if (idx == -1) continue;
            _models.RemoveAt(idx);
        }

        return Task.CompletedTask;
    }
}