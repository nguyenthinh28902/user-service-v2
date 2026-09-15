using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Infrastructure.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(); // Trả về số dòng bị ảnh hưởng
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
