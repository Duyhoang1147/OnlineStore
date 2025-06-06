using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Model.UserEntity;

namespace OnlineStore.Model.Dto.UserDto
{
    public class RoleDto
    {
        [Required]
        public required User User { get; set; }
        
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}