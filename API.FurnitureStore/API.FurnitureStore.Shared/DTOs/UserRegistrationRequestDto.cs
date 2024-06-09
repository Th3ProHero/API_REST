using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.FurnitureStore.Shared.DTOs
{
    public class UserRegistrationRequestDto
    {
        [Required]
        [MaxLength(255,ErrorMessage ="Name can't have more than 250 characteres")]
        public string  Name { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
