using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace AccountManagement.Application.Contract.Address
{
    public class CreateAddress
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(50,ErrorMessage = ValidationMessages.MaxLength)]
        public string Country { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(70, ErrorMessage = ValidationMessages.MaxLength)]
        public string State { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLength)]
        public string City { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]
        public string FullAddress { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [Range(1,9999999999,ErrorMessage = ValidationMessages.MaxLength)]
        public int ZipCode { get; set; }
        public long AccountId { get; set; }
    }
}
