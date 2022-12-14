using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworksProject.Models
{
    [Table("Member")]
    public class Member
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
        public string role { get; set; }

        public Club club { get; set; }

        public Member()
        {
        }

        public Member(string name, string role, Club club)
        {
            this.name = name;
            this.role = role;
            this.club = club;
        }


    }
}
