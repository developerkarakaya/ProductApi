using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Domain.Entities
{
    public class User:IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string? RefleshToken { get; set; }
        public DateTime? RefleshTokenExpiryTime { get; set; }
    }
}
