using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AJAX_Training.Models
{
    public class Training
    {
        public Training()
        {
            this.ID = 0;
            this.Name = null;
            this.Instructor = null;
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.Time = null;
            this.Duration = null;
        }

        public Training(int id, string name, string instructor, DateTime startdate, DateTime enddate, string time, string duration)
        {
            this.ID = id;
            this.Name = name;
            this.Instructor = instructor;
            this.StartDate = startdate;
            this.EndDate = enddate;
            this.Time = time;
            this.Duration = duration;
        }

        public Training(int id, string instructor)
        {
            this.ID = id;
            this.Instructor = instructor;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Instructor { get; set; }
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        public DateTime EndDate { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
    }
}