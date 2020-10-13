using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using MongoDB.Driver;

namespace Application.Registrations.Queries.GetAllRegistrations
{
    public class GetAllRegistrationsQuery: IRequest<IEnumerable<Registration>> {}
    
    public class GetAllRegistrationsQueryHandler: IRequestHandler<GetAllRegistrationsQuery, IEnumerable<Registration>>
    {
        private readonly IMongoCollection<Registration> _registrationsDb;
            
        public GetAllRegistrationsQueryHandler()
        {
            var client = new MongoClient("mongodb+srv://AlliedTesting:Pass321@cluster0.zw1vb.azure.mongodb.net/<dbname>?retryWrites=true&w=majority");
            _registrationsDb = client.GetDatabase("AT").GetCollection<Registration>("Registrations");

        }
            
        public async Task<IEnumerable<Registration>> Handle(GetAllRegistrationsQuery request, CancellationToken cancellationToken)
        {
            // var response = new List<string>() { "1", "2", "3"};
            var response = _registrationsDb.Find(r => true).ToListAsync(cancellationToken: cancellationToken);
            return await Task.Run(() => response);
        }
    }
}