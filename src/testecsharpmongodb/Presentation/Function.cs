using Amazon.Lambda.Core;
using testecsharpmongodb.Application.Interfaces;
using testecsharpmongodb.Application.Services;
using testecsharpmongodb.Infrastructure.Repositories;
using testecsharpmongodb.Domain.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace testecsharpmongodb
{
    public class Function
    {
        private readonly IUserFormService _userFormService;

        public Function()
    {
        // Definindo connectionString e databaseName dentro do construtor
        var connectionString = Environment.GetEnvironmentVariable("MongoDBConnectionString");
        var databaseName = Environment.GetEnvironmentVariable("MongoDBDatabaseName");

        if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
        {
            throw new InvalidOperationException("A string de conexão e o nome do banco de dados não podem ser nulos.");
        }

        var mongoClient = new MongoClient(connectionString);
        var database = mongoClient.GetDatabase(databaseName);

        // Injeção de Dependência
        var userFormRepository = new UserFormRepository(database);
        _userFormService = new UserFormService(userFormRepository);
    }

        public async Task<List<UserForm>> GetAllUserForms(ILambdaContext context)
        {
            var result = await _userFormService.GetAllUserFormsAsync();
            return result.ToList();
        }
    }
}
