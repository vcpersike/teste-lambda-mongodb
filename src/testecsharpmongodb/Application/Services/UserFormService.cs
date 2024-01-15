using testecsharpmongodb.Application.Interfaces;
using testecsharpmongodb.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace testecsharpmongodb.Application.Services
{
    public class UserFormService : IUserFormService
    {
        private readonly IUserFormService _userFormRepository;

        public UserFormService(IUserFormService userFormRepository)
        {
            _userFormRepository = userFormRepository;
        }

        public async Task<IEnumerable<UserForm>> GetAllUserFormsAsync()
        {
            return await _userFormRepository.GetAllUserFormsAsync();
        }
    }
}
