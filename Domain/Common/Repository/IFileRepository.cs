using Domain.Common.Repository.Base;
using Domain.Model.Generic;
using File = Domain.Model.Generic.File;

namespace Domain.Common.Repository;

public interface IFileRepository : IGuidGenericRepositoryBase<File>
{
    
}