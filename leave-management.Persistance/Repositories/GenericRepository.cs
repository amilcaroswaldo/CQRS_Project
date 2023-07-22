using leave_management.Application.Contracts.Persistence;
using leave_management.Domain.Common;
using leave_management.Persistance.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leave_management.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DBContextPg _dBContext;

        public GenericRepository(DBContextPg dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _dBContext.AddAsync(entity);
            await _dBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dBContext.Remove(entity);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync() => await _dBContext.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> GetByIdAsync(int id)
        {
            var getBydId = await _dBContext.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id);
            return getBydId ?? throw new ArgumentNullException(nameof(getBydId));
        }

        public async Task UpdateAsync(T entity)
        {
            _dBContext.Entry(entity).State = EntityState.Modified;
            await _dBContext.SaveChangesAsync();
        }
    }
}
