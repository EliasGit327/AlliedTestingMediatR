using System;
using Domain.Dtos;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public class Registration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Locale { get; set; }
        public PersonDto Person { get; set; }
        public OrganisationDto Organisation { get; set; }
    }
}