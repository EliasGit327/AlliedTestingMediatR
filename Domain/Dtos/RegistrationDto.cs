using System;

namespace Domain.Dtos
{
    public class RegistrationDto
    {
        public DateTime RegistrationDate { get; set; }
        public string Locale { get; set; }
        public PersonDto Person { get; set; }
        public OrganisationDto Organisation { get; set; }
    }
}