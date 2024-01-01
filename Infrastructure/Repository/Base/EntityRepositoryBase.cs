using ApplicationCore.Common.Interface;
using Domain.Common.Repository.Base;
using Domain.Common.Specification;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Base;

public abstract class EntityRepositoryBase<T> : IGuidGenericRepositoryBase<T> where T: class, IEntity
{
    protected readonly ISpecificationHandler<T> SpecificationHandler;
    protected readonly IApplicationDbContext Context;

    protected EntityRepositoryBase(ISpecificationHandler<T> specificationHandler, IApplicationDbContext context)
    {
        SpecificationHandler = specificationHandler;
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

    public async Task<bool> RemoveByIdAsync(int id)
    {
        int affectedRows = await Context.Set<T>().Where(p => p.Id == id).ExecuteDeleteAsync();

        return affectedRows > 0;
    }

    public async Task UpdateAsync(T entity, bool save = true)
    {
        Context.Set<T>().Update(entity);
        if (save)
            await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> FindBySpecificationAsync(ISpecification<T>? specification = null)
    {
        return await SpecificationHandler.Handle(Context.Set<T>(), specification).ToListAsync();
    }

    public async Task<T?> FindByGuidAsync(Guid id)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(p => p.Guid == id);
    }

    public async Task<bool> RemoveByGuidAsync(Guid id)
    {
        int affectedRows = await Context.Set<T>().Where(p => p.Guid == id).ExecuteDeleteAsync();

        return affectedRows > 0;
    }
}