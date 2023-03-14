using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Core.Models;

namespace University.Application.Dtos
{
    public partial class UserDto
    {
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }
        public string ProfilePhoto { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
    }
}
