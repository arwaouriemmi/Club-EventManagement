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
        public int Id { get; set; }

        public string Name { get; set; }
        public string Role { get; set; }

        public Club Club { get; set; }

        public Member()
        {
        }

        public Member(string name, string role, Club club)
        {
            this.Name = name;
            this.Role = role;
            this.Club = club;
        }

        public override string ToString()
        {
            return Role +": "+ Name;
        }

    }
}
