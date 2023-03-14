using University.Core.Models;

namespace University.Application.Services
{
    public interface IFieldApplicationService
    {
        Task<int> NewField(FieldDto dto);
        Task<Field> GetFieldById(FieldDto dto);
        Task<List<Field>> FieldsList(int pagenumber, int pagesize);
        Task<bool> UpdateFieldInfo(FieldDto dto);
        Task<bool> DeleteField(FieldDto dto);

    }
}