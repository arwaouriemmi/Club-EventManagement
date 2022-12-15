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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string StaffForm { get; set; }
        public string ParticipationForm { get; set; }    
        public string Image { get; set; }
        public Club Club { get; set; }

        public Event()
        {
        }

        public Event(string name, string category, DateTime date, string description, string staffForm, string participationForm, string image, Club club)
        {
            this.Name = name;
            this.Category = category;
            this.Date = date;
            this.Description = description;
            this.StaffForm = staffForm;
            this.ParticipationForm = participationForm;
            this.Image = image;
            this.Club = club;
        }

        public override string ToString()
        {
            return "id: "+Id.ToString() + " name: "+Name + " category: "+ Category+ " date: " + Date.ToString() + " description: "+ Description + " club : {"+ Club.Name +"}" ;
        }
    }
}
