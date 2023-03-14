using University.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public class EfSelectUnitRepository : ISelectUnitRepository
    {
        private readonly DatabaseContext _context;

        public EfSelectUnitRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<SelectUnit>> GetAllUnits(int pagenumber, int pagesize)
        {
            var units = await _context.SelectUnits.Skip((pagenumber - 1) * 10).Take(pagesize).ToListAsync();
            return units;
        }

        public async Task<SelectUnit> GetInfoById(int id)
        {
            var units = await _context.SelectUnits.FirstOrDefaultAsync(x => x.SelectUnitId == id);
            return units;
        }

        public async Task<List<string>> GetStartAndEndById(int id)
        {
            var time = await _context.SelectUnits.Where(x => x.SelectUnitId == id).Select(x => x.Started + " " + x.Ended).ToListAsync();
            return time;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }


        public void AddNewUnit(SelectUnit selectUnit)
         {
             _context.SelectUnits.Add(selectUnit);
         }

         public void RemoveUnit(SelectUnit selectUnit)
         {
             _context.SelectUnits.Remove(selectUnit);
         }

        public async Task<List<string>> ShowUnitLimit(int id)
        {
            var time = await _context.SelectUnits.Where(x => x.SelectUnitId == id).Select(x => x.Limit + " " + x.SelectUnitId).ToListAsync();
            return time;
        }
    }
}
