using testecsharpmongodb.Domain.Entities;

namespace testecsharpmongodb.Application.Interfaces
{
    public interface IUserFormService
    {
        Task<IEnumerable<UserForm>> GetAllUserFormsAsync();
    }
}
