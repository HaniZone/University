using University.Core.Models;
using University.Infrastructure.Repositories;

namespace University.Application.Services
{
    public class SelectUnitCourseApplicationService : ISelectUnitCourseApplicationService
    {
        private readonly ISelectUnitCourseRepository _selectUnitCourseRepository;

        public SelectUnitCourseApplicationService(ISelectUnitCourseRepository selectUnitCourseRepository)
        {
            _selectUnitCourseRepository = selectUnitCourseRepository;
        }

        public async Task<int> NewSelectUnitCourse(SelectUnitCourseDto dto)
        {
            var newSelectUnitCourse = new SelectUnitCourse(dto.Capability);
            _selectUnitCourseRepository.AddNewSelectUnitCourse(newSelectUnitCourse);

            await _selectUnitCourseRepository.SaveChangesAsync();
            return newSelectUnitCourse.SelectUnitCourseId;
        }
        public async Task<List<SelectUnitCourse>> UnitCoursesList(int pagenumber, int pagesize)
        {
            var units = await _selectUnitCourseRepository.GetAllSelectUnitCourse(pagenumber, pagesize);
            return units;
        }

        public async Task<SelectUnitCourse> GetCapabilityById(SelectUnitCourseDto dto)
        {
            var capability = await _selectUnitCourseRepository.GetCapabilityById(dto.SelectUnitCourseId);
            return capability;
        }

        public async Task<bool> UpdateSelectUnitCourse(SelectUnitCourseDto dto)
        {
            var capability = await _selectUnitCourseRepository.GetCapabilityById(dto.SelectUnitCourseId);
            if (capability == null)
                throw new ApplicationException("SelectUnitCourse times not found");
            capability.Capability = dto.Capability;


            await _selectUnitCourseRepository.SaveChangesAsync();
            return true;
        }
    }
}
