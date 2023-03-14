using University.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public class EfFieldRepository : IFieldRepository
    {
        private readonly DatabaseContext _context;

        public EfFieldRepository(DatabaseContext context)
        {
            _context = context;
        }


        public async Task<List<Field>> GetAllField(int pagenumber, int pagesize)
        {
            var field = await _context.Fields.Skip((pagenumber - 1) * 10).Take(pagesize).ToListAsync();
            return field;
        }

        public async Task<Field> GetInfoById(int id)
        {
            var field = await _context.Fields.FirstOrDefaultAsync(x => x.FieldId == id);
            return field;
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }


        public void AddNewField(Field field)
        {
            _context.Fields.Add(field);
        }

        public void RemoveField(Field field)
        {
            _context.Fields.Remove(field);
        }
    }
}
