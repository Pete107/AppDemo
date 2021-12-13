using CoreLibrary.Filtering;

namespace CoreLibrary;

public interface IRepository<TEntity> where TEntity : class
{
    #region Create

    void Add(TEntity entity);
    void Add(params TEntity[] entities);
    Task AddAsync(TEntity entity);
    Task AddAsync(params TEntity[] entities);

    #endregion

    #region Read

    TEntity? Get(string id);
    TEntity? Find(ISpecification<TEntity> specification);
    Task<TEntity?> GetAsync(string id);
    Task<TEntity?> FindAsync(ISpecification<TEntity> specification);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> FindAll(ISpecification<TEntity> specification);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> FindAllAsync(ISpecification<TEntity> specification);

    #endregion

    #region Update

    void Update(TEntity entity);
    void Update(params TEntity[] entities);
    Task UpdateAsync(TEntity entity);
    Task UpdateAsync(params TEntity[] entities);

    #endregion

    #region Delete

    void Delete(string id);
    void Delete(TEntity entity);
    void Delete(params string[] ids);
    void Delete(params TEntity[] entities);
    
    Task DeleteAsync(string id);
    Task DeleteAsync(TEntity entity);
    Task DeleteAsync(params string[] ids);
    Task DeleteAsync(params TEntity[] entities);
    

    #endregion

}