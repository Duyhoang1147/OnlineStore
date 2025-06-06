using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Model.Dto.UserDto
{
    public class ChangePasswordDto
    {
        [Required]
        public required string OldPassword { get; set; }

        [Required]
        public required string newPassword { get; set; }
        
        [Required]
        public required string ConfirmNewPassword { get; set; }
    }
}