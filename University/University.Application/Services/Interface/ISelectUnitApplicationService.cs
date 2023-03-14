using University.Core.Models;

namespace University.Application.Services
{
    public interface ISelectUnitApplicationService
    {
        Task<List<SelectUnit>> UnitsList(int pagenumber, int pagesize);
        Task<int> NewUnit(SelectUnitDto dto);
        Task<List<string>> ShowSelectUnitTimes(SelectUnitDto dto);
        Task<bool> UpdateTimes(SelectUnitDto dto);
        Task<bool> TimeOutSelectUnit(SelectUnitDto dto);
    }
}