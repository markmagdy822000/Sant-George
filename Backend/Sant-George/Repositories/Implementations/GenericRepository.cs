using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Sant_George.Models;
using Sant_George.Repositories.Interfaces;

namespace Sant_George.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        public SantGeorgeWebsiteDBContext _context{ get; set; }
        public GenericRepository(SantGeorgeWebsiteDBContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var e = await GetByIdAsync(id);
            _context.Set<T>().Remove(e);
        }
        public async Task DeleteAsync(string id)
        {
            var e = await GetByIdAsync(id);
            _context.Set<T>().Remove(e);
        }
        public async Task<ICollection<T>> GetAllAsync()
        {
            return  _context.Set<T>().AsNoTracking().ToList();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> UpdateAsync(T entity, int id)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
