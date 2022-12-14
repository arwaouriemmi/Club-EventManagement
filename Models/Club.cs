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
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string website { get; set; }

        [Range(1992, 2022)]
        public int creationYear { get; set; }
        public string logo { get; set; }
        public List<Event> events { get; set; }
        public List<Member> members { get; set; }

        public Club()
        {
            this.members = new List<Member>();
            this.events = new List<Event>();
        }

        public Club(string name, string description, string website, int creationYear, string logo)
        {
            this.name = name;
            this.description = description;
            this.website = website;
            this.creationYear = creationYear;
            this.logo = logo;
            this.members = new List<Member>();
            this.events = new List<Event>();
        }

        public override string ToString()
        {
            string ev = "";
            string mem = "";

            for (var i= 0; i < events.Count(); i++)
            {
                ev += events[i].Name + " ";
            }

            for (var i = 0; i < members.Count(); i++)
            {
                mem += members[i].name + " ";
            }

            return "id: " + id.ToString() + " name: " + name + " description: " + description + " website: " + website +  " event : {" + ev + "}"
                + " members: {" + mem +"}";
        }
    }
}
