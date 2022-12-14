using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworksProject.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public string staffForm { get; set; }
        public string participationForm { get; set; }
        
        public string image { get; set; }
        public Club club { get; set; }

        public Event()
        {
        }

        public Event(string name, string category, string date, string description, string staffForm, string participationForm, string image, Club club)
        {
            this.name = name;
            this.category = category;
            this.date = DateTime.Parse(date);
            this.description = description;
            this.staffForm = staffForm;
            this.participationForm = participationForm;
            this.image = image;
            this.club = club;
        }

        public override string ToString()
        {
            return "id: "+id.ToString() + " name: "+name + " category: "+ category+ " date: " + date.ToString() + " description: "+ description + " club : {"+ club.name +"}" ;
        }
    }
}
