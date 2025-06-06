using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace OnlineStore.Model.Dto.UserDto
{
    public class RoleClaimDto
    {
        [Required]
        public required string RoleName { get; set; }
        
        [Required]
        public required string ClaimType { get; set; }

        [Required]
        public required string ClaimValue { get; set; }
    }
}