using University.Core.Models;
using University.Infrastructure.Repositories;

namespace University.Application.Services
{
    public class FieldApplicationService : IFieldApplicationService
    {
        private readonly IFieldRepository _fieldRepository;

        public FieldApplicationService(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<int> NewField(FieldDto dto)
        {
            var newField = new Field(dto.Name, dto.SectionName, dto.MaxUnit, dto.MinUnit);
            _fieldRepository.AddNewField(newField);

            await _fieldRepository.SaveChangesAsync();
            return newField.FieldId;
        }

        public async Task<Field> GetFieldById(FieldDto dto)
        {
            var fieldInfo = await _fieldRepository.GetInfoById(dto.FieldId);
            return fieldInfo;
        }

        public async Task<List<Field>> FieldsList(int pagenumber, int pagesize)
        {
            var lists = await _fieldRepository.GetAllField(pagenumber, pagesize);
            return lists;
        }

        public async Task<bool> UpdateFieldInfo(FieldDto dto)
        {
            var field = await _fieldRepository.GetInfoById(dto.FieldId);
            if (field == null)
                throw new ApplicationException("Field not found");
            field.FieldName = dto.Name;
            field.SectionName = dto.SectionName;
            field.MaxUnit = dto.MaxUnit;
            field.MinUnit = dto.MinUnit;

            await _fieldRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteField(FieldDto dto)
        {
            var field = await _fieldRepository.GetInfoById(dto.FieldId);
            if (field == null)
                throw new ApplicationException("field not found");
            _fieldRepository.RemoveField(field);
            await _fieldRepository.SaveChangesAsync();
            return true;

        }
    }
}
