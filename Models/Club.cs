using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworksProject.Models
{
    [Table("Club")]
    public class Club 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Url]
        public string Website { get; set; }

        [Range(1992, 2022)]
        public int CreationYear { get; set; }
        public string Logo { get; set; }
        public List<Event> Events { get; set; }
        public List<Member> Members { get; set; }

        public Club()
        {
            this.Members = new List<Member>();
            this.Events = new List<Event>();
        }

        public Club(string name, string description, string website, int creationYear, string logo)
        {
            this.Name = name;
            this.Description = description;
            this.Website = website;
            this.CreationYear = creationYear;
            this.Logo = logo;
            this.Members = new List<Member>();
            this.Events = new List<Event>();
        }


        public override string ToString()
        {
            string ev = "";
            string mem = "";

            for (var i= 0; i < Events.Count(); i++)
            {
                ev += Events[i].Name + " ";
            }

            for (var i = 0; i < Members.Count(); i++)
            {
                mem += Members[i].Name + " ";
            }

            return "id: " + Id.ToString() + " name: " + Name + " description: " + Description + " website: " + Website +  " event : {" + ev + "}"
                + " members: {" + mem +"}";
        }

    }
}
