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
    public class GetRegistrationQuery : IRequest<Registration>
    {
        public string Id { get; set; }
    }

    public class GetRegistrationQueryHandler : IRequestHandler<GetRegistrationQuery, Registration>
    {
        private IMongoCollection<Registration> _registrationsDb;

        public GetRegistrationQueryHandler()
        {
            var client =
                new MongoClient(
                    "mongodb+srv://AlliedTesting:Pass321@cluster0.zw1vb.azure.mongodb.net/<dbname>?retryWrites=true&w=majority");
            _registrationsDb = client.GetDatabase("AT").GetCollection<Registration>("Registrations");

        }

        public async Task<Registration> Handle(GetRegistrationQuery request, CancellationToken cancellationToken)
        {
            return await _registrationsDb
                .Find(u => u.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}