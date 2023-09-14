using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp.Common.Model
{
    public class Users
    {
        public Guid? UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }    

        public string Email { get; set; }

        public string FullName { get; set; }

        public Guid? ClassId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Grade { get; set; }

        public int? UserType { get; set; }

        public int? Gender { get; set; }
    }
}
