using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Domain.Dtos;
using MediatR;
using MongoDB.Driver;

namespace Application.Registrations.Commands.CreateRegistration
{
    public class CreateRegistrationCommand : IRequest<CreateRegistrationDto>
    {
        public RegistrationDto RegistrationDto { get; set; }
    }

    public class CreateRegistrationCommandHandler : IRequestHandler<CreateRegistrationCommand, CreateRegistrationDto>
    {
        private readonly IMongoCollection<Registration> _registrationsDb;
        private readonly IMapper _mapper;

        public CreateRegistrationCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
            var client = new MongoClient
            (
                "mongodb+srv://AlliedTesting:Pass321@cluster0.zw1vb.azure.mongodb.net/<dbname>?retryWrites=true&w=majority"
            );
            _registrationsDb = client.GetDatabase("AT").GetCollection<Registration>("Registrations");
        }

        public async Task<CreateRegistrationDto> Handle(CreateRegistrationCommand request,
            CancellationToken cancellationToken)
        {
            var obj = new RegistrationDto() {Locale = "en"};
            var registration = _mapper.Map<Registration>(request.RegistrationDto);
            await _registrationsDb.InsertOneAsync
            (
                registration, cancellationToken: cancellationToken
            );
            return new CreateRegistrationDto();
        }
    }
}