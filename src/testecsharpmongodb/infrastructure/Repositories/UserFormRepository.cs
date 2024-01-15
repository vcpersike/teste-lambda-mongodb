using testecsharpmongodb.Application.Interfaces;
using testecsharpmongodb.Domain.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace testecsharpmongodb.Infrastructure.Repositories
{
    public class UserFormRepository : IUserFormService
    {
        private readonly IMongoCollection<UserForm> _userFormCollection;

        public UserFormRepository(IMongoDatabase database)
        {
            _userFormCollection = database.GetCollection<UserForm>("userform");
        }

        public async Task<IEnumerable<UserForm>> GetAllUserFormsAsync()
        {
            return await _userFormCollection.Find(_ => true).ToListAsync();
        }
    }
}
