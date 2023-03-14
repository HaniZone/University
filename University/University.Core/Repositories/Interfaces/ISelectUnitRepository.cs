using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public interface ISelectUnitRepository
    {
        Task<List<SelectUnit>> GetAllUnits(int pagenumber, int pagesize);
        Task<SelectUnit> GetInfoById(int id);
        Task<List<string>> GetStartAndEndById(int id);
        Task<List<string>> ShowUnitLimit(int id);
        Task<int> SaveChangesAsync();

        void AddNewUnit(SelectUnit selectUnit);
        void RemoveUnit(SelectUnit selectUnit);
    }
}