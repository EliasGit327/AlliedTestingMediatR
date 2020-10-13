using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class OrganisationDto
    {
        [Required]
        [StringLength(120, ErrorMessage = "{0} length of address must be between {2} and {1}.", MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        public AddressDto Address { get; set; }
    }
}