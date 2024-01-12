using ApplicationCore.Common.Interface;
using Domain.Common.Repository.Base;
using Domain.Common.Specification;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Common.Extension;
using Domain.Model.Interface;

namespace Infrastructure.Repository.Base;

public abstract class EntityRepositoryBase<T> : IGuidGenericRepositoryBase<T> where T: class, IEntity
{
    protected readonly IApplicationDbContext Context;

    protected EntityRepositoryBase(IApplicationDbContext context)
    {
        Context = context;
    }
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task<T?> FindByIdAsync(int id)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<T>> FindAllAsync()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public async Task AddAsync(T entity, bool save = true)
    {
        await Context.Set<T>().AddAsync(entity);
        if (save)
            await Context.SaveChangesAsync();
    }

    public async Task Remove(T entity, bool save = true)
    {
        Context.Set<T>().Remove(entity);
        if (save)
            await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity, bool save = true)
    {
        Context.Set<T>().Update(entity);
        if (save)
            await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> FindAllBySpecificationAsync(ISpecification<T>? specification = null)
    {
        return await Context.Set<T>().ApplySpecification(specification).ToListAsync();
    }

    public IQueryable<T> GetQuery(ISpecification<T>? specification = null)
    {
        return Context.Set<T>().ApplySpecification(specification);
    }

    public async Task<T?> FindBySpecificationAsync(ISpecification<T>? specification = null)
    {
        return await Context.Set<T>().ApplySpecification(specification).FirstOrDefaultAsync();
    }

    public async Task<T?> FindByGuidAsync(Guid id)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(p => p.Guid == id);
    }
    
}