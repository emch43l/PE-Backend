using Domain.Common.Repository.Base;
using File = Domain.Model.File;

namespace Domain.Common.Repository;

public interface IFileRepository : IGuidGenericRepositoryBase<File>
{
    
}