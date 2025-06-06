using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace OnlineStore.Model.Dto.UserDto
{
    public class UpdateUserDto
    {
        public string Username { get; set; } = string.Empty;
        public List<ClaimDto> Claims { get; set; } = new List<ClaimDto>();
    }
}