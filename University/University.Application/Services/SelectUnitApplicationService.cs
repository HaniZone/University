using University.Core.Models;
using University.Infrastructure.Repositories;

namespace University.Application.Services
{
    public class SelectUnitApplicationService : ISelectUnitApplicationService
    {
        private readonly ISelectUnitRepository _selectUnitRepository;

        public SelectUnitApplicationService(ISelectUnitRepository selectUnitRepository)
        {
            _selectUnitRepository = selectUnitRepository;
        }

        public async Task<int> NewUnit(SelectUnitDto dto)
        {
            var newTime = new SelectUnit(dto.Started, dto.Ended, dto.Limit);
            _selectUnitRepository.AddNewUnit(newTime);

            await _selectUnitRepository.SaveChangesAsync();
            return newTime.SelectUnitId;
        }
        public async Task<List<SelectUnit>> UnitsList(int pagenumber, int pagesize)
        {
            var units = await _selectUnitRepository.GetAllUnits(pagenumber, pagesize);
            return units;
        }



        public async Task<bool> UpdateTimes(SelectUnitDto dto)
        {
            var times = await _selectUnitRepository.GetInfoById(dto.SelectUnitId);
            if (times == null)
                throw new ApplicationException("SelectUnit times not found");

            times.Started = dto.Started;
            times.Ended = dto.Ended;
            times.Limit = dto.Limit;

            await _selectUnitRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TimeOutSelectUnit(SelectUnitDto dto)
        {
            var times = await _selectUnitRepository.GetInfoById(dto.SelectUnitId);
            if (times == null)
                throw new ApplicationException("SelectUnit times not found");

            _selectUnitRepository.RemoveUnit(times);
            await _selectUnitRepository.SaveChangesAsync();
            return true;
        }

        public async Task<List<string>> ShowSelectUnitTimes(SelectUnitDto dto)
        {
            var time = await _selectUnitRepository.GetStartAndEndById(dto.SelectUnitId);
            return time;
        }

    }
}
