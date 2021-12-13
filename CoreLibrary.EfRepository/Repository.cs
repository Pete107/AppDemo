using CoreLibrary.Data;
using CoreLibrary.Filtering;
using Microsoft.EntityFrameworkCore;

namespace CoreLibrary.EfRepository
{
    public class Repository<T, TContext> : IRepository<T> where T : BaseModel where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<T> _db;
        private readonly ModelFilter<T> _filter;
        public Repository(TContext context)
        {
            _context = context;
            _db = _context.Set<T>();
            _filter = new();
        }
        public void Add(T entity)
        {
            _db.Add(entity);
            _context.SaveChanges();
        }

        public void Add(params T[] entities)
        {
            _db.AddRange(entities);
            _context.SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            await _db.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(params T[] entities)
        {
            await _db.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public T? Get(string id)
        {
            return _db.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public T? Find(ISpecification<T> specification)
        {
            var models = _db.AsNoTracking().ToList();
            return _filter.Filter(models, specification).FirstOrDefault();
        }

        public async Task<T?> GetAsync(string id)
        {
            return await _db.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<T?> FindAsync(ISpecification<T> specification)
        {
            var models = await _db.AsNoTracking().ToListAsync();
            return _filter.Filter(models, specification).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _db.AsNoTracking().ToList();
        }

        public IEnumerable<T> FindAll(ISpecification<T> specification)
        {
            var models = _db.AsNoTracking().ToList();
            return _filter.Filter(models, specification);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(ISpecification<T> specification)
        {
            var models = await _db.AsNoTracking().ToListAsync();
            return _filter.Filter(models, specification);
        }

        public void Update(T entity)
        {
            var existingModel = _db.AsNoTracking().FirstOrDefault(a => a.Id == entity.Id);
            if (existingModel is null) return;
            existingModel.Update(entity);
            _db.Update(existingModel);
            _context.SaveChanges();
        }

        public void Update(params T[] entities)
        {
            var changesMade = false;
            foreach (var baseModel in entities)
            {
                var existingModel = _db.AsNoTracking().FirstOrDefault(a => a.Id == baseModel.Id);
                if (existingModel is null) continue;
                existingModel.Update(baseModel);
                _db.Update(existingModel);
                if (!changesMade)
                    changesMade = true;
            }

            if (changesMade)
                _context.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            var existing = await _db.AsNoTracking().FirstOrDefaultAsync(a => a.Id == entity.Id);
            if (existing is null) return;
            existing.Update(entity);
            _db.Update(existing);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(params T[] entities)
        {
            var changesMade = false;
            foreach (var baseModel in entities)
            {
                var existingModel = await _db.AsNoTracking().FirstOrDefaultAsync(a => a.Id == baseModel.Id);
                if (existingModel is null) continue;
                existingModel.Update(baseModel);
                _db.Update(existingModel);
                if (!changesMade)
                    changesMade = true;
            }

            if (changesMade)
                await _context.SaveChangesAsync();
        }

        public void Delete(string id)
        {
            var model = _db.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (model is null) return;
            model.Delete();
            _db.Update(model);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            var existingModel = _db.AsNoTracking().FirstOrDefault(a => a.Id == entity.Id);
            if (existingModel is null) return;
            existingModel.Delete();
            _db.Update(existingModel);
            _context.SaveChanges();
        }

        public void Delete(params string[] ids)
        {
            var changesMade = false;
            foreach (var id in ids)
            {
                var model = _db.AsNoTracking().FirstOrDefault(a => a.Id == id);
                if (model is null) return;
                model.Delete();
                _db.Update(model);
                if (!changesMade)
                    changesMade = true;
            }
            if (changesMade)
                _context.SaveChanges();
        }

        public void Delete(params T[] entities)
        {
            var changesMade = false;
            foreach (var baseModel in entities)
            {
                var existingModel = _db.AsNoTracking().FirstOrDefault(a => a.Id == baseModel.Id);
                if (existingModel is null) return;
                existingModel.Delete();
                _db.Update(existingModel);
            }
            if (changesMade)
                _context.SaveChanges();
        }

        public async Task DeleteAsync(string id)
        {
            var model = await _db.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (model is null) return;
            model.Delete();
            _db.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            var existingModel = await _db.AsNoTracking().FirstOrDefaultAsync(a => a.Id == entity.Id);
            if (existingModel is null) return;
            existingModel.Delete();
            _db.Update(existingModel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(params string[] ids)
        {
            var changesMade = false;
            foreach (var id in ids)
            {
                var model = await _db.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
                if (model is null) return;
                model.Delete();
                _db.Update(model);
                if (!changesMade)
                    changesMade = true;
            }
            if (changesMade)
                await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(params T[] entities)
        {
            var changesMade = false;
            foreach (var baseModel in entities)
            {
                var existingModel = await _db.AsNoTracking().FirstOrDefaultAsync(a => a.Id == baseModel.Id);
                if (existingModel is null) return;
                existingModel.Delete();
                _db.Update(existingModel);
            }
            if (changesMade)
                await _context.SaveChangesAsync();
        }
    }
}